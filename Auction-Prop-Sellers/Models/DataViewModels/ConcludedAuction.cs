﻿using System;
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

    public partial class ConcludedAuction
    {
        [Key]
        public int AuctionID { get; set; }

        public int? PropertyID { get; set; }

        [Column(TypeName = "money")]
        public decimal? HiegestBid { get; set; }

        [StringLength(128)]
        public string WinningBidder { get; set; }

        public DateTime? TimeOfConclution { get; set; }

        public bool? ExceededReserve { get; set; }

        public virtual Auction Auction { get; set; }

        public virtual Bid Bid { get; set; }

        public virtual Property Property { get; set; }

        public virtual RegisteredBuyer RegisteredBuyer { get; set; }
    }

}