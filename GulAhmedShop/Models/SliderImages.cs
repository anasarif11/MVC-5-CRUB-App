using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace GulAhmedShop.Models
{
    public class SliderImages
    {
        public int id { get; set; }

        public string imagePath { get; set; }

        [NotMapped]
        public HttpPostedFileBase imagePosted { get; set; }

        public string imageHeading { get; set; }

    }
}