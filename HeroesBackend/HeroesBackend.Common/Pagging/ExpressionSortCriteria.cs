using HeroesBackend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace HeroesBackend.Common.Pagging
{
    public class ExpressionSortCriteria<T> : ISortCriteria<T>
       where T : BaseEntity
    {
        protected readonly Expression<Func<T, object>> sortExpression;

        public ExpressionSortCriteria(Expression<Func<T, object>> expression, SortDirection direction)
        {
            this.sortExpression = expression;
            this.Direction = direction;
        }

        public SortDirection Direction { get; protected set; }

        public IOrderedQueryable<T> ApplyOrdering(IQueryable<T> query, bool useThenBy)
        {
            IOrderedQueryable<T> result = null;

            //Chequeo que no este ya ordenado, si es asi use ThenBy
            if (useThenBy && typeof(IOrderedQueryable).IsAssignableFrom(query.GetType()))
            {
                IOrderedQueryable<T> orderedQuery = (IOrderedQueryable<T>)query;

                if (this.Direction == SortDirection.Ascending)
                {
                    result = orderedQuery.ThenBy(sortExpression);
                }
                else
                {
                    result = orderedQuery.ThenByDescending(sortExpression);
                }
            }
            else
            {
                if (this.Direction == SortDirection.Ascending)
                {
                    result = query.OrderBy(sortExpression);
                }
                else
                {
                    result = query.OrderByDescending(sortExpression);
                }
            }

            return result;
        }
    }
}
