using PersonaBlog.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PersonaBlog.Models
{
    public class AcceptedRequests
    {
        public int Priority { get; set; }
        public string RequestID { get; set; }
        public RequestsModel Request { get; set; }
    }
}
