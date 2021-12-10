using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SushiStore.Models
{
    public class PageIntro
    {
        public int Id { get; set; }
        public string IntroLogo { get; set; }
        [Required]
        public string IntroText { get; set; }
        public string IntroTextBold { get; set; }
        public int PageId { get; set; }
        public string Background { get; set; }
        public virtual Page Page { get; set; }
        [NotMapped]
        public IFormFile LogoFile { get; set; }
        [NotMapped]
        public IFormFile BackgroundImage { get; set; }
    }
}
