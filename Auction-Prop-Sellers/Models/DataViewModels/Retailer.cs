using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auction_Prop_Sellers.Models.DataViewModels
{
    public class RetailerView
    {
        [Key]
        public string UserID { get; set; }

        [Required]
        public string RetailerName { get; set; }

        [StringLength(11)]
        public string CompanyContactNumber { get; set; }

        public string CompanyEmail { get; set; }

        public HttpPostedFileBase ProfilePhotoPath { get; set; }

        [Required]
        public HttpPostedFileBase ProofOfResedence { get; set; }

        public bool Signature { get; set; }

        public virtual Seller seller { get; set; }
    }

    public class Retailer
    {
        [Key]
        public string UserID { get; set; }

        [Required]
        public string RetailerName { get; set; }

        [StringLength(11)]
        public string CompanyContactNumber { get; set; }

        public string CompanyEmail { get; set; }

        public string ProfilePhotoPath { get; set; }

        [Required]
        public string ProofOfResedence { get; set; }

        public bool Signature { get; set; }

        public virtual Seller seller { get; set; }
    }
}