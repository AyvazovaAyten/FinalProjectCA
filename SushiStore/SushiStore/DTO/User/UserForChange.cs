using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SushiStore.DTO.User
{
    public class UserForChange
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Maximum length is 100!")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Maximum length is 100!")]
        public string SurName { get; set; }
        public string Adress { get; set; }
        [MaxLength(400, ErrorMessage = "Maximum length is 400!")]
        public string AdressLine { get; set; }
    }
}
