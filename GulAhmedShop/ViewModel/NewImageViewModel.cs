using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using GulAhmedShop.Models;

namespace GulAhmedShop.ViewModel
{
    public class NewImageViewModel
    {
        public IEnumerable<WomenDress> WomenDress { get; set; }

        public IEnumerable<SliderImages> SliderImages { get; set; }

    }
}