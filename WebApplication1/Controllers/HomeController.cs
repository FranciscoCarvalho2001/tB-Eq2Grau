using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index(int A, int B,int C )
        {
            //var auxiliar
            double delta = (B * B) - (4 * A * C);
            string x1 = "", x2 = "";

            //validar se há condições para efetuar o cálculo
            if (A != 0)
            {
                if (delta >= 0)
                {
                    // x1= (-b + sqrt(delta))/(2*a)
                    // x2= (-b - sqrt(delta))/(2*a)
                    x1 = (-B + Math.Sqrt(delta) / (2 * A)) + "";
                    x2 = (-B - Math.Sqrt(delta) / (2 * A)) + "";
                }
                else
                {
                    //solução completa
                    x1 = -B / (2 * A) + " + " + Math.Sqrt(-delta) / (2 * A)+ " i";
                    x2 = -B / (2 * A) + " - " + Math.Sqrt(-delta) / (2 * A) + " i";
                }
                //preparar os dados a serem enviados para o browser
                ViewBag.X1 = x1;
                ViewBag.X2 = x2;
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