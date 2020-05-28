using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Auction_Prop_Buyers.Models.DisplayMadels
{
    public class GuarinteeViewModel
    {
        public GuarinteeViewModel()
        {
            AuctionRegistrations = new HashSet<AuctionRegistration>();
        }

        public int GuarinteeID { get; set; }


        public string BuyerID { get; set; }

        [Required]
        public HttpPostedFileBase GuarinteePath { get; set; }

        public bool GuarinteeApproval { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfSubmition { get; set; }

        public virtual ICollection<AuctionRegistration> AuctionRegistrations { get; set; }

        public virtual RegisteredBuyer RegisteredBuyer { get; set; }
    }

    public partial class Guarintee
    {

        [Key]
        public int AuctionRegistrationID { get; set; }

        [Required]
        public string GuarinteePath { get; set; }

        public bool GuarinteeApproval { get; set; }

        public DateTime DateOfSubmition { get; set; }

        public virtual AuctionRegistration AuctionRegistration { get; set; }
    }
}