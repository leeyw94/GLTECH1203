using Microsoft.AspNetCore.Mvc;

namespace admin_basic.Controllers
{
    public class NewsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}