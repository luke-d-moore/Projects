﻿using AutoTradeSystem.Server.Services;
using Microsoft.AspNetCore.Mvc;
using AutoTradeSystem.Server.Dtos;
using Swashbuckle.AspNetCore.Annotations;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AutoTradeSystem.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TradingStrategyController : ControllerBase
    {
        private readonly ILogger<TradingStrategyController> _logger;
        private readonly IAutoTradingStrategyService _autoTradingStrategyService;

        public TradingStrategyController(ILogger<TradingStrategyController> logger, IAutoTradingStrategyService autoTradingStrategyService)//, IHostedServiceAccessor<IAutoTradingStrategyService> autoTradingStrategyService) 
        {
            _logger = logger;
            _autoTradingStrategyService = autoTradingStrategyService;
        }

        // GET: api/<TradingStrategyController>
        [HttpGet]
        public IDictionary<string, TradingStrategy> Get()
        {
            return _autoTradingStrategyService.GetStrategies();
        }

        // POST api/<TradingStrategyController>
        [HttpPost]
        [SwaggerOperation(nameof(AddStrategy))]
        [SwaggerResponse(StatusCodes.Status200OK, "OK", typeof(string))]
        public async Task<IActionResult> AddStrategy(TradingStrategyDto tradingStrategy)
        {
            if (tradingStrategy == null) return BadRequest("Invalid Strategy");
            if (tradingStrategy.Ticker == null || (tradingStrategy.Ticker.Length > 5 || tradingStrategy.Ticker.Length < 3))
            {
                _logger.LogError("Invalid Ticker {0}", tradingStrategy.Ticker);
                return BadRequest("Invalid Ticker");
            }
            var added = await _autoTradingStrategyService.AddStrategy(tradingStrategy);
            if (added)
            {
                _logger.LogInformation("Stretegy Added Successfully");
            }
            else
            {
                _logger.LogError("Failed To Add Stretagy {@strategyDetails}", tradingStrategy);
            }
            return added ? Ok(added) : BadRequest("Failed To Add Strategy");
        }

        // DELETE api/<TradingStrategyController>/5
        [HttpDelete("{id}")]
        [SwaggerOperation(nameof(DeleteStrategy))]
        [SwaggerResponse(StatusCodes.Status200OK, "OK")]
        [SwaggerResponse(StatusCodes.Status404NotFound, "Not Found")]
        public async Task<IActionResult> DeleteStrategy(string id)
        {
            var removed = await _autoTradingStrategyService.RemoveStrategy(id);
            if (removed)
            {
                _logger.LogInformation("Stretegy Removed Successfully");
            }
            else
            {
                _logger.LogError("Failed To Remove Stretagy {0}", id);
            }
            return removed ? Ok(removed) : NotFound();
        }
    }
}
