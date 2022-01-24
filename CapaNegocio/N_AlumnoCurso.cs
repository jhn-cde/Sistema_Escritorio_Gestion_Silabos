﻿using CapaDatos;
using CapaEntidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace CapaNegocio
{
    public class N_AlumnoCurso
    {
        public int Asignacion { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "ID requerido")]
        public int NRO { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "NRO requerido")]
        public string CodAlumno { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Unidad es requerido")]

        D_AlumnoCurso d_AlumnoCurso = new D_AlumnoCurso();

        public override string ToString()
        {
            return "AsignacionID: " + Asignacion + ", CodAlumno: " + CodAlumno;
        }

        public int Guardar()
        {
            E_AlumnoCurso e_AlumnoCurso = new E_AlumnoCurso
            {
                Asignacion = this.Asignacion,
                NRO = this.NRO,
                CodAlumno = this.CodAlumno,
            };

            Console.WriteLine("Guardando: " + this.ToString());
            d_AlumnoCurso.Agregar(e_AlumnoCurso);
            return 1;
        }
        public DataTable Mostrar(int Asignacion)
        {
            return d_AlumnoCurso.MostrarAsignacion(Asignacion);
        }
        public DataTable Buscar(int Asignacion, string texto)
        {
            return d_AlumnoCurso.Buscar(Asignacion, texto);
        }
        public bool Editar()
        {
            return d_AlumnoCurso.Editar(new E_AlumnoCurso
            {
                Asignacion = this.Asignacion,
                NRO = this.NRO,
                CodAlumno = this.CodAlumno,
            });
        }
        public bool Eliminar(int Asignacion, string CodAlumno)
        {
            return d_AlumnoCurso.Eliminar(Asignacion, CodAlumno);
        }
        public bool ElminarCurso(int Asignacion)
        {
            return d_AlumnoCurso.ElminarCurso(Asignacion);
        }
        public List<bool> AsistioFecha(int asignacion, string Fecha)
        {
            DataTable dataTable = d_AlumnoCurso.MostrarAsistenciaFecha(asignacion);
            List<bool> list = new List<bool>();
            if (dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    if(row["Fecha"].ToString().ToString() == Fecha)
                    {
                        list.Add(Convert.ToBoolean(row["Asistio"]));
                    }
                }
            }
            return list;
        }
        public List<string> Fechas(int asignacion)
        {
            DataTable dataTable = d_AlumnoCurso.MostrarAsistenciaFecha(asignacion);
            List<string> list = new List<string>();
            if(dataTable != null)
            {
                foreach (DataRow row in dataTable.Rows)
                {
                    if (!list.Contains(row["Fecha"].ToString()))
                    {
                        list.Add(row["Fecha"].ToString());
                    }
                }
            }
            return list;
        }
    }
}
