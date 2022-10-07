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
                    (int)Int64.Parse(resultadoConsulta[0].ToString()),
                    resultadoConsulta[1].ToString(),
                    resultadoConsulta[2].ToString(),
                    resultadoConsulta[3].ToString()
                    )
                    );

            }
            return listAlumnos;
        }
    }


}

