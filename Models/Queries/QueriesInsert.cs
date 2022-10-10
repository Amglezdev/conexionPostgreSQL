namespace proyectoConexionPostgreSQL.Models.Queries
{
    using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
    using Npgsql;
    /*
     * QueriesInsert -> Clase que nos permite ejecutar diferentes queries para insertar datos en la base de datos 'alumnos'
     */
    public class QueriesInsert
    {


        public static void InsertAlumno(NpgsqlConnection conn)
        {
            conn.Open();
            // string sql = "Insert into \"pruebasConexion\".\"alumnos\" (id, nombre, email, direccion) VALUES (@id, @nombre, @email, @direccion);";
            string sql = "Insert into \"pruebasConexion\".\"alumnos\" VALUES (DEFAULT, \'testC#\', \'testC#\', \'testC#\');";
            try
            {
                NpgsqlCommand cmd = new NpgsqlCommand(sql, conn);
                //cmd.Parameters.AddWithValue("id", "Default");
                //cmd.Parameters.AddWithValue("nombre", "TestC#");
                //cmd.Parameters.AddWithValue("email", "TestC#");
                //cmd.Parameters.AddWithValue("direccion", "TestC#");
                Console.WriteLine("[INFO-- modelos.Queries.QueriesInsert.InsertAlumno] Creando alumno");
                cmd.ExecuteNonQuery();
                Console.WriteLine("[INFO-- modelos.Queries.QueriesInsert.InsertAlumno] Alumno creado");


            }
            catch (Exception e)
            {
                // TODO: handle exception
                Console.WriteLine("INFO-- modelos.consultas.ConsultasInsert.InsertAlumno] Error al insertar alumno" + e.Message);
            }
            conn.Close();





        }

    }
}
