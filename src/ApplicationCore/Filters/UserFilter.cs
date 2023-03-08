using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.Filters
{
    public class UserFilter : BaseFilter<User>
    {
        public int? Id { get; set; }
        public string? UserName { get; set; }

        public override void ToSpecification(Dictionary<string, string> filter)
        {
            foreach (var item in filter)
            {
                switch (item.Key.ToLower())
                {
                    case "id":
                        int id;
                        if (int.TryParse(item.Value, out id))
                        {
                            Id = id;
                        } 
                        break;
                    case "username":
                        UserName = item.Value; 
                        break;
                    
                }
                ToBaseSpecification(item);
            }
        }

        public override void ApplyFilterSpec()
        {
            #region Filter
            Filter = new List<Expression<Func<User, bool>>>();
            if (Id.HasValue && Id != 0)
            {
                Filter.Add(x => x.Id == Id);
            }
            if (!string.IsNullOrEmpty(UserName))
            {
                Filter.Add(x => x.UserName.Contains(UserName));
            }
            #endregion

            #region Order
            if (!string.IsNullOrEmpty(Order))
            {
                var orderItem = Order.Split(" ");
                if (orderItem.Length == 2)
                {
                    Expression<Func<User, object>>? order = null;
                    if (orderItem[0].ToLower() == "id") { order = x => x.Id; }
                    if (orderItem[0].ToLower() == "username") { order = x => x.UserName; }
                    if (orderItem[1].ToLower() == "asc" && order != null) { OrderBy = order; }
                    if (orderItem[1].ToLower() == "desc" && order != null) { OrderByDesc = order; }
                }
            }
            #endregion
        }
    }
}
