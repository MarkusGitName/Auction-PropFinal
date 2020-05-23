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

    public partial class RegisteredBuyer
    {
        public RegisteredBuyer()
        {
            Bids = new HashSet<Bid>();
           // BuyerAddresses = new HashSet<BuyerAddress>();
            ConcludedAuctions = new HashSet<ConcludedAuction>();
            //Deposits = new HashSet<Deposit>();
           // Guarintees = new HashSet<Guarintee>();
        }

        [Key]
        public string UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(100)]
        public string LastName { get; set; }

        [Required]
        [StringLength(10)]
        public string IDNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        public bool BondedOrCash { get; set; }

        [Required]
        [StringLength(500)]
        public string ProofOfResidencePath { get; set; }

        [Required]
        [StringLength(500)]
        public string CopyOfIDPath { get; set; }

        [StringLength(500)]
        public string ProfilePhotoPath { get; set; }

        public bool ApprovalStatus { get; set; }

        [Column(TypeName = "date")]
        public DateTime RegistrationDate { get; set; }

        public bool Signiture { get; set; }

        public virtual AuctionRegistration AuctionRegistration { get; set; }

        public virtual ICollection<Bid> Bids { get; set; }

     //   public virtual ICollection<BuyerAddress> BuyerAddresses { get; set; }

        public virtual ICollection<ConcludedAuction> ConcludedAuctions { get; set; }

      // public virtual ICollection<Deposit> Deposits { get; set; }

       //  public virtual ICollection<Guarintee> Guarintees { get; set; }
    }
}