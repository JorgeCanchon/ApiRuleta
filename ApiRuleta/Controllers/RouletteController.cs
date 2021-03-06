﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiRuleta.Core.Models;
using ApiRuleta.Core.UseCases.Roulette;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ApiRuleta.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RouletteController : ControllerBase
    {
        private readonly IRouletteInteractor _rouletteInteractor;

        public RouletteController(IRouletteInteractor rouletteInteractor)
        {
            _rouletteInteractor = rouletteInteractor;
        }

        [HttpPost("opening/{idroulette}")]
        public IActionResult Post(long idroulette)
        {
            Response response = _rouletteInteractor.OpeningRoulette(idroulette);

            switch (response.Status)
            {
                case 200:
                    return Ok(response);
                case 400:
                    return BadRequest(response);
                case 404:
                    return NotFound(response);
                case 500:
                    return Problem(response.Message);
                default:
                    return Ok();
            }
        }

        [HttpPost]
        public IActionResult Post(Roulette roulette)
        {
            Response response = _rouletteInteractor.InsertRoulette(roulette);
            switch (response.Status)
            {
                case 201:
                    return Ok(response);
                case 400:
                    return BadRequest(response);
                case 500:
                    return Problem(response.Message);
                default:
                    return Ok();
            }
        }
    }
}
