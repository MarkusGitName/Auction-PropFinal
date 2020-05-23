using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Auction_Prop_Buyers.Models.DisplayMadels
{
    public class BuyerViewModel
    {
        public BuyerViewModel()
        {
            Bids = new HashSet<Bid>();
            BuyerAddresses = new HashSet<BuyerAddress>();
            Guarintees = new HashSet<Guarintee>();
        }

        public string UserId { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public string IDNumber { get; set; }

        [Column(TypeName = "date")]
        public DateTime DateOfBirth { get; set; }

        public bool BondedOrCash { get; set; }

        [Required]
        public HttpPostedFileBase ProofOfResidencePath { get; set; }

        [Required]
        public HttpPostedFileBase CopyOfIDPath { get; set; }

        public HttpPostedFileBase ProfilePhotoPath { get; set; }

        public bool ApprovalStatus { get; set; }

        [Column(TypeName = "date")]
        public DateTime RegistrationDate { get; set; }

        public bool Signiture { get; set; }

        public virtual ICollection<AuctionRegistration> AuctionRegistrations { get; set; }

        public virtual ICollection<Bid> Bids { get; set; }

        public virtual ICollection<BuyerAddress> BuyerAddresses { get; set; }

        public virtual Deposit Deposits { get; set; }

        public virtual ICollection<Guarintee> Guarintees { get; set; }

    }
    public partial class RegisteredBuyer
    {
        public RegisteredBuyer()
        {
            AuctionRegistrations = new HashSet<AuctionRegistration>();
            Bids = new HashSet<Bid>();
            BuyerAddresses = new HashSet<BuyerAddress>();
            Guarintees = new HashSet<Guarintee>();
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

        public virtual ICollection<AuctionRegistration> AuctionRegistrations { get; set; }

        public virtual ICollection<Bid> Bids { get; set; }

        public virtual ICollection<BuyerAddress> BuyerAddresses { get; set; }

        public virtual Deposit Deposit { get; set; }

        public virtual ICollection<Guarintee> Guarintees { get; set; }


    }
    }