using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LightLib.Models
{
    public class Checkout
    {
        public int Id { get; set; }

        public IEnumerable<Asset> Assets { get; set; }

        public ApplicationUser AppUser { get; set; }
    }
}