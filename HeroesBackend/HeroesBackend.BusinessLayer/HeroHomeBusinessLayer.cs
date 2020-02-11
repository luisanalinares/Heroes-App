using HeroesBackend.Entities;
using HeroesBackend.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace HeroesBackend.BusinessLayer
{
    public class HeroHomeBusinessLayer
    {
        private GenericRepository<HeroHome> repository;

        public HeroHomeBusinessLayer()
        {
            this.repository = new GenericRepository<HeroHome>();
        }

        public List<HeroHome> GetAll()
        {
            return this.repository.GetAll();
        }
    }
}
