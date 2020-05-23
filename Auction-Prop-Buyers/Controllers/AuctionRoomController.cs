using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Auction_Prop_Buyers.Models.DisplayMadels;

namespace Auction_Prop_Buyers.Controllers
{
    public class AuctionRoomController : Controller
    {
        // GET: AuctionRoom
        public ActionResult Index(int id)
        {
            Auction model = APILibrary.APIMethods.APIGet<Auction>(id.ToString(), "Auctions");
            return View(model);
        }
    }
}