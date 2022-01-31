using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidades;

namespace CapaDatos
{
    public class D_RegistroAvance
    {
        Conexion conexion = new Conexion();
        protected Conexion aConexion;
        // Metodos CRUD
        public bool Agregar(E_RegistroAvance pRegistro)
        {
            string sql = "INSERT INTO dbo.TRegistroAvance (ID_Silabo, Fecha, NroHoras, FechaRegistro, Observacion) " +
                                    "VALUES (@ID_Silabo, @Fecha, @nroHoras, @FechaRegistro, @Observacion)";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@ID_Silabo", pRegistro.ID_Silabo);
            conexion.cmd.Parameters.AddWithValue("@Fecha", pRegistro.Fecha);
            conexion.cmd.Parameters.AddWithValue("@Observacion", pRegistro.Observacion);
            conexion.cmd.Parameters.AddWithValue("@nroHoras", pRegistro.NroHoras);
            conexion.cmd.Parameters.AddWithValue("@FechaRegistro", pRegistro.FechaRegistro);

            return conexion.executeNonQuery() == 1;
        }
        public DataTable MostrarAsignacion(int AsignacionID)
        {
            string sql = "SELECT Unidad,  Capitulo, Tema, R.NroHoras, Fecha, Observacion " +
                "FROM TRegistroAvance R INNER JOIN TSilabo S ON R.ID_Silabo = S.ID " +
                "WHERE Asignacion = @Asignacion";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@Asignacion", AsignacionID);
            return conexion.executeReader();
        }
        public DataTable Buscar(int AsignacionID, String Texto)
        {
            string sql = "SELECT Unidad,  Capitulo, Tema, NroHoras, Fecha, Observacion " +
                "FROM TRegistroAvance R INNER JOIN TSilabo S ON R.ID_Silabo = S.ID " +
                "WHERE Asignacion = @Asignacion AND (Unidad LIKE (@Texto + '%') OR Capitulo LIKE (@Texto + '%') " +
                "OR Tema LIKE (@Texto + '%'))";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@Asignacion", AsignacionID);
            conexion.cmd.Parameters.AddWithValue("@Texto", Texto);

            return conexion.executeReader();
        }
        public DataTable BuscarID(int pID)
        {
            string sql = "Select * from TRegistroAvance where ID = @ID";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@ID", pID);

            return conexion.executeReader();
        }
        public bool Editar(E_RegistroAvance pRegistro)
        {
            string sql = "UPDATE dbo.TRegistroAvance SET Fecha = @Fecha, Observacion = @Observacion, FechaRegistro = @FechaRegistro WHERE ID = @ID";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@ID", pRegistro.ID);
            conexion.cmd.Parameters.AddWithValue("@Fecha", pRegistro.Fecha);
            conexion.cmd.Parameters.AddWithValue("@Observacion", pRegistro.Observacion);
            conexion.cmd.Parameters.AddWithValue("@FechaRegistro", pRegistro.FechaRegistro);
            return conexion.executeNonQuery() == 1;
        }
        public bool Eliminar(string ID)
        {
            string sql = "DELETE FROM TRegistroAvance WHERE ID = @ID";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@ID", ID);

            return conexion.executeNonQuery() == 1;
        }
        public DataTable UltimoTema(int IdAsignacion)
        {
            string sql = "select S.ID, S.Unidad, S.Capitulo, S.Tema, S.NroHoras from TSilabo S inner JOIN TRegistroAvance R " +
                "ON S.Id = R.ID_Silabo  where S.Asignacion = @IdAsignacion "+
                "order by Fecha desc";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@IdAsignacion", IdAsignacion);
            return conexion.executeReader();
        }
        public DataTable TemasSinAvanzar(int IdAsignacion)
        {
            string sql = "select S.ID, S.Unidad, S.Capitulo, S.Tema, S.NroHoras from TSilabo S  Left JOIN TRegistroAvance R " +
                "ON S.Id = R.ID_Silabo  where R.ID_Silabo IS NULL and S.Asignacion = @IdAsignacion";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@IdAsignacion", IdAsignacion);
            return conexion.executeReader();
        }
        public DataTable Temas(int IdAsignacion)
        {
            string sql = "select ID, Unidad, Capitulo, Tema, NroHoras from TSilabo where Asignacion = @IdAsignacion";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@IdAsignacion", IdAsignacion);
            return conexion.executeReader();
        }
        public DataTable ObtenerRegistro(int idSilabo, DateTime fecha)
        {
            string sql = "select * from TRegistroAvance where ID_Silabo = @IdSilabo and FechaRegistro = @Fecha";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@IdSilabo", idSilabo);
            conexion.cmd.Parameters.AddWithValue("@Fecha", fecha);
            return conexion.executeReader();
        }
        public DataTable NroHorasDia(DateTime fecha)
        {
            string sql = "select Sum(NroHoras) as Horas from TRegistroAvance where CONVERT(date, Fecha) = CONVERT(date, @Fecha)";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@Fecha", fecha);
            return conexion.executeReader();
        }
    }
}
