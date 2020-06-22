using GLtech.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Text;
using System.Threading.Tasks;

namespace admin_basic.Controllers
{
    public class ProductController : Controller
    {
        private readonly db_e db = new db_e();
        public IActionResult Product1()
        {
            return View();
        }
        public IActionResult Product2()
        {
            return View();
        }
        public IActionResult Product1_2()
        {
            return View();
        }
        public IActionResult Product1_3()
        {
            return View();
        }
        public IActionResult Product1_4()
        {
            return View();
        }
        public IActionResult Product1_5()
        {
            return View();
        }
        public IActionResult Product1_6()
        {
            return View();
        }

        //일일보고서
        public IActionResult popup(Downloader doc, int? idx)
        {

            return View(doc);
        }

        public async Task<ActionResult> popup_action(Downloader doc, int? idx)
        {
            var sb = new StringBuilder();

            if (idx == null)
            {

                #region 저장

                doc.write_date = DateTime.Now;
                db.Downloader.Add(doc);
                await db.SaveChangesAsync();

                #endregion
                sb.AppendFormat("<meta http-equiv = 'Content-Type' content = 'text/html; charset = utf-8' />");
                sb.AppendFormat("<script src = '/Content/assets/js/jquery.min.js' ></script >");
                sb.AppendFormat("<script>");
                sb.AppendFormat("alert('완료되었습니다.');");
                sb.AppendFormat("self.close();");
                sb.AppendFormat("</script>");

                await Response.WriteAsync(sb.ToString());

            }


            return null;
        }

    }
}