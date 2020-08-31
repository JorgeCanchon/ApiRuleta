using ApiRuleta.Core.Interfaces.Repositories;
using ApiRuleta.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Response OpeningRoulette(long idroulette)
        {
            try
            {
                var entity = _repositoryWrapper.Roulette.FindByCondition(x => x.IDRoulette == idroulette).FirstOrDefault();
                if (entity != null)
                {
                    if (entity.StatusRoulette == null || entity.StatusRoulette)
                        return new Response() { Status = 400, Message = "Operación denegada" };

                    entity.StatusRoulette = true;
                    var result = _repositoryWrapper.Roulette.Update(entity, "IDRoulette");
                    _repositoryWrapper.Save();
                    return result == EntityState.Modified
                         ? new Response() { Status = 200, Message = "Ruleta abierta con éxito" }
                        : new Response() { Status = 400, Message = "Operación fallida" };
                }

                return new Response() { Status = 404, Message = $"No se encontro la ruleta #{idroulette}"};
            }
            catch (Exception e)
            {
                return e.Message.Equals("Column is null")
                    ? new Response() { Status = 404, Message = $"No se encontro la ruleta #{idroulette}" }
                    : new Response() { Status = 500, Message = e.Message, Payload = null };
            }
        }
    }
}
