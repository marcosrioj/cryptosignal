using Binance.Net.Enums;

namespace BinanceHistoricalCandle.Binance.Common
{
    public static class Helper
    {
        public static long GetTime(DateTime dateTime)
        {
            var time = (dateTime - new DateTime(1970, 1, 1));
            return (long)(time.TotalMilliseconds);
        }

        public static DateTime GetDateTime(long time)
        {
            return new DateTime(1970, 01, 01).AddMilliseconds(time);
        }

        public static string GetInterval(KlineInterval klineInterval)
        {
            switch (klineInterval)
            {
                case KlineInterval.OneMinute:
                    return "1m";
                case KlineInterval.ThreeMinutes:
                    return "3m";
                case KlineInterval.FiveMinutes:
                    return "5m";
                case KlineInterval.FifteenMinutes:
                    return "15m";
                case KlineInterval.ThirtyMinutes:
                    return "30m";
                case KlineInterval.OneHour:
                    return "1h";
                case KlineInterval.TwoHour:
                    return "2h";
                case KlineInterval.FourHour:
                    return "4h";
                case KlineInterval.TwelveHour:
                    return "12h";
                case KlineInterval.OneDay:
                    return "1d";
                case KlineInterval.OneWeek:
                    return "1w";
                case KlineInterval.OneMonth:
                    return "1m";
                default:
                    return "1m";
            }
        }

        public static double GetMilleseconds(KlineInterval eInterval)
        {
            switch (eInterval)
            {
                case KlineInterval.OneMinute:
                    return TimeSpan.FromMinutes(1).TotalMilliseconds;
                case KlineInterval.ThreeMinutes:
                    return TimeSpan.FromMinutes(3).TotalMilliseconds;
                case KlineInterval.FiveMinutes:
                    return TimeSpan.FromMinutes(5).TotalMilliseconds;
                case KlineInterval.FifteenMinutes:
                    return TimeSpan.FromMinutes(15).TotalMilliseconds;
                case KlineInterval.ThirtyMinutes:
                    return TimeSpan.FromMinutes(30).TotalMilliseconds;
                case KlineInterval.OneHour:
                    return TimeSpan.FromHours(1).TotalMilliseconds;
                case KlineInterval.TwoHour:
                    return TimeSpan.FromHours(2).TotalMilliseconds;
                case KlineInterval.FourHour:
                    return TimeSpan.FromHours(4).TotalMilliseconds;
                case KlineInterval.TwelveHour:
                    return TimeSpan.FromHours(12).TotalMilliseconds;
                case KlineInterval.OneDay:
                    return TimeSpan.FromDays(1).TotalMilliseconds;
                case KlineInterval.OneWeek:
                    return TimeSpan.FromDays(7).TotalMilliseconds;
                case KlineInterval.OneMonth:
                    return TimeSpan.FromDays(30).TotalMilliseconds;
                default:
                    return TimeSpan.FromMinutes(1).TotalMilliseconds;
            }
        }

        public static KlineInterval GetEInterval(string interval)
        {
            switch (interval)
            {
                case "1m":
                    return KlineInterval.OneMinute;
                case "3m":
                    return KlineInterval.ThreeMinutes;
                case "5m":
                    return KlineInterval.FiveMinutes;
                case "15m":
                    return KlineInterval.FifteenMinutes;
                case "30m":
                    return KlineInterval.ThirtyMinutes;
                case "1h":
                    return KlineInterval.OneHour;
                case "2h":
                    return KlineInterval.TwoHour;
                case "4h":
                    return KlineInterval.FourHour;
                case "12h":
                    return KlineInterval.TwelveHour;
                case "1d":
                    return KlineInterval.OneDay;
                case "1w":
                    return KlineInterval.OneWeek;
                case "1M":
                    return KlineInterval.OneMonth;
                default:
                    return KlineInterval.OneMinute;
            }
        }
    }
}
