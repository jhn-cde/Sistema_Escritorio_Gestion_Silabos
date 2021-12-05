﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CapaEntidades;

namespace CapaPresentacion
{
    public partial class C_Tarjeta : UserControl
    {
        private E_Curso curso;
        Color colorFondo;
        public C_Tarjeta(E_Curso pCurso)
        {
            curso = pCurso;
            colorFondo = Color.White;
            InitializeComponent();
        }
        public C_Tarjeta(E_Curso pCurso, Color pColorFondo)
        {
            curso = pCurso;
            colorFondo = pColorFondo;
            InitializeComponent();
        }

        private void C_Tarjeta_Load(object sender, EventArgs e)
        {
            // lbTitulo color de fondo
            panelTitulo.BackColor = this.colorFondo;
            // titulo
            lblTitulo.Text = curso.Nombre;
            lblCodigo.Text = curso.CodCurso + curso.Grupo;
        }

        private void btnSilabo_Click(object sender, EventArgs e)
        {
            // curso.CodCurso
        }
    }
}