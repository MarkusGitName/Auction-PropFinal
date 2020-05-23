using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction_Prop_Buyers.Models.DisplayMadels
{
    public partial class Sellers
    {
        public Sellers()
        {
            Properties = new HashSet<Property>();
        }

        public string UserID { get; set; }

        public string FirtstName { get; set; }

        public string LastName { get; set; }

        public string SellerType { get; set; }

        public bool Signature { get; set; }

        public virtual PrivateSeller PrivateSeller { get; set; }

        public virtual ICollection<Property> Properties { get; set; }

        public virtual Retaileler Retaileler { get; set; }

    }
    public class SellersViewModel
    {
    }
}