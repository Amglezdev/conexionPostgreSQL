﻿namespace proyectoConexionPostgreSQL.Models.Queries
{
    using Npgsql;
    /*
     * QueriesSelect -> Clase que nos permite ejecutar diferentes queries de select para la base de datos 'alumnos'
     */
    public class QueriesSelect
    {


        //Ejecutamos un SELECT * FROM alumnos
        public static NpgsqlDataReader SelectEverything(NpgsqlConnection conn)
        {

            NpgsqlCommand querie = new NpgsqlCommand();
            NpgsqlDataReader result = querie.ExecuteReader();
            try
            {
                conn.Open();
                querie = new NpgsqlCommand("SELECT * FROM \"basicDatabase\".\"alumnos\"", conn);
                result = querie.ExecuteReader();
                Console.WriteLine("[RESULTADOS] \n {0}\t{1}\t{2}\t{3}\t{4}\n", result[0], result[1], result[2], result[3], result[4]);
                return result;
                
               
            }
            catch (Exception e)
            {
                Console.WriteLine("[INFO -ERROR- SelectEverything]" + e.Message);
                conn.Close();
                return result;
            }
            return result;

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

