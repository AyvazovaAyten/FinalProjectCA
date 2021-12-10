using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SushiStore.ViewModels
{
    public class RegisterVM
    {
        [Required]
        [MaxLength(100, ErrorMessage = "Maximum length is 100!")]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Maximum length is 100!")]
        public string SurName { get; set; }

        [Required, EmailAddress, DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required, DataType(DataType.Password)]
        [StringLength(100, MinimumLength = 8)]
        public string Password { get; set; }
        [Required, DataType(DataType.Password), Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
        public string Adress { get; set; }
        [MaxLength(400, ErrorMessage = "Maximum length is 400!")]
        public string AdressLine { get; set; }
    }
}
