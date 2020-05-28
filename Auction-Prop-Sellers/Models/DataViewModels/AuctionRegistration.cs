using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction_Prop_Sellers.Models.DataViewModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

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


        public virtual Property Property { get; set; }

        public virtual RegisteredBuyer RegisteredBuyer { get; set; }
    }
}