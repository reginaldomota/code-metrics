namespace Application.CodeMetrics;

public class CompareSequence
{
    public static void Execute()
    {
        List<double> sequenceDouble = ReadSequenceA();
        List<Fraction> sequenceFraction = ReadSequenceB();

        if (sequenceDouble.Count == 0 || sequenceFraction.Count == 0)
        {
            Console.WriteLine("Erro: Uma ou ambas as sequências estão vazias!");
            return;
        }

        int halfOfA = (sequenceDouble.Count + 1) / 2;

        List<Fraction> result = sequenceFraction
            .Where(fraction => sequenceDouble.Count(value => fraction.IsLesser(value)) > halfOfA)
            .ToList();


        sequenceDouble.Sort();

        List<Fraction> result = new List<Fraction>();
        foreach (Fraction value in sequenceFraction)
        {
            int position = 0;
            foreach ( double number in sequenceDouble)
            {
                position++;
                if (value.IsLesser(number))
                    if(position >= halfOfA)
                    {
                        result.Add(value);
                        break;
                    }
            }
        }

        

        // Imprimir resultado
        Console.WriteLine("\n" + new string('=', 50));
        Console.WriteLine("Frações da sequência B maiores que metade de A:");
        Console.WriteLine(new string('=', 50));

        if (result.Count == 0)
        {
            Console.WriteLine("Nenhuma fração atende o critério");
        }
        else
        {
            foreach (var fraction in result)
            {
                Console.WriteLine($"{fraction} = {fraction.GetValue():F4}");
            }
        }
    }

    private static List<double> ReadSequenceA()
    {
        List<double> sequence = new List<double>();
        Console.WriteLine("\n=== Leitura da Sequência A (doubles) ===");
        Console.WriteLine("Digite valores do tipo double (digite 0 para parar):");

        while (true)
        {
            Console.Write("Valor: ");
            if (double.TryParse(Console.ReadLine(), out double value))
            {
                if (value == 0){
                    Console.WriteLine("Leitura encerrada");
                    break;
                }

                sequence.Add(value);
            }
            else
            {
                Console.WriteLine("Valor inválido! Digite um número");
            }
        }
        
        return sequence;
    }

    private static List<Fraction> ReadSequenceB()
    {
        List<Fraction> sequence = new List<Fraction>();
        Console.WriteLine("\n=== Leitura da Sequência B (frações) ===");
        Console.WriteLine("Digite frações no formato: numerador/denominador. (Digite uma fração negativa para parar)");

        while (true)
        {
            Console.Write("Fração (numerador/denominador): ");
            string input = Console.ReadLine() ?? "";
            string[] parts = input.Split('/');

            if (parts.Length != 2)
            {
                Console.WriteLine("Formato inválido! Use: numerador/denominador. Exemplo 1/2");
                continue;
            }

            if (!int.TryParse(parts[0], out int numerator) || !int.TryParse(parts[1], out int denominator))
            {
                Console.WriteLine("Valores inválidos! Digite números inteiros");
                continue;
            }

            if (denominator == 0)
            {
                Console.WriteLine("Denominador não pode ser zero");
                continue;
            }

            if ((double)numerator / denominator < 0)
            {
                Console.WriteLine("Leitura encerrada");
                break;
            }

            Fraction fraction = new Fraction().Of(numerator, denominator);
            sequence.Add(fraction);
        }

        return sequence;
    }
}