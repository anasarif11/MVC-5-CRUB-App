using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GulAhmedShop.Models
{
    public class WomenDress
    {
        [Key]
        public int dressId { get; set; }

        [Display(Name ="Name Of Dress")]
        [StringLength(200)]
        [Required]
        public string dressName { get; set; }

        [Display(Name = "Enter Price Of Dress")]
        [Required]
        public decimal price { get; set; }


        public SeasonDress SeasonDress { get; set; }
        
        [Display(Name ="Season Of Dress")]
        [Required]
        public byte SeasonDressseasonId { get; set; }

        [Display(Name ="Collection of year")]
        [Required]
        public string year { get; set; }
        [Display(Name ="Please Post Image Here")]
        public string imagePath { get; set; }

        public int numberInStock { get; set; }
        [NotMapped]
        public HttpPostedFileBase otherImage1 { get; set; }

        public string otherImage1Path { get; set; }
        [NotMapped]
        public HttpPostedFileBase otherImage2 { get; set; }

        public string otherImage2Path { get; set; }
        [NotMapped]
        public HttpPostedFileBase otherImage3 { get; set; }

        public string otherImage3Path { get; set; }

        
    }
}