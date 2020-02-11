using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using HeroesBackend.Entities;
using HeroesBackend.Common.Pagging;

namespace HeroesBackend.Repository
{
    public class GenericRepository<T> where T : BaseEntity
    {
        public GenericRepository()
        {
           
        }

        public bool Save(T entity)
        {
            bool result = true;
            try
            {
                using (var context = new AppContext())
                {
                    entity.CreateDate = DateTime.Now;
                    context.Add<T>(entity);
                    context.SaveChanges();
                }
            }
            catch
            {
                result = false;
            }

            return result;
        }

        public List<T> GetAll()
        {
            List<T> result = null;

            using (var context = new AppContext())
            {
                result = context.Set<T>().ToList();
            }

            return result;
        }

        public List<T> GetByCriteria(Func<T, bool> expression)
        {
            List<T> result = null;

            using (var context = new AppContext())
            {
                result = context.Set<T>().Where(expression).ToList();
            }

            return result;
        }

        public T GetOne(int id, params Expression<Func<T, object>>[] navigationProperties)
        {
            T result = null;

            using (var context = new AppContext())
            {
                IQueryable<T> dbQuery = context.Set<T>();

                dbQuery = navigationProperties.Aggregate(dbQuery,
                       (current, navigationProperty) => current.Include<T, object>(navigationProperty));

                result = dbQuery.FirstOrDefault(h => h.Id == id);
            }

            return result;
        }

        public PagedListResult<T> GetPaginated(QueryBase<T> query)
        {
            PagedListResult<T> result = new PagedListResult<T>();

            using (var context = new AppContext())
            {
                IQueryable<T> dbQuery = context.Set<T>();
                dbQuery = ManageFilters(query, dbQuery);
                dbQuery = ManageIncludeProperties(query, dbQuery);
                dbQuery = ManageSortCriterias(query, dbQuery);
                result = GetTheResult(query, dbQuery);           
            }

            return result;
        }

        private IQueryable<T> ManageSortCriterias(QueryBase<T> searchQuery, IQueryable<T> dbQuery)
        {
            if (searchQuery.SortCriterias != null && searchQuery.SortCriterias.Count > 0)
            {
                ISortCriteria<T> sortCriteria = searchQuery.SortCriterias[0];
                IOrderedQueryable<T> orderedSequence = sortCriteria.ApplyOrdering(dbQuery, false);

                if (searchQuery.SortCriterias.Count > 1)
                {
                    for (var i = 1; i < searchQuery.SortCriterias.Count; i++)
                    {
                        ISortCriteria<T> sc = searchQuery.SortCriterias[i];
                        orderedSequence = sc.ApplyOrdering(orderedSequence, true);
                    }
                }
                dbQuery = orderedSequence;
            }
            else
            {
                dbQuery = ((IOrderedQueryable<T>)dbQuery).OrderBy(x => x.Id);
            }

            return dbQuery;
        }

        protected virtual IQueryable<T> ManageFilters(QueryBase<T> searchQuery, IQueryable<T> dbQuery)
        {
            if (searchQuery.Filters != null && searchQuery.Filters.Count > 0)
            {
                foreach (Expression<Func<T, bool>> filterClause in searchQuery.Filters)
                {
                    dbQuery = dbQuery.Where(filterClause);
                }
            }
            return dbQuery;
        }

        protected virtual IQueryable<T> ManageIncludeProperties(QueryBase<T> searchQuery, IQueryable<T> sequence)
        {
            if (!string.IsNullOrWhiteSpace(searchQuery.IncludeProperties))
            {
                string[] properties = searchQuery.IncludeProperties.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);

                sequence = properties.Aggregate(sequence, (current, includeProperty) => current.Include(includeProperty));
            }
            return sequence;
        }

        private PagedListResult<T> GetTheResult(QueryBase<T> searchQuery, IQueryable<T> dbQuery)
        {
            //Contando la cantidad de resultados
            int resultCount = dbQuery.Count();
            int indexOff = (searchQuery.PageNumber - 1) * searchQuery.PageSize;

            List<T> result = (searchQuery.PageSize > 0)
                                ? (dbQuery.Skip(indexOff).Take(searchQuery.PageSize).ToList())
                                : (dbQuery.ToList());


            bool hasNext = (searchQuery.PageNumber > 0 || searchQuery.PageSize > 0) && (searchQuery.PageNumber + searchQuery.PageSize < resultCount);
            return new PagedListResult<T>()
            {
                Entities = result,
                HasNext = hasNext,
                HasPrevious = (searchQuery.PageNumber > 0),
                Count = resultCount
            };
        }
    }
}
