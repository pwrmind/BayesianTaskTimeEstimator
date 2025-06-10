namespace BayesianTaskTimeEstimator;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.WriteLine("📊 Калькулятор оценки времени выполнения задач");
        Console.WriteLine("-------------------------------------------");
        
        // Выбор стратегии
        Console.WriteLine("\n🔧 Выберите стратегию расчета:");
        Console.WriteLine("1️⃣ - Байесовский подход (учет фактических результатов)");
        Console.WriteLine("2️⃣ - Фрактальный подход (учет детализации задач)");
        Console.Write("Ваш выбор (1/2): ");
        var choice = Console.ReadLine();
        
        IProbabilityStrategy strategy = choice == "1" 
            ? new BayesianStrategy(alpha: 2, beta: 1) 
            : new FractalStrategy(detailFactor: 0.15);
        
        var calculator = new ProbabilityCalculator(strategy);
        var tasks = new List<Task>();
        
        Console.WriteLine($"\n{strategy.StrategyDescription}");
        Console.WriteLine("-------------------------------------------");
        
        // Ввод задач
        Console.WriteLine("\n➕ ДОБАВЛЕНИЕ ЗАДАЧ");
        while (true)
        {
            var task = new Task();
            
            Console.Write("\nВведите название задачи 📝: ");
            task.Name = Console.ReadLine();
            
            Console.Write($"Введите вероятность успеха для '{task.Name}' (0.1-0.99) 🔮: ");
            task.EstimatedProbability = double.Parse(Console.ReadLine());
            
            tasks.Add(task);
            
            Console.Write("Добавить еще задачу? (y/n) ➕: ");
            if (Console.ReadLine().ToLower() != "y") break;
        }
        
        // Ввод фактических результатов
        Console.WriteLine("\n📋 ВВЕДИТЕ ФАКТИЧЕСКИЕ РЕЗУЛЬТАТЫ");
        foreach (var task in tasks)
        {
            Console.Write($"\nЗадача: {task.Name} (оценка: {task.EstimatedProbability:P0})");
            Console.Write("\nБыла выполнена успешно? (y/n) ✅❌: ");
            var result = Console.ReadLine().ToLower();
            
            task.Evidence = result == "y";
        }
        
        // Обновление вероятностей
        calculator.UpdateProbabilities(tasks);
        
        // Расчет и вывод результатов
        Console.WriteLine("\n📊 РЕЗУЛЬТАТЫ РАСЧЕТА");
        Console.WriteLine("-------------------------------------------");
        
        Console.WriteLine("\nОбновленные оценки задач:");
        foreach (var task in tasks)
        {
            Console.WriteLine($"🔹 {task.Name}: {task.EstimatedProbability:P2} " + 
                              $"({(task.Evidence.Value ? "✅" : "❌")})");
        }
        
        double overallProbability = calculator.CalculateOverallProbability(tasks);
        Console.WriteLine($"\n🌟 ОБЩАЯ ВЕРОЯТНОСТЬ УСПЕХА ПРОЕКТА: {overallProbability:P2}");
        
        Console.WriteLine("\nСпасибо за использование калькулятора! 🎉");
    }
}