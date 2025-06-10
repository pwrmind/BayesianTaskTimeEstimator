# BayesianTaskTimeEstimator# Task Estimation Probability Calculator 🧮

A flexible C# implementation for estimating task completion probabilities using Bayesian and fractal approaches. This tool helps project managers and developers improve their time estimation accuracy by applying mathematical models to real-world scenarios.

## Features ✨

- **📊 Bayesian Probability Approach**: Update estimates based on actual task performance evidence
- **🌀 Fractal Complexity Modeling**: Account for the "coastline paradox" in task decomposition
- **🔧 Extensible Architecture**: Easily add new calculation strategies
- **💻 User-Friendly Interface**: Interactive console with emoji guidance
- **📈 Multiple Task Management**: Handle any number of tasks in a single session

## Mathematical Models 🧠

### Bayesian Approach
Uses Bayes' theorem to update prior probabilities with new evidence:
```
P(A|B) = [P(B|A) * P(A)] / P(B)
```

### Fractal Approach
Models the "coastline paradox" where detailed estimation increases perceived effort:
```
T = u^(x*(1 + k*log(x)))
```
Where:
- `T` = Overall probability
- `u` = Individual task probability
- `x` = Number of tasks
- `k` = Detail factor coefficient

## Getting Started 🚀

### Prerequisites
- .NET 6 SDK or later
- Visual Studio 2022 or VS Code (optional)

### Installation
```bash
git clone https://github.com/pwrmind/BayesianTaskTimeEstimator.git
cd BayesianTaskTimeEstimator
dotnet run
```

## Usage 📝

1. **Choose calculation strategy**:
   ```
   🔧 Choose calculation strategy:
   1️⃣ - Bayesian approach (using actual results evidence)
   2️⃣ - Fractal approach (accounting for task detail complexity)
   ```

2. **Add tasks**:
   ```
   ➕ ADDING TASKS
   Enter task name 📝: API Development
   Enter success probability for 'API Development' (0.1-0.99) 🔮: 0.8
   ```

3. **Enter actual results**:
   ```
   📋 ENTER ACTUAL RESULTS
   Task: API Development (estimate: 80%)
   Was completed successfully? (y/n) ✅❌: y
   ```

4. **View results**:
   ```
   📊 CALCULATION RESULTS
   🔹 API Development: 88.89% (✅)
   🌟 OVERALL PROJECT SUCCESS PROBABILITY: 47.84%
   ```

## Project Structure 🏗️

```
TaskEstimationCalculator/
├── Strategies/
│   ├── IProbabilityStrategy.cs
│   ├── BayesianStrategy.cs
│   └── FractalStrategy.cs
├── Models/
│   └── Task.cs
├── Services/
│   └── ProbabilityCalculator.cs
└── Program.cs
```

## SOLID Principles Compliance ✅

| Principle | Implementation |
|-----------|----------------|
| **Single Responsibility** | Each class has a clear, focused purpose |
| **Open/Closed** | New strategies can be added without modifying existing code |
| **Liskov Substitution** | Strategies are interchangeable via interface |
| **Interface Segregation** | `IProbabilityStrategy` contains minimal required methods |
| **Dependency Inversion** | Calculator depends on abstraction, not concrete implementations |

## Extending the Project 🛠️

To add a new calculation strategy:

1. Create a new class in the `Strategies` folder:
   ```csharp
   public class NewStrategy : IProbabilityStrategy
   {
       public string StrategyDescription => "My new strategy";
       
       public double CalculateOverallProbability(IEnumerable<Task> tasks)
       {
           // Implementation
       }
       
       public void UpdateProbability(Task task)
       {
           // Implementation
       }
   }
   ```

2. Update the user interface in `Program.cs` to include your new strategy option.

## Contributing 🤝

Contributions are welcome! Please follow these steps:
1. Fork the repository
2. Create a new branch (`git checkout -b feature/your-feature`)
3. Commit your changes (`git commit -am 'Add some feature'`)
4. Push to the branch (`git push origin feature/your-feature`)
5. Open a pull request

## License 📄

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

---
Developed with ❤️ by [Your Name] | [Project Website] | [LinkedIn Profile]