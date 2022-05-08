using BinanceHistoricalCandle.Freqtrade.Dto;
using BinanceHistoricalCandle.Freqtrade.Enum;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace BinanceHistoricalCandle.Controllers
{
    [ApiController]
    [Route("FreqtradeWebhook")]
    public class FreqtradeWebhookController : ControllerBase
    {
        [HttpPost]
        public ActionResult Post([FromBody]WebhookResponseDto request)
        {
            if (request == null || string.IsNullOrEmpty(request.WebhookType))
            {
                return BadRequest();
            }

            var webhookType = (EWebhookType)Enum.Parse(typeof(EWebhookType), request.WebhookType);

            switch (webhookType)
            {
                case EWebhookType.Buy:
                    var buyDto = request.ToBuyDto();
                    break;

                case EWebhookType.BuyCancel:
                    var buyCancelDto = request.ToBuyCancelDto();
                    break;

                case EWebhookType.BuyFill:
                    var buyFillDto = request.ToBuyFillDto();
                    break;

                case EWebhookType.Sell:
                    var sellDto = request.ToSellDto();
                    break;

                case EWebhookType.SellCancel:
                    var sellcancelDto = request.ToSellCancelDto();
                    break;

                case EWebhookType.SellFill:
                    var sellFillDto = request.ToSellFillDto();
                    break;

                case EWebhookType.Status:
                    var status = request.Status;
                    break;

                default:
                    break;
            }

            return Ok();
        }
    }
}