using ApiRuleta.Core.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiRuleta.Infraestructure.Data.EntityFrameworkPostgreSQL
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private IRouletteRepository roulette;

        private readonly RepositoryContextPostgresql _repositoryContextPostgresql;

        public RepositoryWrapper(RepositoryContextPostgresql repositoryContextPostgresql)
        {
            _repositoryContextPostgresql = repositoryContextPostgresql ?? throw new ArgumentNullException(nameof(repositoryContextPostgresql));
        }

        public IRouletteRepository Roulette
        {
            get
            {
                if (roulette == null)
                    roulette = new RouletteRepository(_repositoryContextPostgresql);
                return roulette;
            }
        }

        public void Save()
        {
            _repositoryContextPostgresql.SaveChanges();
        }
    }
}
