using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Auction_Prop_Buyers.Models.DisplayMadels
{
    public class BankApprovalView
    {

        public int ApprovalID { get; set; }

        public string BuierID { get; set; }

        [Required]
        public HttpPostedFileBase ApprovalPath { get; set; }

        public bool BankApprovalApprovalstatus { get; set; }

        public DateTime DateOfSubmision { get; set; }

        public virtual RegisteredBuyer RegisteredBuyer { get; set; }
    }
    
    
        public partial class BankApproval
        {
            [Key]
            public int AuctionRegistrationID { get; set; }

            [Required]
            [StringLength(500)]
            public string ApprovalPath { get; set; }

            public bool BankApprovalApprovalstatus { get; set; }

            public DateTime DateOfSubmision { get; set; }

            public virtual AuctionRegistration AuctionRegistration { get; set; }
        }
    


}