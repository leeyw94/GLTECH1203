using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GLtech.Models;
using Newtonsoft.Json;
using System.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Headers;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using LazZiya.ImageResize;
using System.IO;
using admin_basic.Util;
using ReflectionIT.Mvc.Paging;
using Microsoft.AspNetCore.Routing;

namespace admin_basic.Controllers
{
    public class SysController : Controller
    {
        // GET: Sys
        private readonly db_e db = new db_e();

        #region 첨부파일 변수
        private IHttpContextAccessor _accessor;
        // public static string company_id = "GoodDesign";
        private readonly long _fileSizeLimit;
        private readonly string[] _permittedExtensions = { ".txt", ".pdf", ".jpg", ".png", ".zip", ".gif", ".jpeg", ".hwp" };
        private readonly string _targetFilePath;
        public static IConfigurationRoot Configuration { get; set; }
        public SysController(IConfiguration config)
        {
            _fileSizeLimit = config.GetValue<long>("FileSizeLimit");

            // To save physical files to a path provided by configuration:
            _targetFilePath = config.GetValue<string>("StoredFilesPath");

            // To save physical files to the temporary files folder, use:
            //_targetFilePath = Path.GetTempPath();
        } 
        #endregion

        /// <summary>
        /// / 로그인 정보
        // / </summary>
        public class UserData
        {
            public static string user_get(string user_id, string what)
            {

                db_e db = new db_e();
               
                string company_id = "BlueEye";
                string company_name = "BlueEye";
                string user_name = "";
                int department_idx = 0;
                int company_idx = 0;
                string department_name = "";
                int auth = 0; //초기 :0
                string user_auth = "";
                string position_idx = "0";

                //var _list = (from a in db.user.Include(p=>p.company_idxNavigation).Include(p=>p.department_idxNavigation) where a.user_id == user_id select a).Single();             

                //if (_list != null)
                //{
                //    company_id = _list.company_idxNavigation.company_id;
                //    company_name = _list.company_idxNavigation.company_name;
                //    company_idx = _list.company_idxNavigation.idx;
                //    department_name = _list.department_idxNavigation.department_name;
                //    user_name = _list.user_name;
                //    department_idx = _list.department_idx;
                //    auth = _list.check_auth; //최고 권한 관리자 :9 , 회사별 권한 관리자 : 8 , 부서장 : 7
                //    user_auth = _list.user_auth; //페이지 권한 
                //}

                string str = "";

                if (what == "user_id")
                {
                    str = user_id;
                }
                else if (what == "user_name")
                {
                    str = user_name;
                }
                else if (what == "company_id")
                {
                    str = company_id;
                }
                else if (what == "company_idx")
                {
                    str = company_idx.ToString();
                }
                else if (what == "company_name")
                {
                    str = company_name;
                }
                else    if (what == "department_idx")
                {
                    str = department_idx.ToString();
                }
                else if (what == "department_name")
                {
                    str = department_name;
                }
                else if (what == "auth")
                {
                    str = auth.ToString();
                }
                else if (what == "user_auth")
                {
                    str = user_auth.ToString();
                }

                return str;

            }

            public void History_write(string user_id, string _page, string _state)
            {
                db_e db = new db_e();

                string user_name = UserData.user_get(user_id, "user_name");
                string department_id = UserData.user_get(user_id, "department_id");
                string department_name = UserData.user_get(user_id, "department_name");
                string company_id = UserData.user_get(user_id, "company_id");
                string company_name = UserData.user_get(user_id, "company_name");
                string auth = UserData.user_get(user_id, "auth");

                var _insert = new history
                {
                    user_id = user_id,
                    company_id = company_id,
                    department_id = department_id,
                    user_ip = "",
                    pre_page = "",
                    connect_agent = company_name,
                    connect_host = auth,
                    connect_path = user_name,
                    memo = department_name,
                    connect_date = DateTime.Now,
                    state = _state,
                    page = _page
                };

                db.history.Add(_insert);
                db.SaveChanges(); // 실제로 저장 


            }
        }


        public void ResizeImage(string _path, IFormFile uploadedFile, string file_name, int desiredWidth, int desiredHeight)
        {
            string webroot = _path;
            try
            {
                if (uploadedFile.Length > 0)
                {
                    using (var stream = uploadedFile.OpenReadStream())
                    {
                        var uploadedImage = System.Drawing.Image.FromStream(stream);

                        //decide how to scale dimensions
                        if (desiredHeight == 0 && desiredWidth > 0)
                        {
                            var img = ImageResize.ScaleByWidth(uploadedImage, desiredWidth); // returns System.Drawing.Image file
                            img.SaveAs(Path.Combine(webroot, file_name));
                        }
                        else if (desiredWidth == 0 && desiredHeight > 0)
                        {
                            var img = ImageResize.ScaleByHeight(uploadedImage, desiredHeight); // returns System.Drawing.Image file
                            img.SaveAs(Path.Combine(webroot, file_name));
                        }
                        else
                        {
                            var img = ImageResize.Scale(uploadedImage, desiredWidth, desiredHeight); // returns System.Drawing.Image file
                            img.SaveAs(Path.Combine(webroot, file_name));
                        }
                    }
                }
            }
            catch { }
            return;
        }
                
    }
}