using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
//using WebApplication1.Models;
using GLtech.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using admin_basic.Util;

namespace admin_basic.Controllers
{
    public class HomeController : Controller
    {
        
        private readonly ILogger<HomeController> _logger;
        private readonly db_e db = new db_e();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            //공지사항
            var notice = (from a in db.BoardList where a.BM_idx == 1 && a.useable == "Y" && a.main_yn == "Y" select a).OrderByDescending(p => p.idx).ToList();
            //전시회
            var fair = (from a in db.BoardList where a.BM_idx == 3 && a.useable == "Y" && a.main_yn == "Y" select a).OrderByDescending(p => p.idx).ToList(); 

            ViewBag.공지사항 = notice;
            ViewBag.전시회 = fair;
            return View();
        }

        public IActionResult Index1()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Disable()
        {
            return View();
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
