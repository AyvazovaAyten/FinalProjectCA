using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SushiStore.Models
{
    public class Delivery
    {
        public int Id { get; set; }
        public string Info { get; set; }
        public string Details { get; set; }
        public virtual IEnumerable<DeliveryAdress> DeliveryAdresses { get; set; }
    }
}
