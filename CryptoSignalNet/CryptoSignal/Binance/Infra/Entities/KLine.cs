using Binance.Net.Enums;
using CryptoSignal.Binance.Common;

namespace CryptoSignal.Binance.Infra.Entities
{
    public class KLine
    {
        public string Symbol { get; set; }
        public KlineInterval EInterval { get; set; }
        public DateTime OpenTime { get; set; }
        public string Open { get; set; }
        public string High { get; set; }
        public string Low { get; set; }
        public string Close { get; set; }
        public string Volume { get; set; }
        public DateTime CloseTime { get; set; }
        public string QuoteAssetVolume { get; set; }
        public int NumberOfTrades { get; set; }
        public string TakerBuyBaseAssetVolume { get; set; }
        public string TakerBuyQuoteAssetVolume { get; set; }
    }

    public static class KLineExtensions
    {
        public static dynamic[] ToDynamicDto(this KLine kline)
        {
            var openTime = Helper.GetTime(kline.OpenTime);
            var closeTime = Helper.GetTime(kline.CloseTime);

#pragma warning disable CS8601 // Possible null reference assignment.
            return new dynamic[]
            {
                openTime,
                kline.Open,
                kline.High,
                kline.Low,
                kline.Close,
                kline.Volume,
                closeTime,
                kline.QuoteAssetVolume,
                kline.NumberOfTrades,
                kline.TakerBuyBaseAssetVolume,
                kline.TakerBuyQuoteAssetVolume
            };
#pragma warning restore CS8601 // Possible null reference assignment.
        }
    }
}
