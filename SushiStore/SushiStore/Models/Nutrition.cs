using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SushiStore.Models
{
    public class Nutrition
    {
        public int Id { get; set; }
        public double? Oils { get; set; }
        public double? Proteins { get; set; }
        public double? Carbohydrates { get; set; }
        public int? Calories { get; set; }
        public virtual Product Product { get; set; }
        public int ProductId { get; set; }
    }
}
