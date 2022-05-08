
# Strategies

## Comprar em grandes correcoes
NFIX_BB_RPB


# Gambiarras

## Mudar onde carrega historico de trades
C:\repos\freqtrade_bin\.env\Lib\site-packages\ccxt\async_support\base\exchange.py, line 110
Add it:
        if "/klines?" in url and "startTime" not in url:
            url.replace("https://api.binance.com/api/v3", "http://localhost:5000")

python setup.py install
