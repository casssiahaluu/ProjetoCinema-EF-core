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
        public IActionResult CreateSala(Sala sala)
        {
            try{
                if(ModelState.IsValid && sala != null){
                    ctx.Salas.Add(sala);
                    ctx.SaveChanges();
                }
            }
            catch (DbUpdateException /* ex */)
            {
                ModelState.AddModelError("", "Impossível salvar. " +
                "Tente novamente, se o problema persistir, " +
                "contate o administrador.");
            }
            return View("CreateSala");
        }
        public IActionResult ViewSala()
        {
            var sala = ctx.Salas.Include(c => c.Exibicoes);
            return View(sala);
        }
    }
}
