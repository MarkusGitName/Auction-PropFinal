namespace Auction_Prop_API.Models.DataBaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Guarintee
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GuarinteeID { get; set; }

        [Required]
        [StringLength(128)]
        public string BuyerID { get; set; }

        [Required]
        [StringLength(500)]
        public string GuarinteePath { get; set; }

        public bool GuarinteeApproval { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfSubmition { get; set; }

        public virtual RegisteredBuyer RegisteredBuyer { get; set; }
    }
}
