using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonaBlog.Models
{
    public class AcceptedRequests
    {
        [Key]
        public Guid AcceptedId { get; set; }
        public int Priority { get; set; }

        public RequestsModel Request { get; set; }
    }
}
