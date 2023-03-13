using ApplicationCore;
using ApplicationCore.Repositories;
using Infrastructure.Repositories;

namespace Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;
        private IUserRepository userRepository;
        private IRoleRepository roleRepository;
        private IUserRoleRepository userRoleRepository;

        public IUserRepository User => userRepository = userRepository ?? new UserRepository(_dataContext);
        public IRoleRepository Role => roleRepository = roleRepository ?? new RoleRepository(_dataContext);
        public IUserRoleRepository UserRole => userRoleRepository = userRoleRepository ?? new UserRoleRepository(_dataContext);

        public UnitOfWork(DataContext context)
        {
            _dataContext = context;
        }

    }
}
