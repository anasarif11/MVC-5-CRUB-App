using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GulAhmedShop.Models
{
    public class ok
    {
        public static List<cartItem> c = new List<cartItem>();
    }

    public class cartItem
    {
        public int productid { get; set; }
        public int productqty { get; set; }
    }
}