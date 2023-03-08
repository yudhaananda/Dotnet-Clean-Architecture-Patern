using ApplicationCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApplicationCore.Filters
{
    public abstract class BaseFilter<T>
    {
        public int? Page { get; set; }
        public int? Take { get; set; }

        public int Skip()
        {
            if (Take.HasValue && Page.HasValue && Page != 0)
            {
                return (Page.Value - 1) * Take.Value;
            }
            else { return 0; }
        }

        public abstract IQueryable<T> ToSpecification(Dictionary<string, string> filter, IQueryable<T> query);

        protected IQueryable<T> ToBaseSpecification(KeyValuePair<string, string> item, IQueryable<T>query)
        {
            switch (item.Key.ToLower())
            {
                case "Page":
                    int page;
                    if (int.TryParse(item.Value, out page))
                    {
                        Page = page;
                    }
                    break;
                case "take":
                    int take;
                    if (int.TryParse(item.Value, out take))
                    {
                        Take = take;
                    }
                    break;
            }
            if (Page != null && Take != null)
            {
                query.Skip((Page.Value-1) * Take.Value);
                query.Take(Take.Value);
            }
            return query;
        }

    }
}
