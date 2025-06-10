public class BayesianStrategy : IProbabilityStrategy
{
    private readonly double _alpha;
    private readonly double _beta;
    
    public BayesianStrategy(double alpha = 1, double beta = 1)
    {
        _alpha = alpha;
        _beta = beta;
    }
    
    public string StrategyDescription => 
        "🔮 Байесовский подход: обновляем оценки на основе фактических результатов";
    
    public double CalculateOverallProbability(IEnumerable<Task> tasks)
    {
        double product = 1.0;
        foreach (var task in tasks)
        {
            product *= task.EstimatedProbability;
        }
        return product;
    }
    
    public void UpdateProbability(Task task)
    {
        if (task.Evidence.HasValue)
        {
            double prior = task.EstimatedProbability;
            double likelihood = task.Evidence.Value ? 
                _alpha / (_alpha + _beta) : 
                _beta / (_alpha + _beta);
            
            task.EstimatedProbability = (likelihood * prior) / 
                (likelihood * prior + (1 - likelihood) * (1 - prior));
        }
    }
}