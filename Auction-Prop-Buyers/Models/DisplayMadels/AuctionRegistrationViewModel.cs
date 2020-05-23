using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auction_Prop_Buyers.Models.DisplayMadels
{
    public class AuctionRegistrationViewModel
    {

        public int id { get; set; }

        public string BuyerId { get; set; }

        public int PropertyID { get; set; }

        public bool RegistrationFees { get; set; }

        public DateTime RegesterDate { get; set; }
        [Required]
        public bool Signiture { get; set; }

        public bool RegistrationStatus { get; set; }

        public virtual AdminFee AdminFee { get; set; }

        public virtual Property Property { get; set; }

        public virtual RegisteredBuyer RegisteredBuyer { get; set; }
    }
    public partial class AuctionRegistration
    {
        [Required]
        [StringLength(128)]
        public string BuyerId { get; set; }

        public int PropertyID { get; set; }

        public bool RegistrationFees { get; set; }

        public DateTime RegesterDate { get; set; }

        public bool Signiture { get; set; }

        public bool RegistrationStatus { get; set; }

         public int id { get; set; }

        public virtual AdminFee AdminFee { get; set; }

        public virtual Property Property { get; set; }

        public virtual RegisteredBuyer RegisteredBuyer { get; set; }
    }

}