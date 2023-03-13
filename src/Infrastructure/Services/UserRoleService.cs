using ApplicationCore;
using ApplicationCore.Filters;
using ApplicationCore.Models;
using ApplicationCore.Services;

namespace Infrastructure.Services
{
    public class UserRoleService : AsyncService<UserRole, UserRoleFilter>, IUserRoleService
    {
        private readonly IUnitOfWork _repository;
        public UserRoleService(IUnitOfWork repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<bool> CreateAsync(UserRole entity, CancellationToken cancellation)
        {
            return await _repository.UserRole.CreateAsync(entity, cancellation);
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellation)
        {
            return await _repository.UserRole.DeleteAsync(id, cancellation);
        }

        public async Task<bool> EditAsync(UserRole entity, int id, CancellationToken cancellation)
        {
            return await _repository.UserRole.EditAsync(entity, id, cancellation);
        }

        public async Task<List<UserRole>> GetAsync(Dictionary<string, string> filter, CancellationToken cancellation)
        {
            var userRoles = await _repository.UserRole.GetAsync(filter, new UserRoleFilter(), cancellation);

            foreach (var item in userRoles)
            {
                if (item.User != null)
                {
                    item.User.UserRoles = null;
                }
                if (item.Role != null)
                {
                    item.Role.UserRoles = null;
                }
            }

            return userRoles;
        }
    }
}
