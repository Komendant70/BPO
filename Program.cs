// Program.cs
using System;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nВыберите задание:");
            Console.WriteLine("1. Работа с денежными суммами (Money)");
            Console.WriteLine("2. Работа с товарами (Goods)");
            Console.WriteLine("3. Выйти");
            Console.Write("Ваш выбор (1-3): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    RunMoneyTask();
                    break;

                case "2":
                    RunGoodsTask();
                    break;

                case "3":
                    Console.WriteLine("Программа завершена.");
                    return;

                default:
                    Console.WriteLine("Неверный выбор. Пожалуйста, выберите число от 1 до 3.");
                    break;
            }
        }
    }

    // Задание 1: Работа с денежными суммами
    static void RunMoneyTask()
    {
        try
        {
            Console.WriteLine("\n=== Задание 1: Работа с денежными суммами ===");
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
            Console.WriteLine($"Сложение: {money1.Sum(money2).Display()}");
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

    // Задание 2: Работа с товарами
    static void RunGoodsTask()
    {
        try
        {
            Console.WriteLine("\n=== Задание 2: Работа с товарами ===");
            Console.WriteLine("Введите данные о товаре:");
            Console.Write("Наименование товара: ");
            string name = Console.ReadLine();

            Console.Write("Дата оформления (в формате дд.мм.гггг, например 01.04.2025): ");
            DateTime receiptDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", null);

            Console.Write("Цена за единицу товара (в рублях): ");
            decimal price = decimal.Parse(Console.ReadLine());

            Console.Write("Количество единиц товара: ");
            int quantity = int.Parse(Console.ReadLine());

            Console.Write("Номер накладной: ");
            string invoiceNumber = Console.ReadLine();

            Goods product = new Goods(name, receiptDate, price, quantity, invoiceNumber);

            Console.WriteLine("\nИнформация о товаре:");
            Console.WriteLine(product);
            Console.WriteLine();

            while (true)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1. Увеличить количество товара");
                Console.WriteLine("2. Уменьшить количество товара");
                Console.WriteLine("3. Изменить цену товара");
                Console.WriteLine("4. Показать информацию о товаре");
                Console.WriteLine("5. Вернуться в главное меню");
                Console.Write("Ваш выбор (1-5): ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("На сколько увеличить количество товара? ");
                        int increaseAmount = int.Parse(Console.ReadLine());
                        product.IncreaseQuantity(increaseAmount);
                        break;

                    case "2":
                        Console.Write("На сколько уменьшить количество товара? ");
                        int decreaseAmount = int.Parse(Console.ReadLine());
                        product.DecreaseQuantity(decreaseAmount);
                        break;

                    case "3":
                        Console.Write("Введите новую цену товара: ");
                        decimal newPrice = decimal.Parse(Console.ReadLine());
                        product.ChangePrice(newPrice);
                        break;

                    case "4":
                        Console.WriteLine("\nТекущая информация о товаре:");
                        Console.WriteLine(product);
                        break;

                    case "5":
                        Console.WriteLine("Возвращение в главное меню.");
                        return;

                    default:
                        Console.WriteLine("Неверный выбор. Пожалуйста, выберите число от 1 до 5.");
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}