public interface IProbabilityStrategy
{
    double CalculateOverallProbability(IEnumerable<Task> tasks);
    void UpdateProbability(Task task);
    string StrategyDescription { get; }
}