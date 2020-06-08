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


        public ActionResult Properties()
        {
            return View();
        }

        public ActionResult Buyers()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Sellers()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your Contact page.";

            return View();
        }

        public ActionResult FAQ()
        {
            ViewBag.Message = "Your FAQ page.";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your About us page.";

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

        public ActionResult Terms()
        {
            ViewBag.Message = "Terms and Conditions Page.";

            return View();
        }

        public ActionResult AccountReg()
        {
            ViewBag.Message = "Account Register Page.";

            return View();
        }

        public ActionResult Privacy()
        {
            ViewBag.Message = "Privacy Policy Page.";

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
        public ActionResult ErrorView(ErrorView error)
        {
            return View();
        }
    }
}