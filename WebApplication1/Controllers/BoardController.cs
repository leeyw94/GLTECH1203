using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using static admin_basic.Controllers.SysController;
using GLtech.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ReflectionIT.Mvc.Paging;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using admin_basic.Util;
using LazZiya.ImageResize;

namespace SmartFactory.Controllers
{
    public class BoardController : Controller
    {
        private readonly db_e db = new db_e();
        private string Comname = "blueeye";
        // GET: Board

        #region 첨부파일 변수
        private IHttpContextAccessor _accessor;
        // public static string company_id = "GoodDesign";
        private readonly long _fileSizeLimit;
        private readonly string[] _permittedExtensions = { ".txt", ".pdf", ".jpg", ".png", ".zip", ".gif", ".jpeg", ".hwp" };
        private readonly string _targetFilePath;
        public static IConfigurationRoot Configuration { get; set; }
        public BoardController(IConfiguration config)
        {
            _fileSizeLimit = config.GetValue<long>("FileSizeLimit");

            // To save physical files to a path provided by configuration:
            _targetFilePath = config.GetValue<string>("StoredFilesPath");

            // To save physical files to the temporary files folder, use:
            //_targetFilePath = Path.GetTempPath();
        }
        #endregion

        public ActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> Board_List(int? cate,  string search_all_type, string search_all, string sortExpression = "-idx", int page = 1)
        {
            #region 기본 사용자 정보
            string user_id = User.Identity.Name;
            int department_idx = Convert.ToInt32(UserData.user_get(user_id, "department_idx"));
            int company_idx = Convert.ToInt32(UserData.user_get(user_id, "company_idx"));
            int auth = Convert.ToInt32(UserData.user_get(user_id, "auth"));
            #endregion

            #region 변수설정
            ViewBag.search_all_type = search_all_type;
            ViewBag.search_all = search_all;
            ViewBag.카테고리 = cate.ToString();

            var _type = (from a in db.BoardMenu where a.idx == cate select a).FirstOrDefault();

            if (_type != null)
            {
                ViewBag.타입 = _type.BoardType_idx;
                ViewBag.타이틀 = _type.title;
            }
            else
            {
                ViewBag.타입 = 1;
                ViewBag.타이틀 = "";
            }

            if (auth >= 8)
            {
                //게시판 종류 드롭다운==============================================================================================================================================          
                var category =
                    db.BoardMenu.Where(
                        a =>
                        a.company_idx == company_idx && a.open_yn == "Y").Select(
                            a => new { 값 = a.idx, 이름 = a.title });
                ViewBag.category = new SelectList(category.AsEnumerable(), "값", "이름");
                //=====================================================================================================================================================================

            }
            else
            {
                //회사별 데이터 드롭다운==============================================================================================================================================          
                var category =
                    db.BoardMenu.Where(
                        a =>
                        a.company_idx == company_idx && ((a.department_idx == department_idx || a.open_yn == "Y"))).Select(
                             a => new { 값 = a.idx, 이름 = a.title });
                ViewBag.category = new SelectList(category.AsEnumerable(), "값", "이름");
                //=====================================================================================================================================================================
            }

            #endregion

            var query = db.BoardList.AsNoTracking().Where(a => a.useable != "N" && a.BM_idx == cate);
            var model = await PagingList.CreateAsync(query, 10, page, sortExpression, "-idx");

            model.RouteValue = new RouteValueDictionary {
                { "search_all", search_all},
                { "search_all_type", search_all_type}                
            };

            if (!string.IsNullOrEmpty(search_all))
            {
                if (search_all_type == "1")
                {
                    query = query.Where(p => p.title.Contains(search_all) || p.content.Contains(search_all));
                }
                if (search_all_type == "2")
                {
                    query = query.Where(p => p.title.Contains(search_all));
                }
                if (search_all_type == "3")
                {
                    query = query.Where(p => p.writer.StartsWith(search_all));
                }

                 model = await PagingList.CreateAsync(query, 1000, page, sortExpression, "-idx");

                model.RouteValue = new RouteValueDictionary {
                { "search_all", search_all},
                { "search_all_type", search_all_type}

            };

            }

            //권한 시작==============================================================================================
            BoardAuth(null, cate);
            //권한 끝================================================================================================

            return View(model );

        }

        public ActionResult BoardView(int idx, int? cate)
        {         
             if (idx == 0)
            {
                //0번 게시글은 임시글로써, DB에 존재하지 않는 글임
                return NotFound();
            }

            //권한 시작==============================================================================================
             BoardAuth(idx, cate);
            //권한 끝================================================================================================

            BoardList data = db.BoardList.Find(idx);

            #region 파일 가져오기
            //파일 가져오기=====================================================================================================================                    

            var _list = (from a in db.BoardFile where a.Md_id == data.fileId && a.use_yn != "N" select a).OrderByDescending(p => p.id).ToList();

            ViewBag.이미지리스트 = _list;
            ViewBag.이미지리스트카운트 = _list.Count();

            //파일 끝============================================================================================================================ 
            #endregion

            #region 조회수 증가
          
            data.hit = data.hit + 1; ;

            db.SaveChanges(); // 실제로 저장 


            #endregion

            #region 읽은 사용자 저장

            int _readCount = (from a in db.BoardRread where a.board_idx == idx && a.user_id == User.Identity.Name select a.idx).Count();

            if (_readCount == 0)
            {

                var _insert = new BoardRread
                {
                    user_id = User.Identity.Name,
                    user_name = (from a in db.user where a.user_id == User.Identity.Name select a.user_name).FirstOrDefault(),
                    read_date = DateTime.Now,
                    board_idx = idx

                };

                db.BoardRread.Add(_insert);
                db.SaveChanges(); // 실제로 저장 
            }


            var _read = (from a in db.BoardRread where a.board_idx == idx  select a).ToList();

            ViewBag.읽은사람 = _read;

            #endregion

            #region 코멘트 가져오기

            IQueryable <BoardComment> _listComent = Enumerable.Empty<BoardComment>().AsQueryable();

            _listComent = db.BoardComment.Where(p => p.BD_idx == idx && p.use_yn == "Y").OrderByDescending(o => o.idx);

            ViewBag.댓글 = _listComent;
            ViewBag.댓글수 = _listComent.Count();
              #endregion

            return View(data);
        }

        private void BoardAuth(int? idx, int? cate)
        {
            #region 권한

            ViewBag.권한 = "";
            ViewBag.부서 = "";           
            ViewBag.관리자 = "";         
            ViewBag.코멘트 = "N";
            ViewBag.파일 = "N";

            string user_id = "";

            if (cate != null)
            {
                ViewBag.부서 = (from a in db.BoardMenu where a.idx == cate select a.department_idx).FirstOrDefault();
            }
            string board_type = (from a in db.BoardMenu where a.idx == cate select a.BoardType_idxNavigation.gubun).FirstOrDefault();

            foreach (var item in board_type.Split(","))
            {
                if(item == "file")
                {
                    ViewBag.파일 = "Y";
                }
                if (item == "replay")
                {
                    ViewBag.코멘트 = "Y";
                }
            }

            int _auth_department = 0;
            if (User.Identity.IsAuthenticated)
            {
                //로그인 했을 경우

                user_id = User.Identity.Name;

                _auth_department = (from a in db.user where a.user_id == user_id select a.check_auth).FirstOrDefault();

                if (_auth_department >= 9)
                {
                    ViewBag.권한 = "E";
                    ViewBag.관리자 = "Y";

                }

                if (idx != null)
                {
                    string _auth_writer = (from a in db.BoardList where a.idx == idx select a.writer).FirstOrDefault() ?? "";

                    if (user_id == _auth_writer)
                    {
                        ViewBag.권한 = "E";
                    }
                }

                ViewBag.로그인 = "Y";
            }

            else
            {
                ViewBag.타입 = "normal";
                ViewBag.타이틀 = "전체";
                ViewBag.권한 = "";

                //if (ViewBag.부서 == "guest")
                //{
                //    ViewBag.권한 = "G";
                //}
                //else
                //{

                //}
            }

            #endregion
        }

        public ActionResult BoardWrite(BoardList doc,int? idx, int? cate)
        {

            if (idx != null)
            {
                //수정모드
                doc = db.BoardList.Find(idx);

                #region 첨부파일 가져오기
                var _list = (from a in db.BoardFile where a.Md_id == doc.fileId && a.use_yn != "N" select a).OrderByDescending(p => p.id).ToList();
                ViewBag.이미지리스트 = _list;
                ViewBag.이미지리스트카운트 = _list.Count(); 
                #endregion

            }
            else
            {
                ViewBag.이미지리스트 = "";
                ViewBag.이미지리스트카운트 = 0;
            }

            BoardAuth(idx, cate);

            return View(doc);
        }      

        [HttpPost]
        public async Task<IActionResult> Board_action(BoardList doc , int? idx, int cate, string mode_type, List<IFormFile> files)
        {
            string file_id = "";
            string user_id = User.Identity.Name;
            string msg = "";

            if (idx == null)
            {
                msg = "입력";
                file_id =  DateTime.Now.ToShortDateString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();

                #region 저장
                doc.fileId = file_id;
                doc.useable = "Y";
                doc.writeDate = DateTime.Now;
                doc.editDate = DateTime.Now;
                db.BoardList.Add(doc);
                db.SaveChanges(); // 실제로 저장 
              

                #endregion
            }
            else
            {
                int _idx = Convert.ToInt32(idx);

                if (mode_type == "D")
                {
                    #region 삭제

                    msg = "삭제";
                    BoardList _update =
                     (from a in db.BoardList where a.idx == idx select a).Single();

                    _update.useable = "N";
                    _update.delDate = DateTime.Now;
                    
                    db.SaveChanges(); // 실제로 저장 

                    #endregion
                }
                else
                {
                    #region 수정
                    msg = "수정";
                    #region 파일 아이디
                    file_id = doc.fileId;

                    if (string.IsNullOrEmpty(file_id))
                    {

                        file_id = user_id + DateTime.Now.ToShortDateString() + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();

                        doc.fileId = file_id;
                    } 
                    #endregion


                    doc.editDate = DateTime.Now;
                    doc.writeDate = DateTime.Now;
                    db.Entry(doc).State = EntityState.Modified;

                    //idx 제외 업데이트=================================
                    db.Entry(doc).Property("idx").IsModified = false;
                    //==================================================
                    db.SaveChanges();

                  

                    #endregion
                }
            }

            #region 파일 올리기

           
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            Configuration = builder.Build();
            string Models_photo = Configuration["user_app:file_list_url"];
            string company_id = UserData.user_get(user_id, "company_id");


            int s = 1;
            foreach (var formFile in files)
            {
                double file_size = formFile.Length;
                if (file_size < _fileSizeLimit)
                {

                    var formFileContent =
                        await FileHelpers
                            .ProcessFormFile<IFormFile>(
                                formFile, ModelState, _permittedExtensions,
                                _fileSizeLimit);



                    #region 변수
                    // 변수 =========================================================================================================================
                    string only = user_id+ DateTime.Today.ToShortDateString().Replace("-", "") + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
                    //  var trustedFileNameForFileStorage = Path.GetRandomFileName();   //랜덤이름                      

                    string file_ex = ""; // 확장자

                    try { file_ex = Path.GetFileName(formFile.FileName).Split('.').Last(); }
                    catch
                    {

                    }
                    var _fileName = only + "." + file_ex;     // 신규 파일 이름   



                    var _local_path = _targetFilePath + company_id + "/";           // 신규 파일 경로
                    var filePath = Path.Combine(_local_path, _fileName);            // 전체 경로
                    string desiredThumbPath = _local_path + "s/";                   // 작은 이미지 전체 경로

                    string ore_fileName = Path.GetFileName(formFile.FileName); 
                    #endregion




                    //경로에 폴더가 없으면 만들어준다.=============================================
                    var dInfo = new DirectoryInfo(_local_path);
                    var dInfo_s = new DirectoryInfo(desiredThumbPath);
                    if (!dInfo.Exists)
                    {
                        dInfo.Create();
                    }
                    if (!dInfo_s.Exists)
                    {
                        dInfo_s.Create();
                    }
                    //=================================================================================



                    using (var fileStream = System.IO.File.Create(filePath))
                    {
                        await fileStream.WriteAsync(formFileContent);

                    }

                    if (get_word.img_check(file_ex) == "img")
                    {
                        // 세로 기준
                        ResizeImage(desiredThumbPath, formFile, _fileName, 300, 0);
                    }



                    var _insert = new BoardFile()
                    {
                        Md_id = file_id,
                        ImagePath = Models_photo + company_id + "/" + _fileName,
                        fileName = ore_fileName,
                        use_yn = "Y",
                        file_ex = file_ex,
                        file_size = file_size,
                        r_date = DateTime.Now,
                        write_id = user_id,
                        sImagePath = Models_photo + company_id + "/s/" + _fileName,
                    };

                    db.BoardFile.Add(_insert);
                    db.SaveChanges();

                }

                s++;
            }


            #endregion

            //===============================================================================
            UserData history = new UserData();
            history.History_write(User.Identity.Name, "/board/boardwrite/cate=" + cate, msg);
            //==============================================================================

            string returnUrl = "/board/board_list?cate=" + cate;

            return Redirect(returnUrl);

        }

        [HttpPost]
        public async Task<IActionResult> BoardImageUpload(string CKEditorFuncNum, IFormFile upload)
        {

            #region 파일 올리기

            string user_id = User.Identity.Name;
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json");
            Configuration = builder.Build();
            string Models_photo = Configuration["user_app:file_list_url"];
            string company_id = UserData.user_get(user_id, "company_id");




            var formFileContent =
                await FileHelpers
                    .ProcessFormFile<IFormFile>(
                        upload, ModelState, _permittedExtensions,
                        _fileSizeLimit);



            // 변수 =========================================================================================================================
            string only = DateTime.Today.ToShortDateString().Replace("-", "") + DateTime.Now.Hour.ToString() + DateTime.Now.Minute.ToString() + DateTime.Now.Second.ToString() + DateTime.Now.Millisecond.ToString();
                           
            var _fileName = only + Path.GetFileName(upload.FileName);     // 신규 파일 이름                    
            var _local_path = _targetFilePath + company_id + "/";            // 신규 파일 경로
            var filePath = Path.Combine(_local_path, _fileName);            // 전체 경로

            string ImagePath = Models_photo + company_id + "/" + _fileName;
          

          

            //경로에 폴더가 없으면 만들어준다.=============================================
            var dInfo = new DirectoryInfo(_local_path);

            if (!dInfo.Exists)
            {
                dInfo.Create();
            }

            //=================================================================================



            using (var fileStream = System.IO.File.Create(filePath))
            {
                await fileStream.WriteAsync(formFileContent);

            }

          

            var sb = new StringBuilder();
            sb.AppendFormat("<script>");
            sb.AppendFormat("window.parent.CKEDITOR.tools.callFunction('" + CKEditorFuncNum +   "', '" + ImagePath +  "', 'OK'); ");
            sb.AppendFormat("history.go(-1)");
            sb.AppendFormat("</script>");
            await  Response.WriteAsync(sb.ToString());


            #endregion

            return null;

         }

        public ActionResult del_set_check(BoardList doc, int file_idx)
        {

            BoardList _updateContent =
                    (from a in db.BoardList where a.idx == doc.idx select a).Single();

            _updateContent.title = doc.title;
            _updateContent.content = doc.content;
            _updateContent.editDate = DateTime.Now;         

            db.SaveChanges(); // 실제로 저장 

            #region 삭제

            BoardFile _update =
             (from a in db.BoardFile where a.id == file_idx select a).Single();
            _update.use_yn = "N";           

            db.SaveChanges(); // 실제로 저장 

            #endregion                       

            return Redirect("/board/BoardWrite?cate="+doc.BM_idx+"&idx="+ doc.idx);
        }
     
        public IActionResult GetDownload(string link, string file_name)
        {
            var net = new System.Net.WebClient();
            var data = net.DownloadData(link);
            var content = new System.IO.MemoryStream(data);
            var contentType = "application/force-download";
           
            return File(content, contentType, file_name);
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

        public ActionResult BoardComment_action(BoardComment doc,string BD_idx, string cate, string mode_type, int? c_idx)
        {
            int idx = 0;
           
            string msg = "";
          
            #region 기본 사용자 정보
            string user_id = User.Identity.Name;
            int department_idx = Convert.ToInt32(UserData.user_get(user_id, "department_idx"));
            int company_idx = Convert.ToInt32(UserData.user_get(user_id, "company_idx"));
            int auth = Convert.ToInt32(UserData.user_get(user_id, "auth"));
            #endregion

            if (c_idx ==null)
            {
                #region 저장

                doc.write_date = DateTime.Now;
                doc.writer = User.Identity.Name;
                doc.edit_date = DateTime.Now;
                doc.use_yn = "Y";              
                db.BoardComment.Add(doc);
                db.SaveChanges(); // 실제로 저장 


                msg = admin_basic.Util.msg.msg_insert;

                #endregion
            }
            else
            {               

                if (mode_type == "D")
                {
                    #region 삭제

                    BoardComment doc_del = db.BoardComment.Single(x => x.idx == c_idx);
                    db.BoardComment.Remove(doc_del);
                    db.SaveChanges();

                    msg = admin_basic.Util.msg.msg_del;

                    #endregion
                }

                else if (mode_type == "E")
                {
                    #region 임시 삭제 / 상태 변환 업데이트

                    BoardComment _update =
                        (from a in db.BoardComment where a.idx == c_idx select a).Single();
                    _update.edit_date = DateTime.Now;
                    _update.use_yn = "D";
                    _update.writer = User.Identity.Name;                 

                    db.SaveChanges(); // 실제로 저장 


                    msg = admin_basic.Util.msg.msg_disable;

                    #endregion
                }
                else
                {
                    #region 수정


                    BoardComment _update =
                        (from a in db.BoardComment where a.idx == idx select a).Single();
                 
                    _update.edit_date = DateTime.Now;                   
                    _update.memo = doc.memo;


                    db.SaveChanges(); // 실제로 저장 



                    msg = admin_basic.Util.msg.msg_edit;

                    #endregion
                }
            }
            string url = "/board/boardview?idx=" + BD_idx + "&cate=" + cate ;

            return Redirect(url);
                
        }

    }
}