using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GulAhmedShop.Models;

namespace GulAhmedShop.ViewModel
{
    public class NewDressViewModel
    {

        public IEnumerable<SeasonDress> SeasonDress { get; set; }

        
        public WomenDress WomenDress { get; set; }

    }
}