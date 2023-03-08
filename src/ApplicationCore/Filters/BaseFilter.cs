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
        #region JsonIgnore Properties
        [JsonIgnore]
        public List<Expression<Func<T, bool>>>? Filter { get; set; }
        [JsonIgnore]
        public Expression<Func<T, Object>>? OrderBy { get; set; }
        [JsonIgnore]
        public Expression<Func<T, Object>>? OrderByDesc { get; set; }
        #endregion
        public string? Order { get; set; }
        public int? Page { get; set; }
        public int? Take { get; set; }
        public bool? Include { get; set; }

        public int Skip()
        {
            if (Take.HasValue && Page.HasValue && Page != 0)
            {
                return (Page.Value - 1) * Take.Value;
            }
            else { return 0; }
        }

        public abstract void ApplyFilterSpec();
        public abstract void ToSpecification(Dictionary<string, string> filter);

        protected void ToBaseSpecification(KeyValuePair<string, string> item)
        {
            switch (item.Key.ToLower())
            {
                case "order":
                    Order = item.Value;
                    break;
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
                case "include":
                    bool include;
                    if (bool.TryParse(item.Value, out include))
                    {
                        Include = include;
                    }
                    break;
            }
        }

    }
}
