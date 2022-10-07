namespace proyectoConexionPostgreSQL.Models.Queries
{
    using Npgsql;
    using proyectoConexionPostgreSQL.Models.DTOs;
    using System.Text.RegularExpressions;

    /*
     * QueriesSelect -> Clase que nos permite ejecutar diferentes queries de select para la base de datos 'alumnos'
     */
    public class QueriesSelect
    {


        //Ejecutamos un SELECT * FROM alumnos

        /*
            * SELECT al.\"idAlumno\", al.\"nombre\", count(aha.\"idAsignatura\") 
               FROM \"pruebasConexion\".alumnos as al 
               JOIN \"pruebasConexion\".alumn_has_asignaturas  as aha ON aha.\"idAlumno\" = al.\"idAlumno\"
               WHERE al.\"idAlumno\" = 3 
               GROUP BY al.\"idAlumno\"

            */
        public static List<AlumnoDTO> ConsultaSelectAll(NpgsqlConnection conexionGenerada)
        {
            List<AlumnoDTO> listAlumnos = new List<AlumnoDTO>();
            try
            {
                //Se define y ejecuta la consulta Select
                NpgsqlCommand consulta = new NpgsqlCommand("SELECT * FROM \"pruebasConexion\".\"alumnos\"", conexionGenerada);
                NpgsqlDataReader resultadoConsulta = consulta.ExecuteReader();

                //Paso de DataReader a lista de alumnoDTO
                listAlumnos = DTOs.PostgreToDTO.PostgreToDto.ReaderAListAlumnoDTO(resultadoConsulta);
                int cont = listAlumnos.Count();
                //System.Console.WriteLine("[INFORMACIÓN-ConsultasPostgreSQL-ConsultaSelectPostgreSQL] Lista compuesta por: " + cont + " alumnos");

                //System.Console.WriteLine("[INFORMACIÓN-ConsultasPostgreSQL-ConsultaSelectPostgreSQL] Cierre conexión y conjunto de datos");
                conexionGenerada.Close();
                resultadoConsulta.Close();

            }
            catch (Exception e)
            {

                System.Console.WriteLine("[ERROR-HomeController-Index] Error al ejecutar consulta: " + e);
                conexionGenerada.Close();

            }
            return listAlumnos;
        }
        public static List<AsignaturaDTO> ConsultaSelecAsignatura(NpgsqlConnection conexionGenerada)
        {
            List<AsignaturaDTO> listAsignatura = new List<AsignaturaDTO>();
            try
            {
                //Se define y ejecuta la consulta Select
                conexionGenerada.Open();
                NpgsqlCommand consulta = new NpgsqlCommand("SELECT * FROM \"pruebasConexion\".\"asignaturas\"", conexionGenerada);
                NpgsqlDataReader resultadoConsulta = consulta.ExecuteReader();

                //Paso de DataReader a lista de alumnoDTO
                listAsignatura = DTOs.PostgreToDTO.PostgreToDto.ReaderAListAsignaturaDTO(resultadoConsulta);
                int cont = listAsignatura.Count();
                System.Console.WriteLine("[INFORMACIÓN-ConsultasPostgreSQL-ConsultaSelectPostgreSQL] Lista compuesta por: " + cont + " asignaturas");

                System.Console.WriteLine("[INFORMACIÓN-ConsultasPostgreSQL-ConsultaSelectPostgreSQL] Cierre conexión y conjunto de datos");
                conexionGenerada.Close();
                resultadoConsulta.Close();

            }
            catch (Exception e)
            {

                System.Console.WriteLine("[ERROR-HomeController-Index] Error al ejecutar consulta: " + e);
                conexionGenerada.Close();

            }
            return listAsignatura;
        }

        public static List<alumnoHasAsignaturaDTO> ConsultaSelectAha(NpgsqlConnection conexionGenerada)
        {
            List<alumnoHasAsignaturaDTO> listAha = new List<alumnoHasAsignaturaDTO>();
            try
            {
                //Se define y ejecuta la consulta Select
                conexionGenerada.Open();
                NpgsqlCommand consulta = new NpgsqlCommand("SELECT * FROM \"pruebasConexion\".\"alumn_has_asignaturas\"", conexionGenerada);
                NpgsqlDataReader resultadoConsulta = consulta.ExecuteReader();

                //Paso de DataReader a lista de alumnoDTO
                listAha = DTOs.PostgreToDTO.PostgreToDto.ReaderAListAhaDTO(resultadoConsulta);
                int cont = listAha.Count();
                System.Console.WriteLine("[INFORMACIÓN-ConsultasPostgreSQL-ConsultaSelectPostgreSQL] Lista compuesta por: " + cont + " alumnos");

                System.Console.WriteLine("[INFORMACIÓN-ConsultasPostgreSQL-ConsultaSelectPostgreSQL] Cierre conexión y conjunto de datos");
                conexionGenerada.Close();
                resultadoConsulta.Close();

            }
            catch (Exception e)
            {

                System.Console.WriteLine("[ERROR-HomeController-Index] Error al ejecutar consulta: " + e);
                conexionGenerada.Close();

            }
            return listAha;
        }

       


    }



}

