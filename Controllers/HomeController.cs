using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Npgsql;
using Npgsql.Internal;
using proyectoConexionPostgreSQL.Models;
using proyectoConexionPostgreSQL.Models.Connections;
using proyectoConexionPostgreSQL.Models.Queries;
using System.Diagnostics;

namespace proyectoConexionPostgreSQL.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //public IActionResult Index(ConnectionPostgreSQL conexionPostgreSQL)
        //{
        //    System.Console.WriteLine("[INFORMACIÓN-HomeController-Index] Entra en Index");

        //    //CONSTANTES
        //    const string HOST = Util.VariablesConexion.HOST;
        //    const int PORT = Util.VariablesConexion.PORT;
        //    const string USER = Util.VariablesConexion.USER;
        //    const string PASS = Util.VariablesConexion.PASS;
        //    const string DB = Util.VariablesConexion.DB;

        //    //Se genera una conexión a PostgreSQL y validamos que esté abierta fuera del método
        //    var estadoGenerada = "";
        //    NpgsqlConnection conexionGenerada = new NpgsqlConnection();
        //    NpgsqlCommand consulta = new NpgsqlCommand();
        //    conexionGenerada = ConnectionPostgreSQL.PostgreSQLConnection(HOST, PORT, DB, USER, PASS);
        //    estadoGenerada = conexionGenerada.State.ToString();
        //    System.Console.WriteLine("[INFORMACIÓN-HomeController-Index] Estado conexión generada: " + estadoGenerada);

        //    //Se define la consulta a realizar y se guarda el resultado
        //    try
        //    {

        //        consulta = new NpgsqlCommand("SELECT * FROM \"proyectoEclipse\".\"alumnos\"", conexionGenerada);
        //        NpgsqlDataReader resultadoConsulta = consulta.ExecuteReader();
        //        while (resultadoConsulta.Read())
        //        {

        //            Console.Write("{0}\t{1}\t{2}\t{3} \n",
        //                resultadoConsulta[0], resultadoConsulta[1], resultadoConsulta[2], resultadoConsulta[3]);

        //        }

        //        System.Console.WriteLine("[INFORMACIÓN-HomeController-Index] Cierre conexión y conjunto de datos");
        //        conexionGenerada.Close();
        //        resultadoConsulta.Close();

        //    }
        //    catch (Exception e)
        //    {

        //        System.Console.WriteLine("[INFORMACIÓN-HomeController-Index] Error al ejecutar consulta: " + e);
        //        conexionGenerada.Close();

        //    }

        //    return View();
        //}

        public IActionResult Index()
        {
            /*
             * SELECT al.\"idAlumno\", al.nombre, count(aha.\"idAsignatura\") 
                FROM \"pruebasConexion"\.alumnos as al 
                JOIN \"pruebasConexion"\.alumn_has_asignaturas  as aha ON aha."idAlumno" = al."idAlumno"
                WHERE al."idAlumno" = 3 
                GROUP BY al."idAlumno"

             */
            //Importamos las constantes de inicio de sesion
            const string HOST = Util.VariablesConexion.HOST;
            const string PASS = Util.VariablesConexion.PASS;
            const int PORT = Util.VariablesConexion.PORT;
            const string DB = Util.VariablesConexion.DB;
            const string USER = Util.VariablesConexion.USER;

            Console.WriteLine("[INFO -- Creando Conexion]");

            //Creamos la conexion con la base de datos
            NpgsqlConnection conn = ConnectionPostgreSQL.PostgreSQLConnection(HOST, PORT, USER, PASS, DB);
            Console.WriteLine("[INFO -- Comprobando estado de conexion] \t" + conn.State.ToString());
            //Realizamos un select para probar que funcione


            ////TODO: Must fix exceptions taking place in this block
            try
            {
                NpgsqlDataReader sqlDataReader = QueriesSelect.SelectEverything(conn);
                while (sqlDataReader.Read())
                {
                    Console.WriteLine("[RESULTADOS] \n {0}\t{1}\t{2}\t{3}\t{4}\n", sqlDataReader[0], sqlDataReader[1], sqlDataReader[2], sqlDataReader[3], sqlDataReader[4]);
                }
            }
            catch
            {

            }





            return View();
        }



        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public static void TestVistas()
        {
            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine("Test de vistas");

            }


        }
    }
}