using Microsoft.AspNetCore.Mvc;

namespace Dr_Sillystringz_s_Factory.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
