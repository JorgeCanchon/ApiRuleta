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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            if (modelBuilder != null)
            {
                modelBuilder.Entity<Roulette>(entity =>
                {
                    entity.Property(b => b.FHCreation)
                    .HasDefaultValueSql("now()");
                });

                modelBuilder.HasAnnotation("Sqlite:Autoincrement", true)
                   .HasAnnotation("Npgsql:ValueGenerationStrategy",
                    Npgsql.EntityFrameworkCore.PostgreSQL.Metadata.NpgsqlValueGenerationStrategy.IdentityAlwaysColumn);
            }
        }
    }
}
