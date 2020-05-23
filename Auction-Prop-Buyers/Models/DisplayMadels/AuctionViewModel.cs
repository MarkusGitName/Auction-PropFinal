using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction_Prop_Buyers.Models.DisplayMadels
{
    public class Auction
    {
        public Auction()
        {
             AuctionRegistrations = new HashSet<AuctionRegistration>();
            //   Bids = new HashSet<Bid>();
        }

        public int PropertyID { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

          public virtual ICollection<AuctionRegistration> AuctionRegistrations { get; set; }

        public virtual Property Property { get; set; }

        public virtual ICollection<Bid> Bids { get; set; }

        //  public virtual ConcludedAuction ConcludedAuction { get; set; }
    }
    public class AuctionViewModel
    {
    }
}