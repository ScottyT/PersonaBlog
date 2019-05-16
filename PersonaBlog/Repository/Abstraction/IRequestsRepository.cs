using PersonaBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonaBlog.Repository.Abstraction
{
    public interface IRequestsRepository : IRepositoryBase<RequestsModel>
    {
        void CreateRequest(RequestsModel request);
        void UpdateRequest(RequestsModel request);
    }
}
