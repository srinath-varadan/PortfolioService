public class PerformanceService
{
    private List<PerformanceEntry> _performance = new()
    {
        // Apple Inc. Performance
        new PerformanceEntry { Name = "Apple Inc.", Date = "2024-01-01", Open = 150, High = 160, Low = 145, Close = 155 },
        new PerformanceEntry { Name = "Apple Inc.", Date = "2024-02-01", Open = 155, High = 165, Low = 150, Close = 160 },
        new PerformanceEntry { Name = "Apple Inc.", Date = "2024-03-01", Open = 160, High = 170, Low = 155, Close = 165 },
        new PerformanceEntry { Name = "Apple Inc.", Date = "2024-04-01", Open = 165, High = 175, Low = 160, Close = 170 },
        new PerformanceEntry { Name = "Apple Inc.", Date = "2024-05-01", Open = 170, High = 180, Low = 165, Close = 175 },
        new PerformanceEntry { Name = "Apple Inc.", Date = "2024-06-01", Open = 175, High = 185, Low = 170, Close = 180 },

        // Microsoft Corp. Performance
        new PerformanceEntry { Name = "Microsoft Corp.", Date = "2024-01-01", Open = 250, High = 260, Low = 245, Close = 255 },
        new PerformanceEntry { Name = "Microsoft Corp.", Date = "2024-02-01", Open = 255, High = 265, Low = 250, Close = 260 },
        new PerformanceEntry { Name = "Microsoft Corp.", Date = "2024-03-01", Open = 260, High = 270, Low = 255, Close = 265 },
        new PerformanceEntry { Name = "Microsoft Corp.", Date = "2024-04-01", Open = 265, High = 275, Low = 260, Close = 270 },
        new PerformanceEntry { Name = "Microsoft Corp.", Date = "2024-05-01", Open = 270, High = 280, Low = 265, Close = 275 },
        new PerformanceEntry { Name = "Microsoft Corp.", Date = "2024-06-01", Open = 275, High = 285, Low = 270, Close = 280 },

        // Tesla Inc. Performance
        new PerformanceEntry { Name = "Tesla Inc.", Date = "2024-01-01", Open = 600, High = 620, Low = 590, Close = 610 },
        new PerformanceEntry { Name = "Tesla Inc.", Date = "2024-02-01", Open = 610, High = 630, Low = 600, Close = 620 },
        new PerformanceEntry { Name = "Tesla Inc.", Date = "2024-03-01", Open = 620, High = 640, Low = 610, Close = 630 },
        new PerformanceEntry { Name = "Tesla Inc.", Date = "2024-04-01", Open = 630, High = 650, Low = 620, Close = 640 },
        new PerformanceEntry { Name = "Tesla Inc.", Date = "2024-05-01", Open = 640, High = 660, Low = 630, Close = 650 },
        new PerformanceEntry { Name = "Tesla Inc.", Date = "2024-06-01", Open = 650, High = 670, Low = 640, Close = 660 },

        // Amazon.com Inc. Performance
        new PerformanceEntry { Name = "Amazon.com Inc.", Date = "2024-01-01", Open = 3200, High = 3300, Low = 3100, Close = 3250 },
        new PerformanceEntry { Name = "Amazon.com Inc.", Date = "2024-02-01", Open = 3250, High = 3350, Low = 3150, Close = 3300 },
        new PerformanceEntry { Name = "Amazon.com Inc.", Date = "2024-03-01", Open = 3300, High = 3400, Low = 3200, Close = 3350 },
        new PerformanceEntry { Name = "Amazon.com Inc.", Date = "2024-04-01", Open = 3350, High = 3450, Low = 3250, Close = 3400 },
        new PerformanceEntry { Name = "Amazon.com Inc.", Date = "2024-05-01", Open = 3400, High = 3500, Low = 3300, Close = 3450 },
        new PerformanceEntry { Name = "Amazon.com Inc.", Date = "2024-06-01", Open = 3450, High = 3550, Low = 3350, Close = 3500 },

        // Add similar performance data for other holdings...
    };

    public List<PerformanceEntry> GetAll() => _performance;

    public List<PerformanceEntry> GetByName(string name) =>
        _performance.Where(p => p.Name == name).ToList();
}