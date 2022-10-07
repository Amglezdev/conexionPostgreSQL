using Npgsql;

namespace proyectoConexionPostgreSQL.Models.DTOs.PostgreToDTO
{
    public class PostgreToDto
    {

        public static List<AlumnoDTO> ReaderAListAlumnoDTO(NpgsqlDataReader resultadoConsulta)
        {
            List<AlumnoDTO> listAlumnos = new List<AlumnoDTO>();
            while (resultadoConsulta.Read())
            {
                listAlumnos.Add(new AlumnoDTO(
                    (int)Int64.Parse(resultadoConsulta[0].ToString()), resultadoConsulta[1].ToString(), resultadoConsulta[2].ToString(), resultadoConsulta[3].ToString()));

            }
            return listAlumnos;
        }

        public static List<AsignaturaDTO> ReaderAListAsignaturaDTO(NpgsqlDataReader resultadoConsulta)
        {
            List<AsignaturaDTO> listAsignaturas = new List<AsignaturaDTO>();
            while (resultadoConsulta.Read())
            {
                listAsignaturas.Add(new AsignaturaDTO(
                    (int)Int64.Parse(resultadoConsulta[0].ToString()), resultadoConsulta[1].ToString(), resultadoConsulta[2].ToString()));

            }
            return listAsignaturas;
        }

        public static List<alumnoHasAsignaturaDTO> ReaderAListAhaDTO(NpgsqlDataReader resultadoConsulta)
        {
            List<alumnoHasAsignaturaDTO> listAha = new List<alumnoHasAsignaturaDTO>();
            while (resultadoConsulta.Read())
            {
                listAha.Add(new alumnoHasAsignaturaDTO(
                    (int)Int64.Parse(resultadoConsulta[0].ToString()), Int32.Parse(resultadoConsulta[1].ToString()), Int32.Parse(resultadoConsulta[2].ToString())));

            }
            return listAha;
        }

    }


}

