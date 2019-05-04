using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonaBlog.ViewModels
{
    public class RequestFormViewModel
    {
        public string Subject { get; set; }
        public string Content { get; set; }
        public DateTime DateCreated { get; set; }
    }
}
