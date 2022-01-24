using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaDatos;
using CapaNegocio;
using CapaEntidades;

namespace CapaPresentacion
{
    class tuple
    {
        public tuple()
        {
            x = 0;
            y = 0;
        }
        public int x { get; set; }
        public int y { get; set; }
    }
    public partial class C_Alumno : UserControl
    {
        protected Conexion aConexion;
        //Declarar un delegate y Event. StatusUpdate
        public delegate void StatusUpdateHandler(object sender, EventArgs e);
        public event StatusUpdateHandler OnUpdateStatus;
        int AsignacionID;
        N_SubirAlumnos Subir_Alumnos;
        N_AlumnoCurso n_AlumnoCurso = new N_AlumnoCurso();
        DataTable dt_SubirAlumnosCurso;
        public C_Alumno(int pAsignacionID)
        {
            AsignacionID = pAsignacionID;
            InitializeComponent();
        }
        private DataTable sourceData(List<string> list)
        {
            DataTable table = new DataTable();
            table.Columns.Add("Nro".ToString());
            table.Columns.Add("Codigo".ToString());
            table.Columns.Add("Nombres".ToString());
            table.Columns.Add("Asistencias".ToString());
            table.Columns.Add("Faltas".ToString());
            foreach (string str in list)
            {
                string fecha = str.ToString();
                table.Columns.Add(fecha.ToString());
            }
            if (dt_SubirAlumnosCurso != null)
            {
                int tam = dt_SubirAlumnosCurso.Rows.Count;
                foreach (DataRow row in dt_SubirAlumnosCurso.Rows)
                {
                    DataRow dr = table.NewRow();
                    dr["Nro"] = row["NRO"];
                    dr["Codigo"] = row["CodAlumno"];
                    dr["Nombres"] = row["Nombres"];
                    table.Rows.Add(dr);
                }
                tuple[] rs = new tuple[tam];
                for (int i = 0; i < tam; i++)
                {
                    rs[i] = new tuple();
                }
                foreach (string str in list)
                {
                    string fecha = str.ToString();                    
                    List<bool> lista = n_AlumnoCurso.AsistioFecha(AsignacionID, fecha);
                    for (int i = 0; i < lista.Count; i++)
                    {
                        string value;
                        if (lista[i])
                        {
                            rs[i].x += 1;
                            value = "asistio";
                        }
                        else
                        {
                            rs[i].y += 1;
                            value = "falto";
                        }
                        table.Rows[i][fecha] = value;
                    }
                }
                for (int i = 0; i < tam; i++)
                {
                    table.Rows[i]["Asistencias"] = rs[i].x;
                    table.Rows[i]["Faltas"] = rs[i].y;
                }
            }
            return table;
        }
        private void RefrescarDGV()
        {
            dgvAlumnos.DataSource = null;
            dgvAlumnos.Rows.Clear();
            dgvAlumnos.Columns.Clear();
            //dgvAlumnos.Refresh();

            dt_SubirAlumnosCurso = n_AlumnoCurso.Mostrar(AsignacionID);
            List<string> list = n_AlumnoCurso.Fechas(AsignacionID);
            if (dt_SubirAlumnosCurso != null)
            {
                dgvAlumnos.DataSource = sourceData(list);
            }
            //int row = 0;

        }

        private void btnSubir_Click(object sender, EventArgs e)
        {
            dgvAlumnos.Visible = false;
            rTBSubirAlumnos.Visible = true;
            btnGuardar.Visible = true;
            rTBSubirAlumnos.Text = "  Copiar aqui la lista de alumnos matriculados";
            rTBSubirAlumnos.SelectionStart = 0;
            rTBSubirAlumnos.SelectionLength = rTBSubirAlumnos.Text.Length;
            rTBSubirAlumnos.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Tokenizar
            char[] delimiterChars = { '\t' };

            string text = rTBSubirAlumnos.Text;

            string[] words = text.Split(delimiterChars);

            Subir_Alumnos = new N_SubirAlumnos(AsignacionID, words);
            Subir_Alumnos.ProcesarCarga();
            foreach (N_Alumno Alumno in Subir_Alumnos.GetAlumnos())
            {
                Alumno.Guardar();
                //MessageBox.Show("Se guardó carga correctamente", "Sistema de Gestión de Silabos");
            }
            foreach (N_AlumnoCurso AlumnoCurso in Subir_Alumnos.GetAlumnosCurso())
            {
                AlumnoCurso.Guardar();
                //MessageBox.Show("Se guardó carga correctamente", "Sistema de Gestión de Silabos");
            }
            btnGuardar.Visible = false;
            RefrescarDGV();
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

        private void C_Alumno_Load(object sender, EventArgs e)
        {
            dgvAlumnos.Visible = true;
            rTBSubirAlumnos.Visible = false;
            btnGuardar.Visible = false;
            RefrescarDGV();
        }

        private void rTBSubirAlumnos_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
