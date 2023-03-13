using ApplicationCore.Filters;
using ApplicationCore.Models;

namespace ApplicationCore.Repositories
{
    public interface IRoleRepository : IAsyncRepository<Role, RoleFilter>
    {
    }
}
