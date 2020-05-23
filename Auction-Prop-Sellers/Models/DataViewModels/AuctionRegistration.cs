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
        [Key]
        public string BuyerId { get; set; }

        public int AuctionID { get; set; }

        public int GuarinteeID { get; set; }

        public bool RegistrationFees { get; set; }

        public int PaymentID { get; set; }

        public DateTime RegesterDate { get; set; }

        public bool Signiture { get; set; }

        public bool RegistrationStatus { get; set; }

        //public virtual AdminFeesPayment AdminFeesPayment { get; set; }

        //public virtual Guarintee Guarintee { get; set; }

        public virtual Auction Auction { get; set; }

        public virtual RegisteredBuyer RegisteredBuyer { get; set; }
    }
}