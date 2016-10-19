using System.Collections.Generic;
using System.Linq;
using Cinema.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Cinema.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext ctx = new ApplicationDbContext(); 
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        /* ===#### TODO: Controllers ####=== */
        public IActionResult CreateSala(){
            var sala = new Sala{
                Nome="Sala 01",
                Capacidade=2,
                TamanhoTela=100
            };
            ctx.Salas.Add(sala);
            ctx.SaveChanges();

            var exibicoes = new List<string>{
                "Exibição 01", "Exibição 02", "Exibição 03" 
            };

            foreach (var exib in exibicoes)
            {
                var exibicao = new Exibicao{
                    Sala=sala,
                    Data="16/10/2016",
                    Horario="14:00"
                };
                ctx.Exibicoes.Add(exibicao);
                ctx.SaveChanges();
            }

            return RedirectToAction("ViewSala");
        }
        public IActionResult ViewSala(){
            var sala = ctx.Salas.Include(c => c.Exibicoes).First();
            return View(sala);
        }
    }
}
