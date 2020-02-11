using HeroesBackend.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HeroesBackend.Queries
{
    public class PaginatedQuery
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string OrderBy { get; set; }
        public SortDirection SortDirection { get; set; }
    }
}
