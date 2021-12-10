using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SushiStore.Models
{
    public class Title
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        public int? PageId { get; set; }
        public virtual Page Page { get; set; }
    }
}
