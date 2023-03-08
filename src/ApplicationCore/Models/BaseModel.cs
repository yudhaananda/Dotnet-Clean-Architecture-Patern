using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Models
{
    public abstract class BaseModel<T>
    {
        public DateTime? CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
        public int? CreatedById { get; set; }
        public int? UpdatedById { get; set; }
        public int? DeletedById { get; set; }

        public void Create()
        {
            CreatedDate = DateTime.Now;
        }
        public abstract void Edit(T entity);
        public void Delete()
        {
            DeletedDate = DateTime.Now;
        }
    }
}
