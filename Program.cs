using Application.CodeMetrics;

namespace CodeMetrics;

public class Program
{
    public static void Main(string[] args)
    {
        bool running = true;
        while (running)
        {
            Console.WriteLine(string.Concat("\n", new string('=', 50), "\nMenu Principal\n", new string('=', 50)));
            Console.WriteLine("1. Calcular diferença entre dois arrays");
            Console.WriteLine("2. Sair");
            Console.Write("Escolha uma opção: ");

            string option = Console.ReadLine() ?? "";

            if (option == "1")
            {
                SetOperations.Execute();
            }
            else if (option == "2")
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
