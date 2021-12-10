using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SushiStore.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalAmount { get; set; }
        public string ShippingAdress { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public virtual ICollection<OrderProduct> OrderProducts { get; set; }

    }
}
