using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SushiStore.Models
{
    public class Product:BaseModel
    {
        public string ProductCode { get; set; }
        public string Image { get; set; }
        public virtual ProductPrice Prices { get; set; }
        public int? Count { get; set; }
        public string Description { get; set; }
        public string Ingredients { get; set; }
        public virtual Nutrition Nutrition { get; set; }
        public int SaleCount { get; set; }
        public double? Weight { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        [NotMapped]
        [Required]
        public IFormFile ImageFile { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }
        public double? Rating
        {
            get
            {
                if(Ratings !=null && Ratings.Count>0) return (double)(Ratings.Sum(r => r.Value)) / Ratings.Count;

                return null;
            }
        }

    }
}
