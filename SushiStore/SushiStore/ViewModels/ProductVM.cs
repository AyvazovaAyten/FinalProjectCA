using Microsoft.AspNetCore.Http;
using SushiStore.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SushiStore.ViewModels
{
    public class ProductVM
    {
        [Required, MaxLength(200)]
        public string Name { get; set; }
        [Required]
        public decimal CurrentPrice { get; set; }
        public decimal? OldPrice { get; set; }
        public bool? ShowOldPrice { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public double? Oils { get; set; }
        public double? Proteins { get; set; }
        public double? Carbohydrates { get; set; }
        public int? Calories { get; set; }
        public int? Count { get; set; }
        public double? Weight { get; set; }
        [Required]
        public int CategoryId { get; set; }
        [Required]
        public IFormFile ImageFile { get; set; }

    }
}
