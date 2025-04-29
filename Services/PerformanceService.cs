public class PerformanceService
{
   private readonly List<PerformanceEntry> _performance = new()
    {
        new PerformanceEntry { Date = "2024-01-01", Open = 9800, High = 10100, Low = 9700, Close = 10000 },
        new PerformanceEntry { Date = "2024-02-01", Open = 10000, High = 10500, Low = 9900, Close = 10200 },
        new PerformanceEntry { Date = "2024-03-01", Open = 10200, High = 10700, Low = 10100, Close = 10450 },
        new PerformanceEntry { Date = "2024-04-01", Open = 10450, High = 11000, Low = 10300, Close = 10700 },
        new PerformanceEntry { Date = "2024-05-01", Open = 10700, High = 11300, Low = 10600, Close = 11050 }
    };

    public List<PerformanceEntry> GetAll() => _performance;
}