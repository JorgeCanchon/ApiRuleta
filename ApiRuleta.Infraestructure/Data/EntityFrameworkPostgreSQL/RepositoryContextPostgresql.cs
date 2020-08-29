using ApiRuleta.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiRuleta.Infraestructure.Data.EntityFrameworkPostgreSQL
{
    public class RepositoryContextPostgresql : DbContext
    {
        public RepositoryContextPostgresql()
        {

        }
        public RepositoryContextPostgresql(DbContextOptions options)
           : base(options)
        {

        }

        public virtual DbSet<Roulette> Roulettes { get; set; }
    }
}
