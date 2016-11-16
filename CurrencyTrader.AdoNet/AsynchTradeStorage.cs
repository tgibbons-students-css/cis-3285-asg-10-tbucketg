using CurrencyTrader.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CurrencyTrader.AdoNet
{
    public class AsynchTradeStorage : ITradeStorage
    {
        private readonly ILogger logger;
        AdoNetTradeStorage tradeStorage;

        public AsynchTradeStorage(ILogger logger)
        {
            this.logger = logger;
            tradeStorage = new AdoNetTradeStorage(logger);
        }

        public void Persist(IEnumerable<TradeRecord> trades)
        {
            Task.Run(() => tradeStorage.Persist(trades));
        }
    }
}
