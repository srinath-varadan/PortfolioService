public class AssetService
{
   private readonly List<Asset> _assets = new()
    {
        new Asset { Id = 1, Name = "Stocks", Allocation = 60, Risk = "High", ExpectedReturn = 8.5, Liquidity = "High", Volatility = 12.5, MarketCap = 2500, Region = "Global", TaxImplication = "Capital Gains" },
        new Asset { Id = 2, Name = "Bonds", Allocation = 30, Risk = "Low", ExpectedReturn = 3.2, Liquidity = "Medium", Volatility = 4.3, MarketCap = 1500, Region = "US", TaxImplication = "Interest Income" },
        new Asset { Id = 3, Name = "Real Estate", Allocation = 20, Risk = "Medium", ExpectedReturn = 6.0, Liquidity = "Low", Volatility = 8.0, MarketCap = 3000, Region = "US", TaxImplication = "Property Tax" },
        new Asset { Id = 4, Name = "Commodities", Allocation = 10, Risk = "High", ExpectedReturn = 7.5, Liquidity = "Medium", Volatility = 15.0, MarketCap = 1000, Region = "Global", TaxImplication = "Capital Gains" },
        new Asset { Id = 5, Name = "Cryptocurrency", Allocation = 5, Risk = "Very High", ExpectedReturn = 20.0, Liquidity = "High", Volatility = 50.0, MarketCap = 800, Region = "Global", TaxImplication = "Capital Gains" },
        new Asset { Id = 6, Name = "Mutual Funds", Allocation = 25, Risk = "Medium", ExpectedReturn = 5.5, Liquidity = "Medium", Volatility = 6.5, MarketCap = 2000, Region = "US", TaxImplication = "Capital Gains" },
        new Asset { Id = 7, Name = "ETFs", Allocation = 15, Risk = "Medium", ExpectedReturn = 6.2, Liquidity = "High", Volatility = 7.0, MarketCap = 1800, Region = "Global", TaxImplication = "Capital Gains" },
        new Asset { Id = 8, Name = "Private Equity", Allocation = 10, Risk = "High", ExpectedReturn = 12.0, Liquidity = "Low", Volatility = 10.0, MarketCap = 500, Region = "US", TaxImplication = "Capital Gains" },
        new Asset { Id = 9, Name = "Hedge Funds", Allocation = 8, Risk = "High", ExpectedReturn = 9.0, Liquidity = "Low", Volatility = 9.5, MarketCap = 700, Region = "Global", TaxImplication = "Capital Gains" },
        new Asset { Id = 10, Name = "Cash", Allocation = 5, Risk = "Low", ExpectedReturn = 1.0, Liquidity = "High", Volatility = 0.0, MarketCap = 100, Region = "US", TaxImplication = "None" }
    };

    public List<Asset> GetAssets() => _assets;
    public Asset GetById(int id) => _assets.FirstOrDefault(a => a.Id == id);
    public void AddAsset(Asset asset) => _assets.Add(asset);
    public void UpdateAsset(int id, Asset updated)
    {
    var asset = _assets.FirstOrDefault(a => a.Id == id);
    if (asset == null)
    {
        return; // Asset not found
    }

    // Only update the fields individually (do not create a new object)
    asset.Name = updated.Name;
    asset.Allocation = updated.Allocation;
    asset.Risk = updated.Risk;
    asset.ExpectedReturn = updated.ExpectedReturn;
    asset.Liquidity = updated.Liquidity;
    asset.Volatility = updated.Volatility;
    asset.MarketCap = updated.MarketCap;
    asset.Region = updated.Region;
    asset.TaxImplication = updated.TaxImplication;

    return;
}
    public void DeleteAsset(int id) => _assets.RemoveAll(a => a.Id == id);
}
