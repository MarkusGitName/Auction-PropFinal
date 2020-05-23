using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Auction_Prop_Buyers.Controllers
{
    public class FileController : Controller
    {
        public static string uri = "https://localhost:44317";
        [HttpPost]
        public static string PostFile(HttpPostedFileBase file, string filePath, string uriExtension)
        {
            if (file != null && file.ContentLength > 0)
            {
                string path = Path.Combine(filePath, Path.GetFileName(file.FileName));
                file.SaveAs(path);
                string Patth = uri + "/" + uriExtension + "/" + Path.GetFileName(file.FileName);


                return Patth;
            }
            return "error";
        }
    }
}