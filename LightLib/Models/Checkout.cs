using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LightLib.Models
{
    public class Checkout
    {
        public int Id { get; set; }

        public Asset Asset { get; set; }
        public int AssetId { get; set; }

        public User User { get; set; }
        public int UserId { get; set; }
    }
}