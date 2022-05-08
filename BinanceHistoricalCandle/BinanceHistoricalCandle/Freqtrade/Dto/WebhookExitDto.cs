namespace BinanceHistoricalCandle.Freqtrade.Dto
{
    public class WebhookExitDto
    {
        public string TradeId { get; set; }
        public string Exchange { get; set; }
        public string Pair { get; set; }
        public string Direction { get; set; }
        public string Leverage { get; set; }
        public string Gain { get; set; }
        public string Limit { get; set; }
        public string Amount { get; set; }
        public string OpenRate { get; set; }
        public string ProfitAmount { get; set; }
        public string ProfitRatio { get; set; }
        public string StakeCurrency { get; set; }
        public string BaseCurrency { get; set; }
        public string FiatCurrency { get; set; }
        public string ExitReason { get; set; }
        public string OrderType { get; set; }
        public string OpenDate { get; set; }
        public string CloseDate { get; set; }
    }
}
