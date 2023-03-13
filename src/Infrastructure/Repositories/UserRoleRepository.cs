using ApplicationCore.Filters;
using ApplicationCore.Models;
using ApplicationCore.Repositories;

namespace Infrastructure.Repositories
{
    public class UserRoleRepository : AsyncRepository<UserRole, UserRoleFilter>, IUserRoleRepository
    {
        public UserRoleRepository(DataContext db) : base(db)
        {
        }
    }
}
