using ApplicationCore.Filters;
using ApplicationCore.Models;
using ApplicationCore.Repositories;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            }catch (Exception ex)
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
            }catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> EditAsync(T entity,int id, CancellationToken cancellation)
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
            }catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<List<T>> GetAsync(F filter, CancellationToken cancellation)
        {
            filter.ApplyFilterSpec();
            var query = _db.Set<T>().AsQueryable();
            if (filter.Filter != null)
            {
                foreach (var item in filter.Filter)
                {
                    query = query.Where(item).AsQueryable();
                }
            }

            return await query.ToListAsync(cancellation);
        }



    }
}
