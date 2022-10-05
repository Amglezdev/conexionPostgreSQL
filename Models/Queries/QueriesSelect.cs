namespace proyectoConexionPostgreSQL.Models.Queries
{
    using Npgsql;
    /*
     * QueriesSelect -> Clase que nos permite ejecutar diferentes queries de select para la base de datos 'alumnos'
     */
    public class QueriesSelect
    {
        NpgsqlCommand execute = null;


        //Ejecutamos un SELECT * FROM alumnos
        public static NpgsqlDataReader SelectEverything(NpgsqlConnection conn)
        {
            conn.Open();
            NpgsqlCommand querie = new NpgsqlCommand();
            NpgsqlDataReader result = null;

            try
            {
                querie = new NpgsqlCommand("SELECT * FROM \"basicDatabase\".\"alumnos\"", conn);
                result = querie.ExecuteReader();
            }
            catch (Exception e)
            {
                Console.WriteLine("[INFO -ERROR- SelectEverything]" + e.Message);
                conn.Close();
            }
            return result;

        }

        //Ejecutamos un select que nos devuelve todos los nombres y apellidos de los alumnos
        public static NpgsqlDataReader SelectNameAndSurname(NpgsqlConnection conn)
        {
            NpgsqlCommand querie = new NpgsqlCommand();
            NpgsqlDataReader result = null;

            try
            {
                querie = new NpgsqlCommand("SELECT nombre, appelidos FROM \"basicDatabase\".\"alumnos\"", conn);
                result = querie.ExecuteReader();
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

