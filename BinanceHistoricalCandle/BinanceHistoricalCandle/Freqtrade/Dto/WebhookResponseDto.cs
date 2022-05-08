using BinanceHistoricalCandle.Freqtrade.Enum;

namespace BinanceHistoricalCandle.Freqtrade.Dto
{
    public class WebhookResponseDto
    {
        public string WebhookType { get; set; }
        public string? TradeId { get; set; }
        public string? Exchange { get; set; }
        public string? Pair { get; set; }
        public string? Direction { get; set; }
        public string? Leverage { get; set; }
        public string? Limit { get; set; }
        public string? Amount { get; set; }
        public string? OpenDate { get; set; }
        public string? StakeAmount { get; set; }
        public string? BaseCurrency { get; set; }
        public string? FiatCurrency { get; set; }
        public string? OrderType { get; set; }
        public string? CurrentRate { get; set; }
        public string? EnterTag { get; set; }
        public string? OpenRate { get; set; }
        public string? StakeCurrency { get; set; }
        public string? ProfitAmount { get; set; }
        public string? ProfitRatio { get; set; }
        public string? ExitReason { get; set; }
        public string? CloseDate { get; set; }
        public string? Gain { get; set; }
        public string? CloseRate { get; set; }
        public string? Status { get; set; }
    }

    public static class WebhookResponseDtoExtensions
    {
        public static WebhookEntryDto ToBuyDto(this WebhookResponseDto input)
        {
            return new WebhookEntryDto
            {
                BaseCurrency = input.BaseCurrency,
                CurrentRate = input.CurrentRate,
                Direction = input.Direction,
                EnterTag = input.EnterTag,
                Exchange = input.Exchange,
                FiatCurrency = input.FiatCurrency,
                OpenDate = input.OpenDate,
                OpenRate = input.OpenRate,
                OrderType = input.OrderType,
                Pair = input.Pair,
                StakeAmount = input.StakeAmount,
                StakeCurrency = input.StakeCurrency,
                TradeId = input.TradeId,
                Leverage = input.Leverage,
                Amount = input.Amount
            };
        }

        public static WebhookEntryCancelDto ToBuyCancelDto(this WebhookResponseDto input)
        {
            return new WebhookEntryCancelDto
            {
                BaseCurrency = input.BaseCurrency,
                CurrentRate = input.CurrentRate,
                Direction = input.Direction,
                EnterTag = input.EnterTag,
                Exchange = input.Exchange,
                FiatCurrency = input.FiatCurrency,
                OpenDate = input.OpenDate,
                OrderType = input.OrderType,
                Pair = input.Pair,
                StakeAmount = input.StakeAmount,
                TradeId = input.TradeId,
                Amount = input.Amount,
                Leverage = input.Leverage,
                Limit = input.Limit,
                StakeCurrency = input.StakeCurrency
            };
        }

        public static WebhookEntryFillDto ToBuyFillDto(this WebhookResponseDto input)
        {
            return new WebhookEntryFillDto
            {
                BaseCurrency = input.BaseCurrency,
                CurrentRate = input.CurrentRate,
                Direction = input.Direction,
                EnterTag = input.EnterTag,
                Exchange = input.Exchange,
                FiatCurrency = input.FiatCurrency,
                OpenDate = input.OpenDate,
                OrderType = input.OrderType,
                Pair = input.Pair,
                StakeAmount = input.StakeAmount,
                TradeId = input.TradeId,
                Amount = input.Amount,
                Leverage = input.Leverage,
                OpenRate = input.OpenRate,
                StakeCurrency = input.StakeCurrency
            };
        }

        public static WebhookExitDto ToSellDto(this WebhookResponseDto input)
        {
            return new WebhookExitDto
            {
                BaseCurrency = input.BaseCurrency,
                Direction = input.Direction,
                Exchange = input.Exchange,
                FiatCurrency = input.FiatCurrency,
                OpenDate = input.OpenDate,
                OpenRate = input.OpenRate,
                OrderType = input.OrderType,
                Pair = input.Pair,
                StakeCurrency = input.StakeCurrency,
                TradeId = input.TradeId,
                Amount = input.Amount,
                Limit = input.Limit,
                Leverage = input.Leverage,
                CloseDate = input.CloseDate,
                Gain = input.Gain,
                ProfitAmount = input.ProfitAmount,
                ProfitRatio = input.ProfitRatio,
                ExitReason = input.ExitReason
            };
        }

        public static WebhookExitCancelDto ToSellCancelDto(this WebhookResponseDto input)
        {
            return new WebhookExitCancelDto
            {
                BaseCurrency = input.BaseCurrency,
                Direction = input.Direction,
                Exchange = input.Exchange,
                FiatCurrency = input.FiatCurrency,
                OpenDate = input.OpenDate,
                OpenRate = input.OpenRate,
                OrderType = input.OrderType,
                Pair = input.Pair,
                StakeCurrency = input.StakeCurrency,
                TradeId = input.TradeId,
                Amount = input.Amount,
                Limit = input.Limit,
                Leverage = input.Leverage,
                CloseDate = input.CloseDate,
                Gain = input.Gain,
                ProfitAmount = input.ProfitAmount,
                ProfitRatio = input.ProfitRatio,
                CurrentRate = input.CurrentRate,
                ExitReason = input.ExitReason
            };
        }

        public static WebhookExitFillDto ToSellFillDto(this WebhookResponseDto input)
        {
            return new WebhookExitFillDto
            {
                BaseCurrency = input.BaseCurrency,
                Direction = input.Direction,
                Exchange = input.Exchange,
                FiatCurrency = input.FiatCurrency,
                OpenDate = input.OpenDate,
                OpenRate = input.OpenRate,
                OrderType = input.OrderType,
                Pair = input.Pair,
                StakeCurrency = input.StakeCurrency,
                TradeId = input.TradeId,
                Amount = input.Amount,
                Leverage = input.Leverage,
                CloseDate = input.CloseDate,
                Gain = input.Gain,
                ProfitAmount = input.ProfitAmount,
                ProfitRatio = input.ProfitRatio,
                ExitReason = input.ExitReason,
                CloseRate = input.CloseRate,
                CurrentRate = input.CurrentRate
            };
        }
    }
}
