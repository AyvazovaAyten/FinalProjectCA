using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SushiStore.Interfaces
{
    public interface IMail
    {
        public Task SendEmailAsync(string email, string subject, string message);
    }
}
