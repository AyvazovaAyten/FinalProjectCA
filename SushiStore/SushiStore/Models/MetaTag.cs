using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SushiStore.Models
{
    public class MetaTag
    {
        public int Id { get; set; }
        public string Tag { get; set; }
        public int PageId { get; set; }
        public virtual Page Page { get; set; }
    }
}
