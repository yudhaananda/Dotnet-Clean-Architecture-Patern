using ApplicationCore.Filters;
using ApplicationCore.Models;
using ApplicationCore.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AsyncRepository<T, F> : IAsyncRepository<T, F> where F : BaseFilter<T> where T : BaseModel<T>
    {
        public readonly DataContext _db;

        public AsyncRepository(DataContext db)
        {
            _db = db;
        }

        public async Task<bool> CreateAsync(T entity, CancellationToken cancellation)
        {
            try
            {
                entity.Create();
                await _db.Set<T>().AddAsync(entity, cancellation);
                await _db.SaveChangesAsync(cancellation);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> DeleteAsync(int id, CancellationToken cancellation)
        {
            try
            {
                var data = await _db.Set<T>().FindAsync(id, cancellation);
                if (data == null)
                {
                    return false;
                }
                data.Delete();
                await _db.SaveChangesAsync(cancellation);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> EditAsync(T entity, int id, CancellationToken cancellation)
        {
            try
            {
                var oldData = await _db.Set<T>().FindAsync(id, cancellation);
                if (oldData == null)
                {
                    return false;
                }

                oldData.Edit(entity);

                await _db.SaveChangesAsync(cancellation);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<List<T>> GetAsync(Dictionary<string, string> filter, BaseFilter<T> spec, CancellationToken cancellation)
        {
            var query = _db.Set<T>().AsQueryable();
            query = spec.ToSpecification(filter, query);
            return await query.ToListAsync(cancellation);
        }
    }
}
