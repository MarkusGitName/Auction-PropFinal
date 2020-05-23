using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Web;

namespace Auction_Prop_Buyers.Models.DisplayMadels
{
    public class Property
    {
        public Property()
        {
            PromoVideos = new HashSet<PromoVideo>();
            PropertyPhotos = new HashSet<PropertyPhoto>();
        }

        public int PropertyID { get; set; }

        public string SellerID { get; set; }

        public string Title { get; set; }

        public string Country { get; set; }

        public string Province { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string Description { get; set; }

        public string Type { get; set; }

        public string Status { get; set; }

        public int? BedRooms { get; set; }

        public int? BathRooms { get; set; }

        public int? BuildingArea { get; set; }

        public int? TerraceArea { get; set; }

        public int? Garages { get; set; }

        [Column(TypeName = "money")]
        public decimal PrpertyValue { get; set; }

        [Column(TypeName = "money")]
        public decimal MinimubBid { get; set; }

        [Column(TypeName = "money")]
        public decimal? Reserve { get; set; }

        public string PlansPath { get; set; }

        public string TaxesAndRates { get; set; }

        public string TitleDeedPath { get; set; }

        public DbGeography Location { get; set; }

        public bool ApprovalStatus { get; set; }

        public bool SellerSigniture { get; set; }

        public bool A_C { get; set; }

        public bool PetsAllowed { get; set; }

        public bool Garden { get; set; }

        public bool CableTV { get; set; }

        public bool Terrace { get; set; }

        public bool wi_fi { get; set; }

        public bool Fibre { get; set; }

        public bool Pool { get; set; }

        public bool Balcony { get; set; }

        public bool Parquet { get; set; }

        public bool Beach { get; set; }

        public bool Gerage { get; set; }

        public bool RoofTarrace { get; set; }

        public bool Sauna { get; set; }

        public bool OutdoorKitchen { get; set; }

        public bool FireplacePit { get; set; }

        public bool SunRoom { get; set; }

        public bool ConcreteFlooring { get; set; }

        public bool WoodFloring { get; set; }

        public bool TennisCourts { get; set; }


        public virtual Auction Auction { get; set; }



        // public virtual ConcludedAuction ConcludedAuction { get; set; }

         public virtual ICollection<PromoVideo> PromoVideos { get; set; }

        public virtual Sellers Seller { get; set; }

        public virtual ICollection<PropertyPhoto> PropertyPhotos { get; set; }
    }
}