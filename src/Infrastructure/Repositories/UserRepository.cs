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
    public class UserRepository : AsyncRepository<User, UserFilter>, IUserRepository
    {
        public UserRepository(DataContext db) : base(db)
        {
        }
    }
}
