using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SushiStore.Models
{
    public class CartProduct
    {
        [Key]
        public int Id { get; set; }
        public int Quantity { get; set; }
        public string UserId { get; set; }
        public int ProductId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CurrentPrice { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? OldPrice { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
}
