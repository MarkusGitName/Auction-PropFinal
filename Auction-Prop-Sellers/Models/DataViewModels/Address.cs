using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auction_Prop_Sellers.Models.DataViewModels
{
    public class Address
    {
        public int AddressID { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public string City { get; set; }

        public string Supburb { get; set; }

        public string Area { get; set; }

        [Required]
        public string Street { get; set; }

        public int Number { get; set; }

        public virtual SellerAddress SellerAddress { get; set; }
    }
}