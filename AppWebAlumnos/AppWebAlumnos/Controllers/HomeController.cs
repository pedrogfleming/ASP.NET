using Microsoft.AspNetCore.Mvc;

namespace AppWebAlumnos.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
