using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LightLib.Models
{
    public class Checkout
    {
        public int Id { get; set; }

        public List<Asset> Assets { get; set; }

        public DateTime DateCheckedOut { get; set; }
    }
}