public class HoldingService
{
    private readonly List<Holding> _holdings = new()
    {
        new Holding { Id = 1, Name = "Apple Inc.", AssetClass = "Stocks", Ticker = "AAPL", Quantity = 50, PurchasePrice = 145.00, CurrentPrice = 160.00, MarketValue = 8000, GainLoss = 750, Weight = 25 },
        new Holding { Id = 2, Name = "US Treasury Bond", AssetClass = "Bonds", Ticker = "USTB10Y", Quantity = 30, PurchasePrice = 98.00, CurrentPrice = 100.00, MarketValue = 3000, GainLoss = 60, Weight = 10 }
    };

    public List<Holding> GetAll() => _holdings;
    public Holding GetById(int id) => _holdings.FirstOrDefault(h => h.Id == id);
    public void Add(Holding holding) => _holdings.Add(holding);
    public void Update(int id, Holding updated)
    {
        var holding = GetById(id);
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
    public void Delete(int id) => _holdings.RemoveAll(h => h.Id == id);
}
