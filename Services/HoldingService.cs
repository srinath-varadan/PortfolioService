public class HoldingService
{
  private List<Holding> _holdings = new()
    {
        new Holding { Id = 1, Name = "Apple Inc.", AssetClass = "Stocks", Ticker = "AAPL", Quantity = 50, PurchasePrice = 145.00, CurrentPrice = 160.00, MarketValue = 8000, GainLoss = 750, Weight = 25 },
        new Holding { Id = 2, Name = "US Treasury Bond", AssetClass = "Bonds", Ticker = "USTB10Y", Quantity = 30, PurchasePrice = 98.00, CurrentPrice = 100.00, MarketValue = 3000, GainLoss = 60, Weight = 10 },
        new Holding { Id = 3, Name = "Microsoft Corp.", AssetClass = "Stocks", Ticker = "MSFT", Quantity = 40, PurchasePrice = 250.00, CurrentPrice = 280.00, MarketValue = 11200, GainLoss = 1200, Weight = 30 },
        new Holding { Id = 4, Name = "Tesla Inc.", AssetClass = "Stocks", Ticker = "TSLA", Quantity = 20, PurchasePrice = 600.00, CurrentPrice = 650.00, MarketValue = 13000, GainLoss = 1000, Weight = 15 },
        new Holding { Id = 5, Name = "Amazon.com Inc.", AssetClass = "Stocks", Ticker = "AMZN", Quantity = 15, PurchasePrice = 3200.00, CurrentPrice = 3300.00, MarketValue = 49500, GainLoss = 1500, Weight = 20 },
        new Holding { Id = 6, Name = "Google LLC", AssetClass = "Stocks", Ticker = "GOOGL", Quantity = 10, PurchasePrice = 2800.00, CurrentPrice = 2900.00, MarketValue = 29000, GainLoss = 1000, Weight = 10 },
        new Holding { Id = 7, Name = "Coca-Cola Co.", AssetClass = "Stocks", Ticker = "KO", Quantity = 100, PurchasePrice = 55.00, CurrentPrice = 60.00, MarketValue = 6000, GainLoss = 500, Weight = 5 },
        new Holding { Id = 8, Name = "Pfizer Inc.", AssetClass = "Stocks", Ticker = "PFE", Quantity = 80, PurchasePrice = 40.00, CurrentPrice = 45.00, MarketValue = 3600, GainLoss = 400, Weight = 5 },
        new Holding { Id = 9, Name = "Bitcoin", AssetClass = "Cryptocurrency", Ticker = "BTC", Quantity = 1, PurchasePrice = 45000.00, CurrentPrice = 50000.00, MarketValue = 50000, GainLoss = 5000, Weight = 10 },
        new Holding { Id = 10, Name = "Ethereum", AssetClass = "Cryptocurrency", Ticker = "ETH", Quantity = 5, PurchasePrice = 3000.00, CurrentPrice = 3200.00, MarketValue = 16000, GainLoss = 1000, Weight = 5 },
        new Holding { Id = 11, Name = "SPDR S&P 500 ETF", AssetClass = "ETFs", Ticker = "SPY", Quantity = 25, PurchasePrice = 400.00, CurrentPrice = 420.00, MarketValue = 10500, GainLoss = 500, Weight = 10 },
        new Holding { Id = 12, Name = "Vanguard Total Bond Market ETF", AssetClass = "ETFs", Ticker = "BND", Quantity = 50, PurchasePrice = 85.00, CurrentPrice = 90.00, MarketValue = 4500, GainLoss = 250, Weight = 5 },
        new Holding { Id = 13, Name = "Gold", AssetClass = "Commodities", Ticker = "XAU", Quantity = 10, PurchasePrice = 1800.00, CurrentPrice = 1900.00, MarketValue = 19000, GainLoss = 1000, Weight = 10 },
        new Holding { Id = 14, Name = "Silver", AssetClass = "Commodities", Ticker = "XAG", Quantity = 100, PurchasePrice = 25.00, CurrentPrice = 27.00, MarketValue = 2700, GainLoss = 200, Weight = 5 },
        new Holding { Id = 15, Name = "Real Estate Fund", AssetClass = "Real Estate", Ticker = "REIT", Quantity = 20, PurchasePrice = 100.00, CurrentPrice = 110.00, MarketValue = 2200, GainLoss = 200, Weight = 5 },
        new Holding { Id = 16, Name = "Private Equity Fund", AssetClass = "Private Equity", Ticker = "PEF", Quantity = 10, PurchasePrice = 500.00, CurrentPrice = 550.00, MarketValue = 5500, GainLoss = 500, Weight = 5 },
        new Holding { Id = 17, Name = "Hedge Fund A", AssetClass = "Hedge Funds", Ticker = "HFA", Quantity = 5, PurchasePrice = 1000.00, CurrentPrice = 1050.00, MarketValue = 5250, GainLoss = 250, Weight = 5 },
        new Holding { Id = 18, Name = "Mutual Fund A", AssetClass = "Mutual Funds", Ticker = "MFA", Quantity = 30, PurchasePrice = 50.00, CurrentPrice = 55.00, MarketValue = 1650, GainLoss = 150, Weight = 5 },
        new Holding { Id = 19, Name = "Cash Reserve", AssetClass = "Cash", Ticker = "CASH", Quantity = 1, PurchasePrice = 10000.00, CurrentPrice = 10000.00, MarketValue = 10000, GainLoss = 0, Weight = 5 },
        new Holding { Id = 20, Name = "Tesla Bond", AssetClass = "Bonds", Ticker = "TSLABOND", Quantity = 15, PurchasePrice = 95.00, CurrentPrice = 100.00, MarketValue = 1500, GainLoss = 75, Weight = 5 }
    };

    public List<Holding> GetHoldings() => _holdings;
    public Holding GetById(int id) => _holdings.FirstOrDefault(h => h.Id == id);
    public void AddHolding(Holding holding) => _holdings.Add(holding);
    public void UpdateHolding(int id, Holding updated)
    {
        var holding = _holdings.FirstOrDefault(h => h.Id == id);
        if (holding != null)
        {
            holding.Name = updated.Name;
            holding.AssetClass = updated.AssetClass;
            holding.Ticker = updated.Ticker;
            holding.Quantity = updated.Quantity;
            holding.PurchasePrice = updated.PurchasePrice;
            holding.CurrentPrice = updated.CurrentPrice;
            holding.MarketValue = updated.MarketValue;
            holding.GainLoss = updated.GainLoss;
            holding.Weight = updated.Weight;
        }
    }
    public void DeleteHolding(int id) => _holdings.RemoveAll(h => h.Id == id);
}
