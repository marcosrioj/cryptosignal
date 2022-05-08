﻿using Binance.Net.Enums;
using BinanceHistoricalCandle.Binance.Common;
using BinanceHistoricalCandle.Binance.Infra;
using BinanceHistoricalCandle.Binance.Infra.Entities;
using System.Text.Json;

namespace BinanceHistoricalCandle.Binance.Repositories
{
    public class BinanceInMemoryRepository
    {
        private static readonly Dictionary<string, Dictionary<KlineInterval, object>> _lock
            = new Dictionary<string, Dictionary<KlineInterval, object>>(
                AppStore.Symbols.Select(s => new KeyValuePair<string, Dictionary<KlineInterval, object>>
                (
                    s, AppStore.Intervals.Select(i => new KeyValuePair<KlineInterval, object>(i, new object())).ToDictionary(x => x.Key, x => x.Value)
                )).ToDictionary(x => x.Key, x => x.Value));

        public object[][] GetKLines(string interval,
            int limit, string symbol, long? startTime = null)
        {
            var eInterval = Helper.GetEInterval(interval);
            var query = AppStore.KLines[symbol][eInterval]
                .Where(k =>
                    k.EInterval == eInterval
                    && k.Symbol.ToLower() == symbol.ToLower());

            if (startTime == null)
            {
                query = query.OrderByDescending(k => k.OpenTime);
            }
            else
            {
                if (startTime == 0)
                {
                    query = query.OrderBy(k => k.OpenTime);
                }
                else
                {
                    var stDateTime = Helper.GetDateTime(startTime.Value);
                    query = query.Where(k => k.OpenTime > stDateTime);
                }
            }

            var klines = query
                            .Take(limit)
                            .ToArray();

            var result = klines
                .OrderBy(k => k.OpenTime)
                .Select(k => k.ToDynamicDto())
                .ToArray();

            return result;
        }

        public void AddOrUpdateKLine(string symbol, KlineInterval eInterval, DateTime openTime,
            string open, string high, string low, string close, string volume,
            DateTime closeTime, string quoteAssetVolume, int numberOfTrades,
            string takerBuyBaseAssetVolume, string takerBuyQuoteAssetVolume)
        {
            lock (_lock[symbol][eInterval])
            {
                var isUpdated = false;

                foreach (var k in AppStore.KLines[symbol][eInterval])
                {
                    if (k.Symbol == symbol
                        && k.EInterval == eInterval
                        && k.OpenTime == openTime)
                    {
                        k.Open = open;
                        k.High = high;
                        k.Low = low;
                        k.Close = close;
                        k.Volume = volume;
                        k.QuoteAssetVolume = quoteAssetVolume;
                        k.NumberOfTrades = numberOfTrades;
                        k.TakerBuyBaseAssetVolume = takerBuyBaseAssetVolume;
                        k.TakerBuyQuoteAssetVolume = takerBuyQuoteAssetVolume;

                        isUpdated = true;
                        break;
                    }
                }

                if (!isUpdated)
                {
                    AppStore.KLines[symbol][eInterval].Add(new KLine
                    {
                        Close = close,
                        Volume = volume,
                        QuoteAssetVolume = quoteAssetVolume,
                        NumberOfTrades = numberOfTrades,
                        CloseTime = closeTime,
                        EInterval = eInterval,
                        High = high,
                        Low = low,
                        Open = open,
                        OpenTime = openTime,
                        Symbol = symbol,
                        TakerBuyBaseAssetVolume = takerBuyBaseAssetVolume,
                        TakerBuyQuoteAssetVolume = takerBuyQuoteAssetVolume
                    });

                    if (AppStore.KLines[symbol][eInterval].Count > 1000)
                    {
                        AppStore.KLines[symbol][eInterval] = AppStore.KLines[symbol][eInterval]
                            .OrderByDescending(k => k.OpenTime)
                            .Take(AppStore.Limit)
                            .ToList();
                    }
                }


            }
        }

        public void AddKlinesBinanceToDatabase(Dictionary<KlineInterval, object[][]?> klinesFromBinance, string symbol)
        {
            foreach (var item in klinesFromBinance)
            {
                var klinesToAdd = new List<KLine>();

#pragma warning disable CS8602 // Dereference of a possibly null reference.
#pragma warning disable CS8604 // Possible null reference argument.
                foreach (var k in item.Value)
                {
                    var openTime = Helper.GetDateTime(((JsonElement)k[0]).GetInt64());
                    var closeTime = Helper.GetDateTime(((JsonElement)k[6]).GetInt64());

                    AddOrUpdateKLine(
                        symbol,
                        item.Key,
                        openTime,
                        ((JsonElement)k[1]).GetString(),
                        ((JsonElement)k[2]).GetString(),
                        ((JsonElement)k[3]).GetString(),
                        ((JsonElement)k[4]).GetString(),
                        ((JsonElement)k[5]).GetString(),
                        closeTime,
                        ((JsonElement)k[7]).GetString(),
                        ((JsonElement)k[8]).GetInt32(),
                        ((JsonElement)k[9]).GetString(),
                        ((JsonElement)k[10]).GetString());
                }
#pragma warning restore CS8604 // Possible null reference argument.
#pragma warning restore CS8602 // Dereference of a possibly null reference.
            }
        }
    }
}
