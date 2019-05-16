using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PersonaBlog.Models;
using PersonaBlog.Repository.Abstraction;

namespace PersonaBlog.Repository
{
    public class AcceptedRepository : RepositoryBase<AcceptedRequests>, IAcceptedRepository
    {
        private BlogContext _context;

        public AcceptedRepository(BlogContext context) : base(context)
        {
            
        }

        public void RequestAccepted(AcceptedRequests accepted)
        {
            accepted.AcceptedId = Guid.NewGuid().ToString();
            Create(accepted);
        }
    }
}
