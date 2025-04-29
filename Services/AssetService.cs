public class AssetService
{
    private readonly List<Asset> _assets = new()
    {
        new Asset { Id = 1, Name = "Stocks", Allocation = 60, Risk = "High", ExpectedReturn = 8.5, Liquidity = "High", Volatility = 12.5, MarketCap = 2500, Region = "Global", TaxImplication = "Capital Gains" },
        new Asset { Id = 2, Name = "Bonds", Allocation = 30, Risk = "Low", ExpectedReturn = 3.2, Liquidity = "Medium", Volatility = 4.3, MarketCap = 1500, Region = "US", TaxImplication = "Interest Income" }
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
