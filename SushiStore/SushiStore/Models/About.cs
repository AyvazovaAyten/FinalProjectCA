using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SushiStore.Models
{
    public class About
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AboutBody { get; set; }
        public string VideoLink { get; set; }
    }
}
