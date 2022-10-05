using Microsoft.AspNetCore.Mvc;
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

        public IActionResult Index()
        {

            //Importamos las constantes de inicio de sesion
            const string HOST = Util.VariablesConexion.HOST;
            const string PASS = Util.VariablesConexion.PASS;
            const int PORT = Util.VariablesConexion.PORT;
            const string DB = Util.VariablesConexion.DB;
            const string USER = Util.VariablesConexion.USER;

            Console.WriteLine("[INFO -- Creando Conexion]");

            //Creamos la conexion con la base de datos
            NpgsqlConnection conn = ConnectionPostgreSQL.PostgreSQLConnection(HOST, PORT, USER, PASS, DB);           
            

            //Realizamos un select para probar que funcione

            try
            {
                NpgsqlDataReader sqlDataReader = QueriesSelect.SelectEverything(conn);                
                while (sqlDataReader.Read())
                {
                   
                    Console.WriteLine("[RESULTADOS] \n {0}\t{1}\t{2}\t{3}\t{4}\n", sqlDataReader[0], sqlDataReader[1], sqlDataReader[2], sqlDataReader[3], sqlDataReader[4]);
                }
            } catch (Exception e)
            {
                Console.WriteLine("[INFO -- ERROR: Problemas en la consulta a la base de datos]" + e.Message);
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
    }
}