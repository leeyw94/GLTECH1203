using Microsoft.AspNetCore.Mvc;

namespace admin_basic.Controllers
{
    public class CompanyController : Controller
    {
        public IActionResult Greetings()
        {
            return View();
        }

        public IActionResult History()
        {
            return View();
        }

        public IActionResult Patents()
        {
            return View();
        }
        public IActionResult Location()
        {
            return View();
        }
    }
}