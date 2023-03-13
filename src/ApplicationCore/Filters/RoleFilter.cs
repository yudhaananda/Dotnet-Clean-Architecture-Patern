using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;

namespace ApplicationCore.Filters
{
    public class RoleFilter : BaseFilter<Role>
    {
        public override IQueryable<Role> ToSpecification(Dictionary<string, string> filter, IQueryable<Role> query)
        {
            foreach (var item in filter)
            {
                switch (item.Key.ToLower())
                {
                    case "id":
                        int id;
                        if (int.TryParse(item.Value, out id))
                        {
                            query = query.Where(x => x.Id == id);
                        }
                        break;
                    case "name":
                        query = query.Where(x => x.Name == item.Value);
                        break;
                    case "include":
                        bool include;
                        if (bool.TryParse(item.Value, out include))
                        {
                            if (include)
                            {
                                query = query.Include(x => x.UserRoles);
                            }
                        }
                        break;
                    case "order":
                        var orderItem = item.Value.Split(" ");
                        if (orderItem.Length == 2)
                        {
                            Expression<Func<Role, object>>? order = null;
                            switch (orderItem[0].ToLower())
                            {
                                case "id":
                                    order = x => x.Id;
                                    break;
                                case "roleid":
                                    order = x => x.Name;
                                    break;

                            }
                            if (order != null)
                            {
                                switch (orderItem[1].ToLower())
                                {
                                    case "asc":
                                        query = query.OrderBy(order);
                                        break;
                                    case "desc":
                                        query = query.OrderByDescending(order);
                                        break;

                                }
                            }
                        }
                        break;

                }
                query = ToBaseSpecification(item, query);
            }
            return query;
        }
    }
}
