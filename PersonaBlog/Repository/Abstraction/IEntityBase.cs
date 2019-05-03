using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PersonaBlog.Repository.Abstraction
{
    public interface IEntityBase
    {
        string Id { get; set; }
    }
}
