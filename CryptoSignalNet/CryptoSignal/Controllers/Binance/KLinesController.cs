using CryptoSignal.Binance.Infra;
using CryptoSignal.Binance.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CryptoSignal.Controllers
{
    [ApiController]
    [Route("klines")]
    public class KLinesController : ControllerBase
    {
        private readonly BinanceRepository _binanceRepository;

        public KLinesController(
            BinanceRepository binanceRepository)
        {
            _binanceRepository = binanceRepository;
        }

        [HttpGet]
        public ActionResult Get(string interval, int limit, string symbol, long? startTime = null)
        {
            var result = _binanceRepository.GetKLines(interval, limit, symbol, startTime);

            return Ok(result);
        }

        [HttpGet]
        [Route("CheckAndFix")]
        public async Task<ActionResult> CheckAndFixAsync()
        {
            foreach (var symbol in AppStore.Symbols)
            {
                var symbolAppStoreValid = _binanceRepository.IsAppStoreValid(symbol);
                if (!symbolAppStoreValid)
                {
                    await _binanceRepository.AddKlinesFromBinance(symbol);
                }
            }

            return Ok();
        }
    }
}