namespace Auction_Prop_API.Models.DataBaseModels
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("AdminFeesPayment")]
    public partial class AdminFeesPayment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PaymentID { get; set; }

        [Required]
        [StringLength(500)]
        public string ProofOfPaymentPath { get; set; }

        public DateTime DateOfPayment { get; set; }
    }
}
