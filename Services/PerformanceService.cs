public class PerformanceService
{
   private readonly List<PerformanceEntry> _performance = new()
    {
        new PerformanceEntry { Date = "2024-01-01", Value = 10000 },
        new PerformanceEntry { Date = "2024-02-01", Value = 10200 },
        new PerformanceEntry { Date = "2024-03-01", Value = 10450 },
        new PerformanceEntry { Date = "2024-04-01", Value = 10700 },
        new PerformanceEntry { Date = "2024-05-01", Value = 11050 }
    };

    public List<PerformanceEntry> GetAll() => _performance;
}