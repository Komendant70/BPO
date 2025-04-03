// Money.cs
using System;

// Интерфейс для базовых операций с деньгами
public interface IMoneyOperations
{
    Money Add(Money other);
    Money Subtract(Money other);
    Money Divide(double divisor);
    Money Multiply(double multiplier);
    int Compare(Money other);
}

// Абстрактный базовый класс для денежных единиц
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

    // Нормализация копеек (перевод избытка в рубли)
    protected void Normalize()
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

// Конкретная реализация класса Money
public class Money : Currency, IMoneyOperations
{
    public Money(long rubles, int kopecks) : base(rubles, kopecks) { }

    // Вывод суммы в формате "рубли,копейки"
    public override string Display()
    {
        return $"{Rubles},{Kopecks:00}";
    }

    // Сложение
    public Money Add(Money other)
    {
        long newRubles = Rubles + other.Rubles;
        int newKopecks = Kopecks + other.Kopecks;
        return new Money(newRubles, newKopecks);
    }

    // Вычитание
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
        if (divisor == 0) throw new DivideByZeroException();
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

    // Деструктор (финализатор)
    ~Money()
    {
        Console.WriteLine("Money object destroyed");
    }
}