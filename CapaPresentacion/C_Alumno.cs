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
    public partial class C_Alumno : UserControl
    {
        protected Conexion aConexion;
        //Declarar un delegate y Event. StatusUpdate
        public delegate void StatusUpdateHandler(object sender, EventArgs e);
        public event StatusUpdateHandler OnUpdateStatus;
        int AsignacionID;
        N_SubirAlumnos Subir_Alumnos;
        N_AlumnoCurso n_AlumnoCurso = new N_AlumnoCurso();
        public C_Alumno(int pAsignacionID)
        {
            AsignacionID = pAsignacionID;
            InitializeComponent();
        }
        private void RefrescarDGV()
        {
            dgvAlumnos.DataSource = null;
            dgvAlumnos.Rows.Clear();
            dgvAlumnos.Columns.Clear();
            //dgvAlumnos.Refresh();

            DataTable dt_alumnos = new N_Asistencia().Reporte(AsignacionID);

            //dt_SubirAlumnosCurso = n_AlumnoCurso.Mostrar(AsignacionID);
            //List<string> list = n_AlumnoCurso.Fechas(AsignacionID);
            if (dt_alumnos != null)
            {
                dgvAlumnos.DataSource = dt_alumnos;
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
