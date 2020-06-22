using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GLtech.Models;
using System.Text;
using System.Globalization;
using Microsoft.AspNetCore.Http;

namespace admin_basic.Controllers
{
    public class ContactController : Controller
    {
        private readonly db_e db = new db_e();
        public IActionResult Inquiry(Inquiry doc, int? idx)
        {
            if (idx != null)
            {
                doc = db.Inquiry.Single(p => p.idx == idx);
            }
            return View();
        }

        public async Task<IActionResult> Inquiry_action(Inquiry doc, int? idx)
        {

            if (idx == null)
            {
                #region 저장
                doc.writeDate = DateTime.Now;
                db.Inquiry.Add(doc);
                await db.SaveChangesAsync();

                #endregion
            }
            

            return Redirect("/Contact/Inquiry");
        }
        public IActionResult Agency()
        {
            return View();
        }
        public IActionResult Data()
        {
            return View();
        }
    }
}