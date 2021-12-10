using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SushiStore.Models
{
    public class IntroSlider
    {
        public int Id { get; set; }
        public string Image { get; set; }
        [MaxLength(50, ErrorMessage = "Maksimum 50 simvoldan ibaret ola biler.")]
        [Required]
        [Display(Name = "Name")]
        public string SliderText { get; set; }
        [NotMapped]
        public IFormFile ImageFile { get; set; }
        [MaxLength(300, ErrorMessage = "Maksimum 300 simvoldan ibaret ola biler.")]
        public string Description { get; set; }
        public string Duration { get; set; }
        public string Details { get; set; }
    }
}
