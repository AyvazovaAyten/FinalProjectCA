using Microsoft.AspNetCore.Http;
using SushiStore.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SushiStore.Models
{
    public class Bio
    {
        public int Id { get; set; }
        public string Logo { get; set; }
        public string RestaurantName { get; set; }
        [Required]
        public string Adress { get; set; }
        public string CallText { get; set; }
        public string CopyRight { get; set; }
        public string SiteBy { get; set; }
        public string FooterText { get; set; }
        public virtual IEnumerable<PhoneNumber> PhoneNumbers { get; set; }
        [Required]
        public string WorkingHours { get; set; }
        [Required]
        public string FbLink { get; set; }
        [Required]
        public string InstagramLink { get; set; }
        [Required]
        public string WhatsappLink { get; set; }
        [Required]
        public string YoutubeLink { get; set; }
        [NotMapped]
        public IFormFile LogoFile { get; set; }
        [NotMapped]
        public List<ProductVM> Products { get; set; }
    }
}
