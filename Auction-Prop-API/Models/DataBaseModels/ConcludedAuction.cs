namespace Auction_Prop_API.Models.DataBaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ConcludedAuction
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PropertyID { get; set; }

        [Column(TypeName = "money")]
        public decimal? HiegestBid { get; set; }

        [StringLength(128)]
        public string WinningBidder { get; set; }

        public DateTime? TimeOfConclution { get; set; }

        public bool? ExceededReserve { get; set; }

        public virtual Property Property { get; set; }
    }
}
