using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auction_Prop_Sellers.Models.DataViewModels
{
    public class PrivateSellerData
    {
        [Key]
        public string UserID { get; set; }

        [Required]
        public string IDNumber { get; set; }


        public HttpPostedFileBase ProfilePhotoPath { get; set; }

        [Required]
        public HttpPostedFileBase ProofOfResedence { get; set; }

        public bool Signiture { get; set; }

        public virtual Sellers Seller { get; set; }
    }
    public class PrivateSeller
    {
        [Key]
        public string UserID { get; set; }

        [Required]
        public string IDNumber { get; set; }


        public string ProfilePhotoPath { get; set; }

        [Required]
        public string ProofOfResedence { get; set; }

        public bool Signiture { get; set; }

        public virtual Sellers Seller { get; set; }

    }
}
