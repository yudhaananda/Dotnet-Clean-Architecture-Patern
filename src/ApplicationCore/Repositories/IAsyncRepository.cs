using ApplicationCore.Filters;
using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Repositories
{
    public interface IAsyncRepository<T,F>
    {
        Task<List<T>> GetAsync(F filter, CancellationToken cancellation);
        Task<bool> CreateAsync(T entity, CancellationToken cancellation);
        Task<bool> EditAsync(T entity,int id, CancellationToken cancellation);
        Task<bool> DeleteAsync(int id, CancellationToken cancellation);
    }
}
