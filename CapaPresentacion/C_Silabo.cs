using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaNegocio;
using CapaEntidades;

namespace CapaPresentacion
{
    public partial class C_Silabo : UserControl
    {
        //Declarar un delegate y Event. StatusUpdate
        public delegate void StatusUpdateHandler(object sender, EventArgs e);
        public event StatusUpdateHandler OnUpdateStatus;

        int asignacionID;
        string Semestre = "2021-I";
        N_SubirSilabo Subir_Silabo;
        N_Silabo n_Silabo = new N_Silabo();
        DataTable dt_SubirSilabo;
        DataTable dias;
        DataRow curSemestre;
        DataTable dt_avanzado;
        List<string> listAvanzados;
        public C_Silabo (int pAsignacionID)
        {
            asignacionID = pAsignacionID;
            InitializeComponent();
            btnSubirSilabo.Visible = false;
            btnGuardar.Visible = false;
            RefrescarDGV();
        }
        private void RefrescarDGV()
        {
            dgvSubirSilabo.DataSource = null;
            dgvSubirSilabo.Rows.Clear();
            dgvSubirSilabo.Columns.Clear();
            dgvSubirSilabo.Refresh();

            dt_SubirSilabo = n_Silabo.Mostrar(Semestre, asignacionID);
            if (dt_SubirSilabo != null)
            {
                btnSubirSilabo.Visible = false;
                dgvSubirSilabo.DataSource = dt_SubirSilabo;
                dgvSubirSilabo.Columns["ID"].Visible = false;
                dgvSubirSilabo.Columns["Asignacion"].Visible = false;
            }
            else
            {
                btnSubirSilabo.Visible = true;
            }
        }
        private void RellenarHeaders()
        {
            // rellenar DGV
            dgvSubirSilabo.DataSource = null;
            dgvSubirSilabo.Rows.Clear();
            dgvSubirSilabo.Refresh();

            dgvSubirSilabo.ColumnCount = 4;
            dgvSubirSilabo.Columns[0].Name = "Unidad";
            dgvSubirSilabo.Columns[1].Name = "Capítulo";
            dgvSubirSilabo.Columns[2].Name = "Tema";
            dgvSubirSilabo.Columns[3].Name = "NroHoras";
        }

        private void btnSubirSilabo_Click(object sender, EventArgs e)
        {
            Subir_Silabo = new N_SubirSilabo(asignacionID);
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;

                int nroFilas = Subir_Silabo.Procesar(file);

                RellenarHeaders();
                Console.WriteLine(dgvSubirSilabo.Columns[0].Name);
                foreach (N_Silabo SSilabo in Subir_Silabo.getSilabo())
                {
                    string[] row = {
                            SSilabo.Unidad,  SSilabo.Capitulo, SSilabo.Tema, SSilabo.NroHoras.ToString()};
                    dgvSubirSilabo.Rows.Add(row);
                }
                MessageBox.Show(nroFilas + " filas leidas", "Sistema de Gestion de Sílabos");
            }
            if (Subir_Silabo.getSilabo().Count() > 0)
            {
                btnGuardar.Visible = true;
            }
            if (Subir_Silabo.getSilabo().Count() == 0)
            {
                RefrescarDGV();
                MessageBox.Show("Error! Elegir otro archivo", "Sistema de Gestion de Sílabos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {

            foreach (N_Silabo SSilabo in Subir_Silabo.getSilabo())
            {
                SSilabo.Guardar();
                //MessageBox.Show("Se guardó carga correctamente", "Sistema de Gestión de Silabos");
            }


            btnGuardar.Visible = false;
            RefrescarDGV();
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            if (dgvSubirSilabo.Rows.Count > 0)
            {
                int index = dgvSubirSilabo.SelectedCells[0].RowIndex;
                if (index >= 0 && index < dgvSubirSilabo.Rows.Count - 1)
                {
                    E_Silabo Silabo = new E_Silabo();
                    Silabo.ID = Int32.Parse(dgvSubirSilabo.Rows[index].Cells[0].Value.ToString());
                    Silabo.Asignacion = Int32.Parse(dgvSubirSilabo.Rows[index].Cells[1].Value.ToString());
                    Silabo.Unidad = dgvSubirSilabo.Rows[index].Cells[2].Value.ToString();
                    Silabo.Capitulo = dgvSubirSilabo.Rows[index].Cells[3].Value.ToString();
                    Silabo.Tema = dgvSubirSilabo.Rows[index].Cells[4].Value.ToString();
                    Silabo.NroHoras = Int32.Parse(dgvSubirSilabo.Rows[index].Cells[5].Value.ToString());
                    Frm_AddSilabo AddSilabo = new Frm_AddSilabo(Silabo, true);
                    AddSilabo.ShowDialog();
                    RefrescarDGV();
                }
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {

            if (dgvSubirSilabo.Rows.Count > 0)
            {
                int index = dgvSubirSilabo.SelectedCells[0].RowIndex;
                if (index >= 0 && index < dgvSubirSilabo.Rows.Count - 1)
                {
                    E_Silabo Silabo = new E_Silabo();
                    String ID = dgvSubirSilabo.Rows[index].Cells[0].Value.ToString();
                    String tmpNombre = dgvSubirSilabo.Rows[index].Cells[1].Value.ToString();
                    tmpNombre += " - " + dgvSubirSilabo.Rows[index].Cells[2].Value.ToString();
                    tmpNombre += " " + dgvSubirSilabo.Rows[index].Cells[3].Value.ToString();
                    tmpNombre += " " + dgvSubirSilabo.Rows[index].Cells[4].Value.ToString();
                    DialogResult confirm = MessageBox.Show("¿Realmente desea eliminar silabo " + tmpNombre + "?", "Sistema de Silabos", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (confirm == DialogResult.OK)
                    {

                        if (new N_Silabo { ID = Silabo.ID }.Eliminar(ID))
                            MessageBox.Show("silabo " + tmpNombre + " eliminado!");
                        else
                            MessageBox.Show("No se pudo eliminar silabo " + tmpNombre + "!");
                        RefrescarDGV();

                    }
                }
            }
        }
        private void UpdateStatus()
        {
            //Crear arguments.
            EventArgs args = new EventArgs();

            //llamar a escuchadores, padres
            OnUpdateStatus?.Invoke(this, args);

        }
        private void btnAtras_Click(object sender, EventArgs e)
        {
            UpdateStatus();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Frm_AddSilabo AddCurso = new Frm_AddSilabo(null, false, asignacionID);
            AddCurso.ShowDialog();
            RefrescarDGV();
        }

        private string diaEspañol(string day)
        {
            day = day.ToLower();
            string dia = "-1";
            if (day == "monday" || day == "lunes")
                dia = "lunes";
            else if (day == "tuesday" || day == "martes")
                dia = "martes";
            else if (day == "wednesday" || day == "miercoles")
                dia = "miercoles";
            else if (day == "thursday" || day == "jueves")
                dia = "jueves";
            else if (day == "friday" || day == "viernes")
                dia = "viernes";
            else if (day == "saturday" || day == "sabado")
                dia = "sabado";
            else if (day == "sunday" || day == "domingo")
                dia = "domingo";
            return dia.ToUpper();
        }
        private List<string> ObtenerLista(string texto, DataTable dt = null)
        {
            if (dt != null)
            {
                List<string> list = new List<string>();
                foreach (DataRow dr in dt.Rows)
                {
                    string item = dr[texto].ToString();
                    if (!list.Contains(item)) list.Add(item);
                }
                return list;
            }
            return null;
        }
        private int nroHoras(string dia)
        {
            foreach(DataRow row in dias.Rows)
            {
                if (row["Dia"].ToString() == dia)
                    return Convert.ToInt32(row["NroHoras"].ToString());
            }
            return 0;
        }
        private void fillChart(List<string> lista, string serie, bool fechas = false)
        {

            DateTime minDate = Convert.ToDateTime(curSemestre["Fecha_inicio"].ToString());
            DateTime maxDate = Convert.ToDateTime(curSemestre["Fecha_fin"].ToString());
            DateTime curDate = minDate;
            List<Tuple<DateTime, int>> ejeX = new List<Tuple<DateTime, int>>();
            List<Tuple<string, int>> ejeY = new List<Tuple<string, int>>();

            // rellenar fechas de avance
            int x = 0;
            while (DateTime.Compare(curDate, maxDate) <= 0)
            {
                string hoy = diaEspañol(curDate.DayOfWeek.ToString());
                foreach (DataRow row in dias.Rows)
                {
                    if (row["Dia"].ToString().ToUpper() == hoy)
                    {
                        ejeX.Add(new Tuple<DateTime, int>(curDate, x));
                        x++;
                    }
                }

                curDate = curDate.AddDays(1);
            }

            int yi, xi = 0;
            int y = 0;

            // Avance ideal
            if (dt_SubirSilabo != null)
            {
                int nroHorasDia = 0;
                int nroHorasTema = 0;
                string dia = diaEspañol(ejeX[xi].Item1.DayOfWeek.ToString());
                nroHorasDia = nroHoras(dia);
                foreach (DataRow tema in dt_SubirSilabo.Rows)
                {
                    nroHorasTema = Convert.ToInt32(tema["NroHoras"]);
                    
                    while (nroHorasTema > 0)
                    {
                        dia = diaEspañol(ejeX[xi].Item1.DayOfWeek.ToString());
                        chartAvance.Series["Ideal"].Points.AddXY(ejeX[xi].Item2, y);
                        nroHorasTema -= nroHorasDia;
                        if (nroHorasTema >= 0)
                        {
                            xi++;
                            nroHorasDia = nroHoras(dia);
                        }
                        else
                            nroHorasDia = -1 * nroHorasTema;
                    }
                    ejeY.Add(new Tuple<string, int>(tema["Tema"].ToString(), y));
                    y++;
                }
            }
            // Avance real
            listAvanzados = new List<string>();
            if (dt_avanzado != null)
            {
                foreach (DataRow tema in dt_avanzado.Rows)
                {
                    string item = tema["Tema"].ToString();
                    DateTime fechaAvance = Convert.ToDateTime(tema["Fecha"].ToString());
                    
                    bool added = false;
                    xi = 0; yi = 0;
                    while (xi < ejeX.Count() && !added)
                    {
                        if(DateTime.Compare(fechaAvance.Date, ejeX[xi].Item1.Date) == 0)
                        {
                            while (yi < ejeY.Count() && !added)
                            {
                                if(ejeY[yi].Item1 == item)
                                {
                                    Console.WriteLine(item);
                                    chartAvance.Series["Real"].Points.AddXY(ejeX[xi].Item2, ejeY[yi].Item2);
                                    added = true;
                                }
                                yi++;
                            }
                        }
                        xi++;
                    }
                    if (!listAvanzados.Contains(item))
                    {
                        listAvanzados.Add(item);
                    }
                }
            }
            // Rellenar labels
            
            labelTemasCursados.Text = listAvanzados.Count.ToString();
            labelTemasRestantes.Text = (ejeY.Count - listAvanzados.Count).ToString();
            if(listAvanzados.Count > 0)
                labelTemaUltimo.Text = listAvanzados[listAvanzados.Count-1];
            else
                labelTemaUltimo.Text = "";
        }

        private void C_Silabo_Load(object sender, EventArgs e)
        {
            curSemestre = new N_Semestre().MostrarUltimo();
            
            dias = new N_Dia().DiasAsignacion(asignacionID.ToString());
            dt_avanzado = new N_RegistroAvance().Mostrar(asignacionID);
            //List<string> avanzado = ObtenerLista("Tema", dt_avanzado);
            List<string> subirSilabo = ObtenerLista("Tema", dt_SubirSilabo);

            fillChart(subirSilabo, "Ideal");
        }
    }
}
