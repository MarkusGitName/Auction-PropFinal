﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction_Prop_Buyers.Models.DisplayMadels
{
    public class PrivateSellerViewModel
    {
    }

    public partial class PrivateSeller
    {
        public string UserID { get; set; }

        public string IDNumber { get; set; }

        public string ProfilePhotoPath { get; set; }

        public string ProofOfResedence { get; set; }

        public bool Signiture { get; set; }

        public string email { get; set; }
        public string PhoneNumber { get; set; }

        public virtual Sellers Seller { get; set; }
    }
}