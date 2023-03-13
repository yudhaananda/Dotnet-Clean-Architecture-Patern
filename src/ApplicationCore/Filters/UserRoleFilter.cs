using ApplicationCore.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ApplicationCore.Filters
{
    public class UserRoleFilter : BaseFilter<UserRole>
    {
        public override IQueryable<UserRole> ToSpecification(Dictionary<string, string> filter, IQueryable<UserRole> query)
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
                    case "roleid":
                        int roleId;
                        if (int.TryParse(item.Value, out roleId))
                        {
                            query = query.Where(x => x.RoleId == roleId);
                        }
                        break;
                    case "userid":
                        int userId;
                        if (int.TryParse(item.Value, out userId))
                        {
                            query = query.Where(x => x.UserId == userId);
                        }
                        break;
                    case "include":
                        bool include;
                        if (bool.TryParse(item.Value, out include))
                        {
                            if (include)
                            {
                                query = query.Include(x => x.User);
                                query = query.Include(x => x.Role);
                            }
                        }
                        break;
                    case "order":
                        var orderItem = item.Value.Split(" ");
                        if (orderItem.Length == 2)
                        {
                            Expression<Func<UserRole, object>>? order = null;
                            switch (orderItem[0].ToLower())
                            {
                                case "id":
                                    order = x => x.Id;
                                    break;
                                case "roleid":
                                    order = x => x.RoleId;
                                    break;
                                case "userid":
                                    order = x => x.UserId;
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
