namespace Auction_Prop_API.Models.DataBaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Bid")]
    public partial class Bid
    {
         public int BidID { get; set; }

        [Required]
        [StringLength(128)]
        public string BuyerID { get; set; }

        public int PropertyID { get; set; }

        [Column(TypeName = "money")]
        public decimal AmuntOfBid { get; set; }

        public DateTime TimeOfbid { get; set; }

        public virtual Auction Auction { get; set; }

        public virtual RegisteredBuyer RegisteredBuyer { get; set; }
    }
}
