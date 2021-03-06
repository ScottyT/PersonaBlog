﻿using PersonaBlog.Repository;
using PersonaBlog.Repository.Abstraction;
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
        public string AcceptedId { get; set; }
        public int Priority { get; set; }
        public string RequestID { get; set; }
        public RequestsModel Request { get; set; }
    }
}
