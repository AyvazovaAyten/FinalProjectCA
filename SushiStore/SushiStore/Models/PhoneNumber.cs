using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SushiStore.Models
{
    public class PhoneNumber
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public virtual Bio Bio { get; set; }
        public int BioId { get; set; }
    }
}
