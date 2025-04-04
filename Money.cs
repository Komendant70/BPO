using System;

public interface MoneyOperations
{
    Money Sum(Money other); // сложение
    Money Subtract(Money other); // вычитание
    Money Divide(double divisor); // деление
    Money Multiply(double multiplier); // умножение
    int Compare(Money other); // сравнение
}


public abstract class Currency
{
    protected long Rubles { get; set; }
    protected int Kopecks { get; set; }

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
    public Money(long rubles, int kopecks) : base(rubles, kopecks) { }

    public override string Display()
    {
        return $"{Rubles},{Kopecks:00}";
    }

    public Money Sum(Money other)
    {
        long newRubles = Rubles + other.Rubles;
        int newKopecks = Kopecks + other.Kopecks;
        return new Money(newRubles, newKopecks);
    }

    public Money Subtract(Money other)
    {
        long newRubles = Rubles - other.Rubles;
        int newKopecks = Kopecks - other.Kopecks;
        return new Money(newRubles, newKopecks);
    }

    // Деление двух сумм
    public double Divide(Money other)
    {
        double thisTotal = Rubles + Kopecks / 100.0;
        double otherTotal = other.Rubles + other.Kopecks / 100.0;
        return thisTotal / otherTotal;
    }

    // Деление на дробное число
    public Money Divide(double divisor)
    {
        double total = (Rubles + Kopecks / 100.0) / divisor;
        long newRubles = (long)total;
        int newKopecks = (int)((total - newRubles) * 100);
        return new Money(newRubles, newKopecks);
    }

    // Умножение на дробное число
    public Money Multiply(double multiplier)
    {
        double total = (Rubles + Kopecks / 100.0) * multiplier;
        long newRubles = (long)total;
        int newKopecks = (int)((total - newRubles) * 100);
        return new Money(newRubles, newKopecks);
    }

    // Сравнение
    public int Compare(Money other)
    {
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