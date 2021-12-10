using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SushiStore.DTO.User
{
    public class UserDto
    {
        public string Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string SurName { get; set; }
        [Required]
        public string Email { get; set; }
        public bool IsDeleted { get; set; }
        public string Role { get; set; }
        public List<string> Roles { get; set; }

    }
}
