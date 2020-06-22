using GLtech.Models;

using System.Linq;
namespace admin_basic.Util
{
    public class msg
    {
        public static string msg_insert = "Saved.";
        public static string msg_edit = "Update complete";
        public static string msg_del = "Deleted.";
        public static string msg_no = "You do not have permission.";
        public static string msg_disable = "Disable.";



    }

    public class get_word
    {



        // string language = Request.Cookies["language"].Value ?? "korea";
        public static string language_code(string language_code, string code)
        {
            db_e db = new db_e();

            code = code.Trim();

            string _language_code = "korea";

            if (language_code == "korea")
            {

                _language_code = (from a in db.language
                                  where a.code_name.Equals(code)
                                  select a.korea).FirstOrDefault();
            }

            else if (language_code == "english")
            {

                _language_code = (from a in db.language
                                  where a.code_name.Equals(code)
                                  select a.english).FirstOrDefault();

            }

            return _language_code;

        }
        public static string style_color(string code)
        {

            string color = "red";

            if (code == "blue") { color = "tbl_blue"; }
            else if (code == "azure") { color = "tbl_azure"; }
            else if (code == "green") { color = "tbl_green"; }
            else if (code == "orange") { color = "tbl_orange"; }
            else if (code == "red") { color = "tbl_red"; }
            else if (code == "purple") { color = "tbl_purple"; }





            return color;
        }

        public static string file_type(string code)
        {

            string color = "file.gif";

            if (code == "jpg") { color = "img.gif"; }
            else if (code == "gif") { color = "img.gif"; }
            else if (code == "jpeg") { color = "img.gif"; }
            else if (code == "png") { color = "img.gif"; }
            else if (code == "eps") { color = "eps.gif"; }
            else if (code == "pdf") { color = "pdf.gif"; }
            else if (code == "hwp") { color = "hwp.gif"; }
            else if (code == "doc") { color = "doc.gif"; }
            else if (code == "docx") { color = "doc.gif"; }
            else if (code == "ppt") { color = "ppt.gif"; }
            else if (code == "pptx") { color = "ppt.gif"; }
            else if (code == "xlsx") { color = "xlsx.gif"; }
            else if (code == "xls") { color = "xlsx.gif"; }
            else if (code == "zip") { color = "zip.gif"; }
            else if (code == "txt") { color = "txt.gif"; }


            return color;
        }

        public static string img_check(string code)
        {

            string color = "";

                 if (code == "jpg")  { color = "img"; }
            else if (code == "gif")  { color = "img"; }
            else if (code == "jpeg") { color = "img"; }
            else if (code == "png")  { color = "img"; }
         


            return color;
        }

    }
 
}