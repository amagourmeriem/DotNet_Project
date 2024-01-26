using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModElle.Models
{
    public class Product
    {

        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Article")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Taille")]
        public string size { get; set; }
        [Required]
        [Display(Name = "Couleur")]
        public string color { get; set; }
        [Required]
        [MaxLength(200)]
        [Display(Name = "Déscription")]
        public string Description { get; set; }
        [Required]
        [Display(Name = "Prix")]
        public string ListPrice { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey(("CategoryId"))]
        [ValidateNever]
        public Category Category { get; set; }
        [ValidateNever]
        public string ImageUrl { get; set; }

    }
}
