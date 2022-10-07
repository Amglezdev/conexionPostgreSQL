namespace proyectoConexionPostgreSQL.Models.Queries
{
    using Npgsql;
    /*
     * QueriesSelect -> Clase que nos permite ejecutar diferentes queries de select para la base de datos 'alumnos'
     */
    public class QueriesSelect
    {


        //Ejecutamos un SELECT * FROM alumnos
        public static List<AlumnoDTO> ConsultaSelectPostgreSQL(NpgsqlConnection conexionGenerada)
        {
            List<AlumnoDTO> listAlumnos = new List<AlumnoDTO>();
            try
            {
                //Se define y ejecuta la consulta Select
                NpgsqlCommand consulta = new NpgsqlCommand("SELECT * FROM \"proyectoEclipse\".\"alumnos\"", conexionGenerada);
                NpgsqlDataReader resultadoConsulta = consulta.ExecuteReader();

                //Paso de DataReader a lista de alumnoDTO
                listAlumnos = DTOs.ADTO.ReaderAListDTO.ReaderAListAlumnoDTO(resultadoConsulta);
                int cont = listAlumnos.Count();
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
            return listAlumnos;
        }

        //Ejecutamos un select que nos devuelve todos los nombres y apellidos de los alumnos
        public static NpgsqlDataReader SelectNameAndSurname(NpgsqlConnection conn)
        {
            NpgsqlCommand querie = new NpgsqlCommand();
            NpgsqlDataReader result = querie.ExecuteReader();

            try
            {

                querie = new NpgsqlCommand("SELECT nombre, appelidos FROM \"basicDatabase\".\"alumnos\"", conn);
                result = querie.ExecuteReader();
                conn.Close();
            }
            catch (Exception e)
            {
                Console.WriteLine("[INFO -ERROR- SelectEverything]" + e.Message);
                conn.Close();
            }
            return result;

        }


    }



}

