using ApiRuleta.Core.Interfaces.Repositories;
using ApiRuleta.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiRuleta.Infraestructure.Data.EntityFrameworkPostgreSQL.Repositories
{
    public class RouletteRepository : RepositoryBase<Roulette>, IRouletteRepository
    {
        public RouletteRepository(RepositoryContextPostgresql repositoryContextPostgresql)
            : base(repositoryContextPostgresql)
        {

        }
    }
}
