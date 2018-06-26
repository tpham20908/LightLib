using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LightLib.Models
{
    public class Asset
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public AssetType Type { get; set; }
        public int AssetTypeId { get; set; }
        public string Author { get; set; }
        public int ReleasedYear { get; set; }
        public string ImageUrl { get; set; }
        public string User { get; set; }  
        public DateTime RentDate { get; set; }
        public Checkout Checkout { get; set; }
    }
}