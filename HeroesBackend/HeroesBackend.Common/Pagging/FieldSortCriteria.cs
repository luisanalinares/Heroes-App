using HeroesBackend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace HeroesBackend.Common.Pagging
{
    public class FieldSortCriteria<T> : ISortCriteria<T>
        where T : BaseEntity
    {
        protected readonly string propertyName;

        public FieldSortCriteria(string propertyName, SortDirection direction)
        {
            this.propertyName = propertyName;
            this.Direction = direction;
        }

        public SortDirection Direction { get; protected set; }

        public IOrderedQueryable<T> ApplyOrdering(IQueryable<T> query, bool useThenBy)
        {
            Type entityType = typeof(T);
            string methodName;

            //Chequeo que no este ya ordenado, si es asi use ThenBy
            if (useThenBy && typeof(IOrderedQueryable).IsAssignableFrom(query.GetType()))
                methodName = "ThenBy";
            else
                methodName = "OrderBy";

            if (this.Direction == SortDirection.Descending)
                methodName += "Descending";

            PropertyInfo propertyInfo = entityType.GetProperty(propertyName);
            ParameterExpression arg = Expression.Parameter(entityType, "x");
            MemberExpression property = Expression.Property(arg, propertyName);
            LambdaExpression selector = Expression.Lambda(property, new ParameterExpression[] { arg });

            Type enumarableType = typeof(Queryable);
            MethodInfo method = enumarableType.GetMethods()
                .Where(m => m.Name == methodName && m.IsGenericMethodDefinition)
                .Where(m =>
                {
                    var parameters = m.GetParameters().ToList();
                    return parameters.Count == 2;
                }).Single();

            MethodInfo genericMethod = method
                .MakeGenericMethod(entityType, propertyInfo.PropertyType);

            var newQuery = (IOrderedQueryable<T>)genericMethod
                .Invoke(genericMethod, new object[] { query, selector });

            return newQuery;
        }
    }
}
