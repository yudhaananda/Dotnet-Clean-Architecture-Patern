using ApplicationCore.Filters;
using ApplicationCore.Models;
using ApplicationCore.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRoleRepository : AsyncRepository<UserRole, UserRoleFilter>, IUserRoleRepository
    {
        public UserRoleRepository(DataContext db) : base(db)
        {
        }
    }
}
