using HeroesBackend.Common.Pagging;
using HeroesBackend.Entities;
using HeroesBackend.Repository;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Reflection;

namespace HeroesBackend.BusinessLayer
{
    public class HeroBusinessLayer
    {
        private GenericRepository<Hero> repository;

        public HeroBusinessLayer()
        {
            this.repository = new GenericRepository<Hero>();
        }

        public List<Hero> GetAll()
        {
            return this.repository.GetAll();
        }

        public PagedListResult<Hero> GetPaginated(int pageNumber, int pageSize, string sortby, SortDirection sortDirection)
        {
            QueryBase<Hero> query = new QueryBase<Hero>
            {
                PageNumber = pageNumber,
                PageSize = pageSize                
            };

            var sortCriterias = sortby.Split(',');

            foreach (var sortField in sortCriterias)
            {
                query.SortCriterias.Add(new FieldSortCriteria<Hero>(sortField, sortDirection));
            }

            return this.repository.GetPaginated(query);
        }

        public Hero GetOne(int id)
        {
            Hero result = default;
             
            if (id > 0)
            {
                result = repository.GetOne(id, h => h.Home);
                result.Home.Heroes = null;
            }

            return result;
        }

        public List<Hero> SearchHeroByName(string term)
        {
            var value = term.ToLower();

            return repository.GetByCriteria(h => h.Name.ToLower().Contains(value));
        }

        public bool Save(Hero hero)
        {
            bool result = false;
            
            if (hero != null)
            {
                result = this.repository.Save(hero);
            }

            return result;
        }
    }
}
