using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SushiStore.Models
{
    public class AppPart
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string MenuText { get; set; }
        public string MenuImage { get; set; }
        public string AppImage { get; set; }

    }
}
