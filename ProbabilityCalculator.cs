public class ProbabilityCalculator
{
    private readonly IProbabilityStrategy _strategy;
    
    public ProbabilityCalculator(IProbabilityStrategy strategy)
    {
        _strategy = strategy;
    }
    
    public double CalculateOverallProbability(IEnumerable<Task> tasks)
    {
        return _strategy.CalculateOverallProbability(tasks);
    }
    
    public void UpdateProbabilities(List<Task> tasks)
    {
        foreach (var task in tasks)
        {
            _strategy.UpdateProbability(task);
        }
    }
}