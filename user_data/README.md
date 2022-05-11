
# Strategies

## Comprar em grandes correcoes
NFIX_BB_RPB


# Gambiarras

## Instalar fredtrade na pasta:
C:\repos\freqtrade_bin
cd c:\repos
git clone https://github.com/freqtrade/freqtrade.git


## Mudar onde carrega historico de trades
C:\repos\freqtrade_bin\.env\Lib\site-packages\ccxt\async_support\base\exchange.py, line 110
Add it:
        if "/klines?" in url and "startTime" not in url:
            url = url.replace("https://api.binance.com/api/v3", "http://localhost:5000")