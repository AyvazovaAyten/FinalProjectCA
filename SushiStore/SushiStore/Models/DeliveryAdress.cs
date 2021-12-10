using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SushiStore.Models
{
    public class DeliveryAdress
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Time { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal? MinAmount { get; set; }
        public int DeliveryId { get; set; }
        public virtual Delivery Delivery { get; set; }
    }
}
