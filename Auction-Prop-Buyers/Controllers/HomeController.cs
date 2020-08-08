using APILibrary;
using Auction_Prop_Buyers.Models;
using Auction_Prop_Buyers.Models.DisplayMadels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Auction_Prop_Buyers.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Message msg)
        {
            msg.SellerID = "";
            msg.UserID = "";
            APIMethods.APIPost<Message>(msg, "Messages");
            return View(msg);
        }
         public ActionResult HowItWorks()
        {
            return View();
        }


        public ActionResult Properties(List<Property> model, int? id)
        {
            ICollection<Property> propertiesList = APILibrary.APIMethods.APIGetALL<ICollection<Property>>("Properties");
            List<Property> propLys = new List<Property>();
            List<Property> propLysSorted = new List<Property>();
            List<Property> propLysUnS = new List<Property>();



            foreach (Property prop in propertiesList)
            {
                try
                {

                    if (prop.Auction != null)
                    {
                        propLysSorted.Add(prop);

                    }
                    else
                    {
                        propLysUnS.Add(prop);
                    }



                }
                catch
                {

                }

            }

            var sortedReadings = propLysSorted.OrderBy(x => x.Auction.StartTime.Year)
    .ThenBy(x => x.Auction.StartTime.Date)
    .ThenBy(x => x.Auction.StartTime.TimeOfDay);


            propLysSorted = sortedReadings.ToList<Property>();
            propLysSorted.AddRange(propLysUnS);

            try
            {
                if(id == null)
                {
                    id = 0;
                }
                int? i = 0;
                foreach (Property p in propLysSorted)
                {
                    if (i >= id && i <= id + 15)
                    {
                        propLys.Add(p);
                    }
                    i++;
                }
            }
            catch
            {
                int? i = 0;
                foreach (Property p in propLysSorted)
                {
                    if (i >= id && i <= id + 15)
                    {
                        propLys.Add(p);
                    }
                    i++;
                }
            }

       
            

            return View(propLys);
        }

        public ActionResult Buyers()
        {
            ViewBag.Message = "Buyers";

            return View();
        }   
       

        public ActionResult Sellers()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult FAQ()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Add()
        {
            ViewBag.Message = "Add property";

            return View();
        }
        public ActionResult Auction()
        {
            ViewBag.Message = "Add property";

            return View();
        }
     
        public ActionResult Details(int id)
        {
            try
            {
                Property prop = APIMethods.APIGet<Property>(id.ToString(), "Properties");
                return View(prop);
            }
            catch (Exception E)
            {
                 ErrorViewModel error = new ErrorViewModel()
                {
                    msge = E.ToString(),
                };
                return RedirectToAction("ErrorView", "Home", error);
            }

        }
        public ActionResult Detailss(int id)
        {
            try
            {
                Property prop = APIMethods.APIGet<Property>(id.ToString(), "Properties");
                return View(prop);
            }
            catch (Exception E)
            {
                ErrorViewModel error = new ErrorViewModel()
                {
                    msge = E.ToString(),
                };
                return RedirectToAction("ErrorView", "Home", error);
            }
        }
        public ActionResult DetailsID(int id)
        {
            try
            {
                Property prop = APIMethods.APIGet<Property>(id.ToString(),"Properties");
                return View(prop);
            }
            catch (Exception E)
            {
                ErrorViewModel error = new ErrorViewModel()
                {
                    msge = E.ToString(),
                };
                return RedirectToAction("ErrorView", "Home", error);
            }

        }
        public ActionResult ErrorView(ErrorViewModel error)
        {
            return View(error);
        }
    }
}