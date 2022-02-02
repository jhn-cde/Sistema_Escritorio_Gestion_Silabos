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
    public class D_Asistencia
    {
        Conexion conexion = new Conexion();
        protected Conexion aConexion;
        // Metodos CRUD
        public bool Agregar(E_Asistencia pAsistencia)
        {
            string sql = "INSERT INTO dbo.TAsistencia (ID_Registro, CodAlumno, Asistio)" +
                                    "VALUES (@ID_Registro, @CodAlumno, @Asistio)";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@ID_Registro", pAsistencia.ID_Registro);
            conexion.cmd.Parameters.AddWithValue("@CodAlumno", pAsistencia.CodAlumno);
            conexion.cmd.Parameters.AddWithValue("@Asistio", pAsistencia.Asistio);

            return conexion.executeNonQuery() == 1;
        }
        // Mostrar por Fecha y Asignacion
        public DataTable MostrarFechaAsignacion(DateTime Fecha, int AsignacionID)
        {
            string sql = "SELECT A.CodAlumno, Nombres, Asistio " +
                "FROM((TAlumno AL INNER JOIN TAsistencia A ON AL.CodAlumno = A.CodAlumno) " +
                "INNER JOIN TRegistroAvance R ON A.ID_Registro = R.ID) " +
                "INNER JOIN TSilabo S ON R.ID_Silabo = S.ID " +
                "WHERE Fecha = @Fecha AND Asignacion = @Asignacion";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@Fecha", Fecha);
            conexion.cmd.Parameters.AddWithValue("@Asignacion", AsignacionID);
            return conexion.executeReader();
        }
        // Buscar por Nombre y CodigoAlumno
        public DataTable Buscar(int AsignacionID, String Texto)
        {
            string sql = "SELECT A.CodAlumno, Nombres, Asistio " +
                "FROM((TAlumno AL INNER JOIN TAsistencia A ON AL.CodAlumno = A.CodAlumno) " +
                "INNER JOIN TRegistroAvance R ON A.ID_Registro = R.ID) " +
                "INNER JOIN TSilabo S ON R.ID_Silabo = S.ID " +
                "WHERE Asignacion = @Asignacion AND (A.CodAlumno LIKE (@Texto + '%') " +
                "OR Nombres LIKE (@Texto + '%'))";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@Asignacion", AsignacionID);
            conexion.cmd.Parameters.AddWithValue("@Texto", Texto);

            return conexion.executeReader();
        }
        public bool Editar(E_Asistencia pAsistencia)
        {
            string sql = "UPDATE dbo.TAsistencia SET Asistio = @Asistio WHERE ID = @ID";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@ID", pAsistencia.ID);
            conexion.cmd.Parameters.AddWithValue("@Asistio", pAsistencia.Asistio);
            return conexion.executeNonQuery() == 1;
        }
        public bool Eliminar(string ID)
        {
            string sql = "DELETE FROM TAsistencia WHERE ID = @ID";
            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@ID", ID);

            return conexion.executeNonQuery() == 1;
        }
        public DataTable Reporte(int AsignacionID)
        {
            string sql = "DECLARE @cols AS NVARCHAR(MAX), @query  AS NVARCHAR(MAX) " +
"select @cols = STUFF((SELECT distinct ',' + QUOTENAME(a.Fecha) from (select m.CodAlumno,n.Asistio, n.Fecha from " +
" (select TAA.NRO,TAA.CodAlumno, count(nullif(TAA.Asistio, 0)) as Asistencias, count(nullif(TAA.Asistio, 1)) as Faltas " +
"	from (select TA.ID_Registro, TA.CodAlumno, TA.Asistio, TAC.NRO from TAsistencia TA inner join TAlumnoCurso TAC on TA.CodAlumno = TAC.CodAlumno) TAA inner join " +
"		(select TRA.Fecha, TRA.ID " +
"			from TRegistroAvance TRA inner join TSilabo TS on TRA.ID_Silabo = TS.ID " +
"			where TS.Asignacion = @Asignacion) TRAS " +
"		on TAA.ID_Registro = TRAS.ID " +
"		Group by TAA.CodAlumno, TAA.NRO) m inner join " +
"(select TAL.Nombres, TAL.CodAlumno, CAST(TF.Asistio as int) as Asistio, TF.Fecha  " +
"							from TAlumno TAL inner join " +
"							(select TA.Asistio, TA.CodAlumno, TRA.Fecha " +
"								from TAsistencia TA inner join TRegistroAvance TRA on TA.ID_Registro = TRA.ID) TF on TAL.CodAlumno = TF.CodAlumno) n " +
"								on m.CodAlumno = n.CodAlumno) a " +
"            FOR XML PATH(''), TYPE ).value('.', 'NVARCHAR(MAX)') ,1,1,'') " +
"set @query = 'SELECT NRO, CodAlumno, Nombres, Asistencias, Faltas, ' + @cols + ' from  " +
"             ( select m.NRO, m.CodAlumno, n.Nombres, m.Asistencias, m.Faltas, n.Asistio, n.Fecha from " +
" (select TAA.NRO,TAA.CodAlumno, count(nullif(TAA.Asistio, 0)) as Asistencias, count(nullif(TAA.Asistio, 1)) as Faltas " +
"	from (select TA.ID_Registro, TA.CodAlumno, TA.Asistio, TAC.NRO from TAsistencia TA inner join TAlumnoCurso TAC on TA.CodAlumno = TAC.CodAlumno) TAA inner join " +
"		(select TRA.Fecha, TRA.ID " +
"			from TRegistroAvance TRA inner join TSilabo TS on TRA.ID_Silabo = TS.ID " +
"			where TS.Asignacion = '+@Asignacion+') TRAS " +
"		on TAA.ID_Registro = TRAS.ID " +
"		Group by TAA.CodAlumno, TAA.NRO) m inner join " +
"(select TAL.Nombres, TAL.CodAlumno, CAST(TF.Asistio as int) as Asistio, TF.Fecha  " +
"							from TAlumno TAL inner join " +
"							(select TA.Asistio, TA.CodAlumno, TRA.Fecha " +
"								from TAsistencia TA inner join TRegistroAvance TRA on TA.ID_Registro = TRA.ID) TF on TAL.CodAlumno = TF.CodAlumno) n " +
"								on m.CodAlumno = n.CodAlumno ) x " +
"								pivot  ( sum(Asistio) for Fecha in (' + @cols + ') ) p ' " +
"execute(@query) ";

            conexion.setComando(sql);
            conexion.cmd.Parameters.AddWithValue("@Asignacion", AsignacionID.ToString());

            return conexion.executeReader();
        }
    }
}
