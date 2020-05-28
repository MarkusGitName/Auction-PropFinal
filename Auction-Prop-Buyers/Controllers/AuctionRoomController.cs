using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auction_Prop_Buyers.Models;
using Auction_Prop_Buyers.Models.DisplayMadels;

namespace Auction_Prop_Buyers.Controllers
{
    public class AuctionRoomController : Controller
    {
        // GET: AuctionRoom
        public ActionResult Index(int id)
        {
            try
            {
                Auction model = APILibrary.APIMethods.APIGet<Auction>(id.ToString(), "Auctions");
                return View(model);
            }
            catch (Exception E)
            {
                ErrorViewModel error = new ErrorViewModel()
                {
                    msge = E.ToString(),
                };
                return RedirectToAction("ErrorView","AuctionRoom", error);
            }

        }
        public ActionResult ErrorView(ErrorView error)
        {
            return View();
         
        }
    }
}