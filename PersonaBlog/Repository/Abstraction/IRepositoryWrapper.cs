using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonaBlog.Repository.Abstraction
{
    public interface IRepositoryWrapper
    {
        IAcceptedRepository Accepted { get; set; }
        IRequestsRepository Requests { get; set; }
        void Save();
    }
}
