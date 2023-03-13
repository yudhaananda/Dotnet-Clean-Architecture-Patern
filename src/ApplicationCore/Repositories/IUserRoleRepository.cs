using ApplicationCore.Filters;
using ApplicationCore.Models;

namespace ApplicationCore.Repositories
{
    public interface IUserRoleRepository : IAsyncRepository<UserRole, UserRoleFilter>
    {
    }
}
