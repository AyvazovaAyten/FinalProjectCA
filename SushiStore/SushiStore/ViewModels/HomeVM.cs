using SushiStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SushiStore.ViewModels
{
    public class HomeVM
    {
        public List<IntroSlider> Sliders { get; set; }
        public Intro Intros { get; set; }
        public AppPart AppParts { get; set; }
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
        public Page Page { get; set; }

    }
}
