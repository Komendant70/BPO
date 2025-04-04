using System;

class Program
{
    static void Main(string[] args)
    {
        try
        {

            Console.WriteLine("Введите первую сумму:");
            Console.Write("Рубли: ");
            long rub1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Копейки: ");
            int kop1 = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("\nВведите вторую сумму:");
            Console.Write("Рубли: ");
            long rub2 = Convert.ToInt64(Console.ReadLine());
            Console.Write("Копейки: ");
            int kop2 = Convert.ToInt32(Console.ReadLine());

            Money money1 = new Money(rub1, kop1);
            Money money2 = new Money(rub2, kop2);

            Console.WriteLine("\nРезультаты операций:");
            Console.WriteLine($"Первая сумма: {money1.Display()}");
            Console.WriteLine($"Вторая сумма: {money2.Display()}");
            Console.WriteLine($"Сложениее: {money1.Sum(money2).Display()}");
            Console.WriteLine($"Вычитание: {money1.Subtract(money2).Display()}");
            Console.WriteLine($"Деление сумм: {money1.Divide(money2):F2}");
            Console.WriteLine($"Деление первой суммы на 2: {money1.Divide(2).Display()}");
            Console.WriteLine($"Умножение первой суммы на 1.5: {money1.Multiply(1.5).Display()}");
            
            money1.Compare(money2);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}