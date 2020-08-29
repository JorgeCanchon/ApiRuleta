using ApiRuleta.Core.Interfaces.Repositories;
using ApiRuleta.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiRuleta.Core.UseCases.Roulette
{
    public class RouletteInteractor : IRouletteInteractor
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public RouletteInteractor(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper ?? throw new ArgumentNullException(nameof(repositoryWrapper));
        }

        public Response InsertRoulette(Models.Roulette roulette)
        {
            try
            {
                var entity = _repositoryWrapper.Roulette.Create(roulette);
                _repositoryWrapper.Save();

                if(entity.IDRoulette >= 0)
                    return new Response() { Status = 201, Message = "Ruleta creada con éxito" , Payload = entity.IDRoulette };
                else
                    return new Response() { Status = 400, Message = "No se pudo crear la ruleta", Payload = null };
            }
            catch(Exception e) 
            {
                return new Response() { Status = 500, Message = e.Message, Payload = null };
            }
        }
    }
}
