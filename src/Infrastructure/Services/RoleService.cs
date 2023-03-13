using ApplicationCore;
using ApplicationCore.Filters;
using ApplicationCore.Models;
using ApplicationCore.Services;

namespace Infrastructure.Services
{
    public class RoleService : AsyncService<Role, RoleFilter>, IRoleService
    {
        private readonly IUnitOfWork _repository;
        public RoleService(IUnitOfWork repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<bool> CreateAsync(Role entity, CancellationToken cancellation)
        {
            return await _repository.Role.CreateAsync(entity, cancellation);
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellation)
        {
            return await _repository.Role.DeleteAsync(id, cancellation);
        }

        public async Task<bool> EditAsync(Role entity, int id, CancellationToken cancellation)
        {
            return await _repository.Role.EditAsync(entity, id, cancellation);
        }

        public async Task<List<Role>> GetAsync(Dictionary<string, string> filter, CancellationToken cancellation)
        {
            var roles = await _repository.Role.GetAsync(filter, new RoleFilter(), cancellation);
            foreach (var item in roles)
            {
                if (item.UserRoles != null)
                {
                    foreach (var item1 in item.UserRoles)
                    {
                        item1.Role = null;
                    }
                }
            }
            return roles;
        }
    }
}
