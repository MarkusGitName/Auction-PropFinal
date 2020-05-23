using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Auction_Prop_Buyers.Models.DisplayMadels
{
    public class PropertyPhotoViewModel
    {
    }
    public class PropertyPhoto
    {
        public int ImageID { get; set; }

        public int PropertyId { get; set; }


        public string Title { get; set; }


        public string Description { get; set; }

        public string PropertyPhotoPath { get; set; }

        public virtual Property Property { get; set; }
    }
}