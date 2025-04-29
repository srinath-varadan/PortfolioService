public class Asset
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Allocation { get; set; }
    public string Risk { get; set; }
    public double ExpectedReturn { get; set; }
    public string Liquidity { get; set; }
    public double Volatility { get; set; }
    public double MarketCap { get; set; }
    public string Region { get; set; }
    public string TaxImplication { get; set; }
}

// Models/Holding.cs
public class Holding
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string AssetClass { get; set; }
    public string Ticker { get; set; }
    public int Quantity { get; set; }
    public double PurchasePrice { get; set; }
    public double CurrentPrice { get; set; }
    public double MarketValue { get; set; }
    public double GainLoss { get; set; }
    public double Weight { get; set; }
}

// Models/PerformanceEntry.cs
public class PerformanceEntry
{
    public string Date { get; set; }
    public double Open { get; set; }
    public double High { get; set; }
    public double Low { get; set; }
    public double Close { get; set; }
}