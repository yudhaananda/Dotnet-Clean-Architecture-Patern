using ApplicationCore.Filters;
using ApplicationCore.Models;
using ApplicationCore.Repositories;

namespace Infrastructure.Repositories
{
    public class UserRepository : AsyncRepository<User, UserFilter>, IUserRepository
    {
        public UserRepository(DataContext db) : base(db)
        {
        }
    }
}
