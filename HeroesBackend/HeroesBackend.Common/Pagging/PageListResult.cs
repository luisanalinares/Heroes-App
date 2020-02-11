using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesBackend.Common.Pagging
{
    public class PagedListResult<T>
    {
        public bool HasNext { get; set; }
        public bool HasPrevious { get; set; }
        public long Count { get; set; }
        public List<T> Entities { get; set; }
    }
}
