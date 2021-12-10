using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SushiStore.Models
{
    public class Category:BaseModel
    {
        public virtual ICollection<Product> Products { get; set; }
    }
}
