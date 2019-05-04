using PersonaBlog.Models;
using PersonaBlog.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonaBlog.Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private BlogContext _context;
        private IAcceptedRepository _accepted;
        private IRequestsRepository _requests;

        public IAcceptedRepository Accepted
        {
            get
            {
                if (_accepted == null)
                {
                    _accepted = new AcceptedRepository(_context);
                }
                return _accepted;
            }
            set { }
        }

        public IRequestsRepository Requests
        {
            get
            {
                if(_requests == null)
                {
                    _requests = new RequestsRepository(_context);
                }
                return _requests;
            }
            set { }
        }
        

        public RepositoryWrapper(BlogContext context)
        {
            _context = context;
        }
        public void Save()
        {
            _context.SaveChangesAsync();
        }
    }
}
