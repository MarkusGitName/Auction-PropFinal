using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auction_Prop_Buyers.Models.DisplayMadels
{
    public class BidViewModel
    {
    }
    public partial class Bid
    {
        public int BidID { get; set; }

        [Required]
        public string BuyerID { get; set; }

        public int PropertyID { get; set; }

       // [Column(TypeName = "money")]
        public decimal AmuntOfBid { get; set; }

        public DateTime TimeOfbid { get; set; }

        public virtual Auction Auction { get; set; }

        public virtual RegisteredBuyer RegisteredBuyer { get; set; }
    }
}