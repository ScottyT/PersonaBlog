using PersonaBlog.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonaBlog.Repository.Abstraction
{
    public class RequestsRepository : RepositoryBase<RequestsModel>, IRequestsRepository
    {
        public RequestsRepository(BlogContext blogContext) : base(blogContext)
        {

        }

        public void CreateRequest(RequestsModel request)
        {
            request.Id = Guid.NewGuid().ToString();
            Create(request);
        }
    }
}
