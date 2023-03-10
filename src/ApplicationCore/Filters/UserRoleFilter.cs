using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Filters
{
    public class UserRoleFilter : BaseFilter<UserRole>
    {
        public override IQueryable<UserRole> ToSpecification(Dictionary<string, string> filter, IQueryable<UserRole> query)
        {
            throw new NotImplementedException();
        }
    }
}
