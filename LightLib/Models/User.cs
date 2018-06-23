﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LightLib.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }

        public virtual IEnumerable<Checkout> Checkouts { get; set; }
    }
}