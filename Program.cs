using Application.CodeMetrics;
using Application.Operations;
using Application.Sequence.StopConditions;
using Application.Sequence.Factories;
using Microsoft.Extensions.DependencyInjection;

namespace CodeMetrics;

public class Program
{
    public static void Main(string[] args)
    {
        var serviceProvider = ConfigureServices();

        var app = new Application(serviceProvider);
        app.Run();
    }

    private static ServiceProvider ConfigureServices()
    {
        var services = new ServiceCollection();

        services.AddKeyedTransient<IStopCondition<double>, DoubleStop>("double");
        services.AddKeyedTransient<IStopCondition<Fraction>, StopOnNegativeFraction>("fraction");

        services.AddSingleton<IStopConditionFactory, StopConditionFactory>();

        services.AddTransient<SetOperations>();
        services.AddTransient<CompareSequence>();

        return services.BuildServiceProvider();
    }
}
