using System;

namespace HeroesBackend.Entities
{
    public class Hero : BaseEntity
    {
        public string Name { get; set; }
        public string Bio { get; set; }
        public string Image { get; set; }
        public DateTime FirstAppearance { get; set; }
        public long HomeId { get; set; }
        public HeroHome Home { get; set; }
    }
}
