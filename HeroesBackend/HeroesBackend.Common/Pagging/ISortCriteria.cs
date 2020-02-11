using HeroesBackend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HeroesBackend.Common.Pagging
{
    public interface ISortCriteria<T> where T : BaseEntity
    {
        SortDirection Direction { get; }
        IOrderedQueryable<T> ApplyOrdering(IQueryable<T> query, bool useThenBy);
    }
}
