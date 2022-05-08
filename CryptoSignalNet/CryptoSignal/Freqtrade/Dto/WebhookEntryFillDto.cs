namespace CryptoSignal.Freqtrade.Dto
{
    public class WebhookEntryFillDto
    {
        public string TradeId { get; set; }
        public string Exchange { get; set; }
        public string Pair { get; set; }
        public string Direction { get; set; }
        public string Leverage { get; set; }
        public string OpenRate { get; set; }
        public string Amount { get; set; }
        public string OpenDate { get; set; }
        public string StakeAmount { get; set; }
        public string StakeCurrency { get; set; }
        public string BaseCurrency { get; set; }
        public string FiatCurrency { get; set; }
        public string OrderType { get; set; }
        public string CurrentRate { get; set; }
        public string EnterTag { get; set; }
    }
}
