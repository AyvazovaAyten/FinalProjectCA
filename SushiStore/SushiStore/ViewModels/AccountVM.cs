using SushiStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SushiStore.ViewModels
{
    public class AccountVM
    {
        public User User { get; set; }
        public List<Order> Orders { get; set; }
        public List<Rating> Ratings { get; set; }
        
    }
}
