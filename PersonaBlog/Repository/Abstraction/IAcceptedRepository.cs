﻿using PersonaBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonaBlog.Repository.Abstraction
{
    public interface IAcceptedRepository : IRepositoryBase<AcceptedRequests>
    {
        void RequestAccepted(AcceptedRequests accepted);
    }
}
