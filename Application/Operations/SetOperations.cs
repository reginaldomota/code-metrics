namespace Application.Operations;

using Application.Operations.Utils;

public class SetOperations
{
    public void Execute()
    {
        Console.Write("Digite o primeiro array (separado por vírgula): ");
        string input = Console.ReadLine() ?? "";
        int[] a = Parser.ParseArray(input);

        Console.Write("Digite o segundo array (separado por vírgula): ");
        input = Console.ReadLine() ?? "";
        int[] b = Parser.ParseArray(input);
        int[] result = Difference(a, b);

        Console.WriteLine($"\nArray A: [{string.Join(", ", a)}]");
        Console.WriteLine($"Array B: [{string.Join(", ", b)}]");
        Console.WriteLine($"Diferença (A - B): [{string.Join(", ", result)}]");
    }

    private int[] Difference(int[] a, int[] b)
    {
        HashSet<int> setB = new HashSet<int>(b);
        List<int> result = new List<int>();

        foreach (int item in a)
            if (!setB.Contains(item))
                result.Add(item);

        return result.ToArray();
    }
}