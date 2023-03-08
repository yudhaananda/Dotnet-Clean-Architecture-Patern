using ApplicationCore.Filters;
using ApplicationCore.Models;
using ApplicationCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore
{
    public interface IUnitOfWork
    {
        IUserRepository User { get; } 
    }
}
