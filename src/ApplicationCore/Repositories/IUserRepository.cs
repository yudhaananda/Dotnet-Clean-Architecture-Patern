using ApplicationCore.Filters;
using ApplicationCore.Models;

namespace ApplicationCore.Repositories
{
    public interface IUserRepository : IAsyncRepository<User, UserFilter>
    {
    }
}
