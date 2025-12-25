namespace Application.CodeMetrics;

public class Fraction
{
    public int Numerator { get; private set; }
    public int Denominator { get; private set; }

    public Fraction Of(int numerator, int denominator)
    {
        if (denominator == 0)
            throw new ArgumentException("Denominador não pode ser zero.");

        Numerator = numerator;
        Denominator = denominator;

        return this;
    }

    public double GetValue()
    {
        return (double) Numerator / Denominator;
    }

    public bool IsLesser(Fraction other)
    {
        return GetValue() < other.GetValue();
    }

    public bool IsLesser(double value)
    {
        return GetValue() < value;
    }

    public bool IsGreater(Fraction other)
    {
        return GetValue() > other.GetValue();
    }

    public bool IsGreater(double value)
    {
        return GetValue() > value;
    }

    public override string ToString()
    {
        return $"{Numerator}/{Denominator}";
    }
}
