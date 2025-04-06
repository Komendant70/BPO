using System;
public interface MoneyOperations
{
    Money Sum(Money other);
    Money Subtract(Money other);
    Money Divide(double divisor);
    Money Multiply(double multiplier);
    int Compare(Money other);
}

public abstract class Currency
{
    public long Rubles { get; set; }
    public int Kopecks { get; set; }

    public Currency(long rubles, int kopecks)
    {

        Rubles = rubles;
        Kopecks = kopecks;
        Normalize();
    }

    private void Normalize()
    {
        if (Kopecks >= 100)
        {
            Rubles += Kopecks / 100;
            Kopecks %= 100;
        }
        else if (Kopecks < 0)
        {
            Rubles -= 1 + (-Kopecks) / 100;
            Kopecks = 100 - ((-Kopecks) % 100);
        }
    }

    public abstract string Display();
}

public class Money : Currency, MoneyOperations
{
     public Money(long rubles, int kopecks) : base(rubles, kopecks) {}

    public override string Display()
    {
        return $"{Rubles},{Kopecks:00}";
    }

    public Money Sum(Money other)
    {
        if (other == null)
            throw new ArgumentNullException(nameof(other));

        long newRubles = Rubles + other.Rubles;
        int newKopecks = Kopecks + other.Kopecks;
        
        var result = new Money(newRubles, newKopecks);
        return result;
    }

    public Money Subtract(Money other)
    {
        if (other == null)
            throw new ArgumentNullException(nameof(other));

        long newRubles = Rubles - other.Rubles;
        int newKopecks = Kopecks - other.Kopecks;

        if (newRubles < 0 || (newRubles == 0 && newKopecks < 0))
            throw new InvalidOperationException("Результат вычитания не может быть отрицательным");

        return new Money(newRubles, newKopecks);
    }

    public double Divide(Money other)
    {
        if (other == null)
            throw new ArgumentNullException(nameof(other));
        if (other.Rubles == 0 && other.Kopecks == 0)
            throw new DivideByZeroException("Деление на нулевую сумму");

        double thisTotal = Rubles + Kopecks / 100.0;
        double otherTotal = other.Rubles + other.Kopecks / 100.0;
        return thisTotal / otherTotal;
    }

    public Money Divide(double divisor)
    {
        if (divisor <= 0)
            throw new ArgumentException("Делитель должен быть положительным", nameof(divisor));

        double total = (Rubles + Kopecks / 100.0) / divisor;
        long newRubles = (long)total;
        int newKopecks = (int)((total - newRubles) * 100);
        return new Money(newRubles, newKopecks);
    }

    public Money Multiply(double multiplier)
    {
        if (multiplier < 0)
            throw new ArgumentException("Множитель не может быть отрицательным", nameof(multiplier));

        double total = (Rubles + Kopecks / 100.0) * multiplier;
        long newRubles = (long)total;
        int newKopecks = (int)((total - newRubles) * 100);
        return new Money(newRubles, newKopecks);
    }

    public int Compare(Money other)
    {
        if (other == null)
            throw new ArgumentNullException(nameof(other));

        if (Rubles > other.Rubles || (Rubles == other.Rubles && Kopecks > other.Kopecks))
        {
            Console.WriteLine($"Первая сумма ({Display()}) больше второй ({other.Display()})");
            return 1;
        }
        else if (Rubles < other.Rubles || (Rubles == other.Rubles && Kopecks < other.Kopecks))
        {
            Console.WriteLine($"Вторая сумма ({other.Display()}) больше первой ({Display()})");
            return -1;
        }
        else
        {
            Console.WriteLine($"Суммы равны: {Display()} = {other.Display()}");
            return 0;
        }
    }

    ~Money()
    {
        Console.WriteLine("Денег нет, но вы держитесь");
    }
}