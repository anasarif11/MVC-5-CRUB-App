using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GulAhmedShop.Models
{
    public class NewDress
    {
        public WomenDress WomenDress { get; set; }

        public IEnumerable<SeasonDress> SeasonDress { get; set; }
    }
}