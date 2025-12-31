using Microsoft.Extensions.DependencyInjection;
using Application.CodeMetrics;
using Application.Operations;
using Application.Matrix;

namespace Presentation;

public class ConsoleApplication
{
    private readonly IServiceProvider _serviceProvider;

    public ConsoleApplication(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void Run()
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine(string.Concat("\n", new string('=', 50), "\nMenu Principal\n", new string('=', 50)));
            Console.WriteLine("1. Calcular diferença entre dois arrays");
            Console.WriteLine("2. Comparar sequências (A e B com frações)");
            Console.WriteLine("3. Operações com Matriz de Strings");
            Console.WriteLine("4. Sair");
            Console.Write("Escolha uma opção: ");

            string option = Console.ReadLine() ?? "";

            if (option == "1")
            {
                var setOperations = _serviceProvider.GetRequiredService<SetOperations>();
                setOperations.Execute();
            }
            else if (option == "2")
            {
                var compareSequence = _serviceProvider.GetRequiredService<CompareSequence>();
                compareSequence.Execute();
            }
            else if (option == "3")
            {
                var consoleMatrix = _serviceProvider.GetRequiredService<ConsoleMatrix>();
                consoleMatrix.Execute();
            }
            else if (option == "4")
            {
                running = false;
                Console.WriteLine("Até logo!");
            }
            else
            {
                Console.WriteLine("Opção inválida!");
            }
        }
    }
}
