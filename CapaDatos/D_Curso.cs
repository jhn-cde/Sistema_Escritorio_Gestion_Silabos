﻿using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaEntidades;

namespace CapaDatos
{
    public class D_Curso
    {
        // Definir la conexion a la base de datos
        readonly SqlConnection Conectar = new SqlConnection(ConfigurationManager.ConnectionStrings["Conexion"].ConnectionString);
        // Metodos abrir y cerrar la conexion
        public void Abrir()
        {
            if (Conectar.State == ConnectionState.Closed)
                Conectar.Open();
        }
        public void Cerrar()
        {
            if (Conectar.State == ConnectionState.Open)
                Conectar.Close();
        }
        // Metodos CRUD
        public bool AgregarCurso(E_Curso Curso)
        {
            string sql = "INSERT INTO dbo.TCurso (CodCurso, Nombre, Creditos, Categoria) VALUES (@CodCurso, @Nombre, @Creditos, @Categoria)";
            SqlCommand Comando = new SqlCommand(sql, Conectar);
            Comando.Parameters.AddWithValue("@CodCurso", Curso.CodCurso);
            Comando.Parameters.AddWithValue("@Nombre", Curso.Nombre);
            Comando.Parameters.AddWithValue("@Creditos", Curso.Creditos);
            Comando.Parameters.AddWithValue("@Categoria", Curso.Categoria);
            try
            {
                Abrir();
                int res = Comando.ExecuteNonQuery();
                Cerrar();
                return res==1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("C. Error al tratar de conectar con la base de datos", ex.Message);
                return false;
            }
        }
        public DataTable ObtenerCursos()
        {
            string sql = "SELECT * FROM TCurso";
            SqlCommand Comando = new SqlCommand(sql, Conectar);
            DataTable dt = new DataTable();
            try
            {
                
                Abrir();
                using (SqlDataReader dr = Comando.ExecuteReader())
                {
                    if (dr.HasRows)
                        dt.Load(dr);
                    else
                    {
                        Console.WriteLine("dr cursos vacio");
                        dt = null;
                    }
                }
                Cerrar();
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine("R. Error al tratar de conectar con la base de datos", ex.Message);
                return null;
            }

        }
        public DataTable BuscarCurso(String Texto)
        {
            string sql = "SELECT * FROM TCurso WHERE CodCurso LIKE (@Texto + '%') OR Nombre LIKE (@Texto + '%')";
            SqlCommand Comando = new SqlCommand(sql, Conectar);
            Comando.Parameters.AddWithValue("@Texto", Texto);
            DataTable dt = new DataTable();
            try
            {
                Abrir();
                using (SqlDataReader dr = Comando.ExecuteReader())
                {
                    if (dr.HasRows)
                        dt.Load(dr);
                    else
                    {
                        Console.WriteLine("dr cursos vacio");
                        dt = null;
                    }
                }
                Cerrar();
                return dt;
            }
            catch (Exception ex)
            {
                Console.WriteLine("R. Error al tratar de conectar con la base de datos", ex.Message);
                return null;
            }
        }
        public bool EditarCurso(E_Curso Curso)
        {
            string sql = "UPDATE dbo.TCurso SET Nombre = @Nombre, Creditos = @Creditos, Categoria = @Categoria WHERE CodCurso = @CodCurso";
            SqlCommand Comando = new SqlCommand(sql, Conectar);
            Comando.Parameters.AddWithValue("@CodCurso", Curso.CodCurso);
            Comando.Parameters.AddWithValue("@Nombre", Curso.Nombre);
            Comando.Parameters.AddWithValue("@Creditos", Curso.Creditos);
            Comando.Parameters.AddWithValue("@Categoria", Curso.Categoria);
                Abrir();
                int res = Comando.ExecuteNonQuery();
                Cerrar();
                return res == 1;
        }
        public bool EliminarCurso(E_Curso Curso)
        {
            string sql = "DELETE FROM TCurso WHERE CodCurso = @CodCurso";
            SqlCommand Comando = new SqlCommand(sql, Conectar);
            Comando.Parameters.AddWithValue("@CodCurso", Curso.CodCurso);
            try
            {
                Abrir();
                int res = Comando.ExecuteNonQuery();
                Cerrar();
                return res == 1;
            }
            catch (Exception ex)
            {
                Console.WriteLine("D. Error al tratar de conectar con la base de datos", ex.Message);
                return false;
            }
        }
    }
}
