using ApplicationCore.Filters;
using ApplicationCore.Models;
using ApplicationCore.Repositories;
using ApplicationCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class RoleRepository : AsyncRepository<Role, RoleFilter>, IRoleRepository
    {
        public RoleRepository(DataContext db) : base(db)
        {
        }
    }
}
