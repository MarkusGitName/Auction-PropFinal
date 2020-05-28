using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction_Prop_Buyers.Models.DisplayMadels
{
    public class RetailerViewModels
    {
    }
    public partial class Retaileler
    {
        
        public string UserID { get; set; }
        public string RetailerName { get; set; }

        public string CompanyContactNumber { get; set; }

        public string CompanyEmail { get; set; }

        public string ProfilePhotoPath { get; set; }

        public string ProofOfResedence { get; set; }

        public string CompanyDescription { get; set; }

        public bool Signature { get; set; }

        public virtual Seller Seller { get; set; }
    }
}