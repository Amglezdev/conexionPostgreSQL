namespace proyectoConexionPostgreSQL.Models.Connections
{
    using Npgsql;
    public class ConnectionPostgreSQL
    {
        /*
         * ConnectionPostgreSQL -> Clase con la que creamos la conexion con la base de datos de PostgreSQL, basandonos en la informacion ubicada en el fichero util.VariablesConexion
         */

        public static NpgsqlConnection PostgreSQLConnection(string host, int port, string user, string pass, string db)
        {
            Console.WriteLine("[INFO-Crear Conexion] Entrando en la conexion");

            //Creamos la conexion y el string con los datos

            NpgsqlConnection conn = new NpgsqlConnection();
            string datosConexion = "Server=" + host + "; Port=" + port + "; User Id=" + user + "; Password=" + pass + "; Database=" + db;
            Console.WriteLine(datosConexion);

            //Comprobamos que el string de conexion se ha creado correctamente 
            if (string.IsNullOrWhiteSpace(datosConexion))
            {
                try
                {
                    conn = new NpgsqlConnection(datosConexion);
                    conn.Open();
                    Console.WriteLine("[INFO -- Conexion creada correctamente]");
                    Console.WriteLine("[INFO -- PARAMETROS DE CONEXION \t]" + datosConexion);

                }
                catch (Exception e)
                {
                    Console.WriteLine("[INFO- Error en la conexion]" + e.Message);
                    conn.Close();
                }

            }

            return conn;

        }
    }
}
