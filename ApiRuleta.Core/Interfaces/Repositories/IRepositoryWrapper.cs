using System;
using System.Collections.Generic;
using System.Text;

namespace ApiRuleta.Core.Interfaces.Repositories
{
    public interface IRepositoryWrapper
    {
        IRouletteRepository Roulette { get; }
        void Save();
    }
}
