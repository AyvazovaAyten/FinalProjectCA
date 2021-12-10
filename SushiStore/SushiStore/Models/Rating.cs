using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SushiStore.Models
{
    public class Rating
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public string UserId { get; set; }
        public virtual User User { get; set; }
        public int ProductId { get; set; }
        public virtual Product Product { get; set; }
    }
}
