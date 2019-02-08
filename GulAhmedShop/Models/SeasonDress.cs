using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GulAhmedShop.Models
{
    public class SeasonDress
    {
        [Key]
        public byte seasonId { get; set; }

        public string seasonName { get; set; }
    }
}