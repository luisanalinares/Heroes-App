using HeroesBackend.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace HeroesBackend.Common.Pagging
{
    public class QueryBase<T> where T : BaseEntity
    {
        public QueryBase()
        {
            this.Filters = new List<Expression<Func<T, bool>>>();
            this.SortCriterias = new List<ISortCriteria<T>>();
            this.PageNumber = 0;
            this.PageSize = 1000;
        }

        public List<Expression<Func<T, bool>>> Filters { get; protected set; }
        public List<ISortCriteria<T>> SortCriterias { get; protected set; }
        public string IncludeProperties { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public void AddFilter(Expression<Func<T, bool>> filter)
        {
            Filters.Add(filter);
        }

        public void AddSortCriteria(ISortCriteria<T> sortCriteria)
        {
            SortCriterias.Add(sortCriteria);
        }
    }
}
