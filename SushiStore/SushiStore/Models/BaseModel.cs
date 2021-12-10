using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SushiStore.Models
{
    public class BaseModel
    {
        public int Id { get; set; }
        [Required]
        public string Name  { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
        public Nullable<DateTime> DeletedAt { get; set; }
        public Nullable<DateTime> LastUpdateDate { get; set; }

        public BaseModel()
        {
            IsDeleted = false;
            CreatedAt = DateTime.UtcNow.AddHours(4);
        }


    }
}
