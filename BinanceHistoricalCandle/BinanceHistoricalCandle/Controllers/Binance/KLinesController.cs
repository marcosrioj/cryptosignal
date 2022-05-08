using BinanceHistoricalCandle.Binance.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BinanceHistoricalCandle.Controllers
{
    [ApiController]
    [Route("klines")]
    public class KLinesController : ControllerBase
    {
        private readonly BinanceInMemoryRepository _binanceRepository;

        public KLinesController(
            BinanceInMemoryRepository binanceRepository)
        {
            _binanceRepository = binanceRepository;
        }

        [HttpGet]
        public ActionResult Get(string interval, int limit, string symbol, long? startTime = null)
        {
            var result = _binanceRepository.GetKLines(interval, limit, symbol, startTime);

            return Ok(result);
        }
    }
}