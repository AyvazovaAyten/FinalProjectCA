using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SushiStore.Models
{
    public class ProductPrice
    {
        public int Id { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? OldPrice { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CurrentPrice { get; set; }
        public int ProductId { get; set; }
        public bool? ShowOldPrice { get; set; }
        public virtual Product Product { get; set; }

    }
}
