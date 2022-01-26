using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using CapaDatos;
using CapaNegocio;
using CapaEntidades;

namespace CapaPresentacion
{
    public partial class C_Control : UserControl
    {
        protected Conexion aConexion;
        N_Asistencia n_Asistencia = new N_Asistencia();
        N_RegistroAvance n_RegistroAvance = new N_RegistroAvance();
        DataTable temasNoCursados;
        DataTable ultimoTema;
        //Declarar un delegate y Event. StatusUpdate
        public delegate void StatusUpdateHandler(object sender, EventArgs e);
        public event StatusUpdateHandler OnUpdateStatus;

        int asignacionID;
        public C_Control(int pAsignacionID)
        {
            asignacionID = pAsignacionID;
            InitializeComponent();
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
        private void C_Control_Load(object sender, EventArgs e)
        {
           
        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        private List<string> ObtenerLista(string texto, DataTable dt = null)
        {
            if (dt == null)
            {
                dt = temasNoCursados;
            }
            List<string> list = new List<string>();
            foreach (DataRow dr in dt.Rows)
            {
                string item = dr[texto].ToString();
                if (!list.Contains(item)) list.Add(item);
            }
            return list;
        }
        private List<string> ObtenerCapitulo()
        {
            return ObtenerLista("Capitulo");
        }
        private List<string> ObtenerUnidad()
        {
            return ObtenerLista("Unidad");
        }
        private List<string> ObtenerTemas()
        {
            List<string> noCursados = ObtenerLista("Tema");
            List<string> list = new List<string>();

            if (ultimoTema != null)
            {
                list.Add(ultimoTema.Rows[0]["Tema"].ToString());
            }

            foreach (string item in noCursados) list.Add(item);
            return list;
        }
        private void Refrescar()
        {
            temasNoCursados = n_RegistroAvance.TemasSinAvanzar(asignacionID);
            ultimoTema = n_RegistroAvance.UltimoTema(asignacionID);
            if (temasNoCursados != null)
            {
                List<string> unidadlist = ObtenerUnidad();
                List<string> capitulolist = ObtenerCapitulo();
                List<string> temasList = ObtenerTemas();

                cbUnidad.Items.Clear();
                foreach (string item in unidadlist)
                {
                    cbUnidad.Items.Add(item);
                }
                cbCapitulo.Items.Clear();
                foreach (string item in capitulolist)
                {
                    cbCapitulo.Items.Add(item);
                }
                cbTema.Items.Clear();
                foreach (string item in temasList)
                {
                    cbTema.Items.Add(item);
                }

                cbTema.SelectedItem = temasNoCursados.Rows[0]["Tema"];
                cbCapitulo.SelectedItem = temasNoCursados.Rows[0]["Capitulo"];
                cbUnidad.SelectedItem = temasNoCursados.Rows[0]["Unidad"];
            }

            // rellenar lista de alumnos
            N_AlumnoCurso n_AlumnoCurso = new N_AlumnoCurso();
            DataTable dt_SubirAlumnosCurso = n_AlumnoCurso.Mostrar(asignacionID);
            if (dt_SubirAlumnosCurso != null)
            {
                dgvAlumnos.DataSource = dt_SubirAlumnosCurso;
            }
        }
        private void C_Control_Load_1(object sender, EventArgs e)
        {
            Refrescar();
        }
        private int idSilabo(DataTable dt1)
        {
            var value = cbTema.SelectedItem;
            foreach (DataRow dr in dt1.Rows)
            {
                if (dr["Tema"].ToString() == value.ToString())
                {
                    return Convert.ToInt32(dr["Id"]);
                }
            }
            return -1;
        }

        private int nroHoras(DataTable dt1)
        {
            var value = cbTema.SelectedItem;
            foreach (DataRow dr in dt1.Rows)
            {
                if (dr["Tema"].ToString() == value.ToString())
                {
                    return Convert.ToInt32(dr["NroHoras"].ToString());
                }
            }
            return -1;
        }
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (cbUnidad.SelectedIndex > -1 && cbCapitulo.SelectedIndex > -1 && cbTema.SelectedIndex > -1)
            {
                int IdSilabo = idSilabo(temasNoCursados);
                if (IdSilabo == -1)
                {
                    MessageBox.Show("Error al seleccionar");
                }
                else
                {
                    DateTime fecha = DateTime.Now;
                    n_RegistroAvance.ID_Silabo = IdSilabo;
                    n_RegistroAvance.Fecha = fecha;
                    n_RegistroAvance.Observacion = textBoxObservacion.Text;
                    n_RegistroAvance.NroHoras = nroHoras(temasNoCursados);
                    n_RegistroAvance.Guardar();                  
                    int IdAvance = n_RegistroAvance.IdRegistro(IdSilabo, fecha);
                    foreach (DataGridViewRow fila in dgvAlumnos.Rows)
                    {
                        DataGridViewCheckBoxCell b = (DataGridViewCheckBoxCell)fila.Cells["Asistencia"];
                        n_Asistencia.ID_Registro = IdAvance;
                        n_Asistencia.CodAlumno = fila.Cells[2].Value.ToString();
                        n_Asistencia.Asistio = Convert.ToBoolean(b.Value);
                        n_Asistencia.Guardar(); 
                    }
                    MessageBox.Show("Guardado Correctamente");
                }
                Refrescar();
            }
            else
            {
                MessageBox.Show("un item (Unidad, Capitulo o Tema) no esta seleccionado");
            }
        }

        private void cbTema_SelectedIndexChanged(object sender, EventArgs e)
        {
            var value = cbTema.SelectedItem;
            foreach (DataRow dr in temasNoCursados.Rows)
            {
                if(dr["Tema"].ToString() == value.ToString())
                {
                    cbCapitulo.SelectedItem = dr["Capitulo"];
                    cbUnidad.SelectedItem = dr["Unidad"];
                }
            }
        }
    }
}
