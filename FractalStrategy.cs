public class FractalStrategy : IProbabilityStrategy
{
    private readonly double _detailFactor;
    
    public FractalStrategy(double detailFactor = 0.1)
    {
        _detailFactor = detailFactor;
    }
    
    public string StrategyDescription => 
        "🌀 Фрактальный подход: учитываем увеличение времени при детализации задач";
    
    public double CalculateOverallProbability(IEnumerable<Task> tasks)
    {
        int taskCount = tasks.Count();
        double effectiveTasks = taskCount * (1 + _detailFactor * Math.Log(taskCount + 1));
        
        double product = 1.0;
        foreach (var task in tasks)
        {
            product *= task.EstimatedProbability;
        }
        
        return Math.Pow(product, 1 + _detailFactor);
    }
    
    public void UpdateProbability(Task task)
    {
        if (task.Evidence.HasValue)
        {
            task.EstimatedProbability = task.Evidence.Value ? 
                Math.Min(1.0, task.EstimatedProbability * 1.05) : 
                Math.Max(0.0, task.EstimatedProbability * 0.95);
        }
    }
}