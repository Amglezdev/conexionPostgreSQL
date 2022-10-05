using Microsoft.AspNetCore.Mvc;
using Npgsql;
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
            const string HOST = Util.VariablesConexion.HOST;
            const string PASS = Util.VariablesConexion.PASS;
            const int PORT = Util.VariablesConexion.PORT;
            const string DB = Util.VariablesConexion.DB;
            const string USER = Util.VariablesConexion.USER;

            Console.WriteLine("[INFO -- Creando Conexion]");

            NpgsqlConnection conn = ConnectionPostgreSQL.PostgreSQLConnection(HOST, PORT, USER, PASS, DB);
            
            Console.WriteLine(QueriesSelect.SelectEverything(conn)); 

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