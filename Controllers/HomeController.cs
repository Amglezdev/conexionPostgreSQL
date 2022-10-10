using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Hosting;
using Npgsql;
using Npgsql.Internal;
using proyectoConexionPostgreSQL.Models;
using proyectoConexionPostgreSQL.Models.Connections;
using proyectoConexionPostgreSQL.Models.DTOs;
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
            Console.WriteLine("[INFO -- Comprobando estado de conexion] \t" + conn.State.ToString());
            //Realizamos un select para probar que funcione


            ////TODO: Must fix exceptions taking place in this block
            try
            {
                //Almacenamos los resultados en listas para despues mostrarlos
                List<AlumnoDTO> listAl = QueriesSelect.ConsultaSelectAll(conn);
                List<AsignaturaDTO> listAs = QueriesSelect.ConsultaSelecAsignatura(conn);
                List<alumnoHasAsignaturaDTO> listAha = QueriesSelect.ConsultaSelectAha(conn);


                //Mostramos los resultados de las queries
                foreach (AlumnoDTO al in listAl)
                {
                    Console.WriteLine(al.ToString());
                }
                foreach (AsignaturaDTO a in listAs)
                {
                    Console.WriteLine(a.ToString());
                }

                foreach (alumnoHasAsignaturaDTO b in listAha)
                {
                    Console.WriteLine(b.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("[INFO -- Controllers.HomeController.Index -- ] " + e.Message);
            }

            QueriesInsert.InsertAlumno(conn);

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
