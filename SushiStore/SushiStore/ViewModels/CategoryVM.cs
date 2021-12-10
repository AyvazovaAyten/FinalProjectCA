using SushiStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SushiStore.ViewModels
{
    public class CategoryVM
    {
        public Category Category {get; set;}
        public List<Product> Products { get; set; }
    }
}
