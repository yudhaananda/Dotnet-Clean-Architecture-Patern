﻿using ApplicationCore;
using ApplicationCore.Filters;
using ApplicationCore.Models;
using ApplicationCore.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            return await _repository.UserRole.GetAsync(filter, new UserRoleFilter(), cancellation);
        }
    }
}
