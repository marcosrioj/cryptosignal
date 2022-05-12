using Binance.Net.Clients;
using Binance.Net.Interfaces;
using CryptoExchange.Net.Sockets;
using CryptoSignal.Binance.Infra;
using CryptoSignal.Binance.Repositories;

namespace CryptoSignal.Binance.HostedService
{
    public class BinanceHostedService : IHostedService
    {
        private readonly BinanceRepository _binanceRepository;
        private readonly ILogger<BinanceHostedService> _logger;

        public BinanceHostedService(ILogger<BinanceHostedService> logger, IServiceProvider serviceProvider)
        {
            _binanceRepository = serviceProvider.CreateScope().ServiceProvider.GetRequiredService<BinanceRepository>();
            _logger = logger;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            InitAsync();
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private async Task InitAsync()
        {
            var symbolsExecuted = 0;
            var totalSymbols = AppStore.Symbols.Length;

            foreach (var symbol in AppStore.Symbols)
            {
                await InitAsync(symbol);

                symbolsExecuted++;
                _logger.LogCritical($"{symbolsExecuted} executed from {totalSymbols}. Symbol: {symbol}");
            }
        }

        public async Task InitAsync(string symbol)
        {
            await _binanceRepository.AddKlinesFromBinance(symbol);

            await SubscribeOnBinanceAsync(symbol);
        }

        private async Task SubscribeOnBinanceAsync(string symbol)
        {
            var client = new BinanceSocketClient();
            var result = await client.SpotStreams.SubscribeToKlineUpdatesAsync(
                symbol,
                AppStore.Intervals,
                OnMessage);
        }

        private async void OnMessage(DataEvent<IBinanceStreamKlineData> data)
        {
            _binanceRepository.AddOrUpdateKLine(
                symbol: data.Data.Symbol,
                eInterval: data.Data.Data.Interval,
                openTime: data.Data.Data.OpenTime,
                open: data.Data.Data.OpenPrice.ToString(),
                high: data.Data.Data.HighPrice.ToString(),
                low: data.Data.Data.LowPrice.ToString(),
                close: data.Data.Data.ClosePrice.ToString(),
                volume: data.Data.Data.Volume.ToString(),
                closeTime: data.Data.Data.CloseTime,
                quoteAssetVolume: data.Data.Data.QuoteVolume.ToString(),
                numberOfTrades: data.Data.Data.TradeCount,
                takerBuyBaseAssetVolume: data.Data.Data.TakerBuyBaseVolume.ToString(),
                takerBuyQuoteAssetVolume: data.Data.Data.TakerBuyQuoteVolume.ToString());
        }
    }
}
