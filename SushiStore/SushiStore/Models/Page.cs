using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SushiStore.Models
{
    public class Page
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Title Title { get; set; }
        public virtual PageIntro PageIntro { get; set; }
        public virtual ICollection<MetaTag> MetaTags { get; set; }
    }
}
