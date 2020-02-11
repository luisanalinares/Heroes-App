using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesBackend.Entities
{
    public abstract class BaseEntity
    {
        public long Id { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
    }
}
