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

        public IUserRepository User => userRepository = userRepository ?? new UserRepository(_dataContext);

        public UnitOfWork(DataContext context)
        {
            _dataContext = context;
        }

    }
}
