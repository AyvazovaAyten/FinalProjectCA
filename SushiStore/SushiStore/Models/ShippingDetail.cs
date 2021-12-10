using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SushiStore.Models
{
    public class ShippingDetail
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string SurName { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Adress { get; set; }
        [Required]
        public string AdressLine { get; set; }
        public bool TakeMyself { get; set; }

    }
}
