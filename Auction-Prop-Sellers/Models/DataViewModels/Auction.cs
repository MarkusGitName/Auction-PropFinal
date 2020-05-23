using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction_Prop_Sellers.Models.DataViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Auction
    {
        public Auction()
        {
            AuctionRegistrations = new HashSet<AuctionRegistration>();
            Bids = new HashSet<Bid>();
        }

         public int AuctionID { get; set; }

        public int PropertyID { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public virtual ICollection<AuctionRegistration> AuctionRegistrations { get; set; }

        public virtual Property Property { get; set; }

        public virtual ICollection<Bid> Bids { get; set; }

    }
}