using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesBackend.Entities
{
    public class HeroHome : BaseEntity
    {
        public string Name { get; set; }
        public string Image { get; set; }

        public List<Hero> Heroes { get; set; }
    }
}
