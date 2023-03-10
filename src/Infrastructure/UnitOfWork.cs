using ApplicationCore;
using ApplicationCore.Filters;
using ApplicationCore.Models;
using ApplicationCore.Repositories;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
