using ApplicationCore.Filters;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Services
{
    public interface IUserService : IAsyncService<User, UserFilter>
    {
        Task<List<User>> GetAsync(UserFilter filter, CancellationToken cancellation);
        Task<bool> CreateAsync(User entity, CancellationToken cancellation);
        Task<bool> EditAsync(User entity, int id, CancellationToken cancellation);
        Task<bool> DeleteAsync(int id, CancellationToken cancellation);
    }
}
