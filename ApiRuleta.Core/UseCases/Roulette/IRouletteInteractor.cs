using System;
using System.Collections.Generic;
using System.Text;
using ApiRuleta.Core.Models;

namespace ApiRuleta.Core.UseCases.Roulette
{
    public interface IRouletteInteractor
    {
        Response InsertRoulette(Models.Roulette roulette);
        Response OpeningRoulette(long idroulette);
    }
}
