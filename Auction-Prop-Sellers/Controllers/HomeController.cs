using APILibrary;
using Auction_Prop_Sellers.Models.DataViewModels;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Auction_Prop_Sellers.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(Sellers model)
        {
            if (ModelState.IsValid)
            {
                return View();
            }
            else
            {


                try
                {
                    Sellers sellerModel = APIMethods.APIGet<Sellers>(User.Identity.GetUserId(), "Sellers");

                    return View(sellerModel);


                }
                catch
                {

                    return View();
                }

            }



        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}