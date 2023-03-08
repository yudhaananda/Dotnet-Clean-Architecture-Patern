using ApplicationCore;
using ApplicationCore.Filters;
using ApplicationCore.Models;
using ApplicationCore.Repositories;
using ApplicationCore.Services;
using Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class AsyncService<T, F> : IAsyncService<T, F> where T : BaseModel<T> where F : BaseFilter<T> 
    {
        private readonly IUnitOfWork _repository;
        public AsyncService(IUnitOfWork repository)
        {
            _repository = repository;
        }
        
    }
}
