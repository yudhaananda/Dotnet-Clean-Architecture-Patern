﻿using ApplicationCore;
using ApplicationCore.Filters;
using ApplicationCore.Models;
using ApplicationCore.Services;

namespace Infrastructure.Services
{
    public class UserService : AsyncService<User, UserFilter>, IUserService
    {
        private readonly IUnitOfWork _repository;
        public UserService(IUnitOfWork repository) : base(repository)
        {
            _repository = repository;
        }

        public async Task<bool> CreateAsync(User entity, CancellationToken cancellation)
        {
            return await _repository.User.CreateAsync(entity, cancellation);
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellation)
        {
            return await _repository.User.DeleteAsync(id, cancellation);
        }

        public async Task<bool> EditAsync(User entity, int id, CancellationToken cancellation)
        {
            return await _repository.User.EditAsync(entity, id, cancellation);
        }

        public async Task<List<User>> GetAsync(Dictionary<string, string> filter, CancellationToken cancellation)
        {
            var users = await _repository.User.GetAsync(filter, new UserFilter(), cancellation);

            foreach (var item in users)
            {
                if (item.UserRoles != null)
                {
                    foreach (var item1 in item.UserRoles)
                    {
                        item1.User = null;
                    }
                }
            }
            return users;
        }
    }
}
