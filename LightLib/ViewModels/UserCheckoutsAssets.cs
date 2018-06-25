using LightLib.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LightLib.ViewModels
{
    public class UserCheckoutsAssets
    {
        public LibraryUser User { get; set; }
        public IEnumerable<Asset> Assets { get; set; }
    }
}