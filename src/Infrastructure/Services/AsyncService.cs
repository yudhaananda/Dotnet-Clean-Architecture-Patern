using ApplicationCore;
using ApplicationCore.Filters;
using ApplicationCore.Models;
using ApplicationCore.Services;

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
