using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auction_Prop_Buyers.Models.DisplayMadels
{
    public partial class Seller
    {
         public Seller()
        {
            Properties = new HashSet<Property>();
        }

        public string UserID { get; set; }

        [Required]
        public string FirtstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string SellerType { get; set; }

        public bool Signature { get; set; }

        public bool ApprovalStatus { get; set; }

        public virtual PrivateSeller PrivateSeller { get; set; }

        public virtual ICollection<Property> Properties { get; set; }

        public virtual Retaileler Retaileler { get; set; }

     //   public virtual ICollection<SellerAddress> SellerAddresses { get; set; }

    }
    public class SellersViewModel
    {
    }
}