using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Filters
{
    public class RoleFilter : BaseFilter<Role>
    {
        public override IQueryable<Role> ToSpecification(Dictionary<string, string> filter, IQueryable<Role> query)
        {
            throw new NotImplementedException();
        }
    }
}
