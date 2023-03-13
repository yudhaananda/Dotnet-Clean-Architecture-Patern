using ApplicationCore.Filters;
using ApplicationCore.Models;
using ApplicationCore.Repositories;

namespace Infrastructure.Repositories
{
    public class RoleRepository : AsyncRepository<Role, RoleFilter>, IRoleRepository
    {
        public RoleRepository(DataContext db) : base(db)
        {
        }
    }
}
