using Microsoft.AspNetCore.Identity;
using SushiStore.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SushiStore.Models
{
    public class User: IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string SurName { get; set; }
        public bool IsEmailConfirmed { get; set; }
        public string Adress { get; set; }
        public string AdressLine { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public Nullable<DateTime> DeletedAt { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        public virtual ICollection<Rating> Ratings { get; set; }      
    }
}
