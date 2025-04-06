using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("\nВыберите задание:");
            Console.WriteLine("1. Работа с денежными суммами (Money)");
            Console.WriteLine("2. Работа с товарами (Goods)");
            Console.WriteLine("3. Шахматные фигуры (Chess)");
            Console.WriteLine("4. Выйти");
            
            Console.Write("Ваш выбор (1-4): ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    MoneyTask();
                    break;

                case "2":
                    GoodsTask();
                    break;

                case "3":
                    ChessTask();
                    break;
                    
                case "4":
                    Console.WriteLine("Программа завершена");
                    return;

                default:
                    Console.WriteLine("Неверный выбор. Выберите число от 1 до 4");
                    break;
            }
        }
    }

    //Задание 1
    static void MoneyTask()
    {
        try
        {
            Console.WriteLine("\nЗадание 1 (Деньги)");
            Console.WriteLine("Введите первую сумму:");
            Console.Write("Рубли: ");
            long rub1 = Convert.ToInt64(Console.ReadLine());
            Console.Write("Копейки: ");
            int kop1 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("\nВведите вторую сумму:");
            Console.Write("Рубли: ");
            long rub2 = Convert.ToInt64(Console.ReadLine());
            Console.Write("Копейки: ");
            int kop2 = Convert.ToInt32(Console.ReadLine());

            Money money1 = new Money(rub1, kop1);
            Money money2 = new Money(rub2, kop2);

            Console.WriteLine("\nРезультат:");
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

    //Задание 2
    static void GoodsTask()
    {
        try
        {
            Console.WriteLine("\nЗадание 2(Товары)");
            Console.WriteLine("Введите данные о товаре:");
            Console.Write("Наименование: ");
            string name = Console.ReadLine();

            Console.Write("Дата оформления (дд.мм.гггг): ");
            DateTime Date = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", null);

            Console.Write("Цена за единицу товара (в рублях): ");
            decimal price = Convert.ToDecimal(Console.ReadLine()); 

            Console.Write("Количество единиц товара: ");
            int quantity = Convert.ToInt32(Console.ReadLine());

            Console.Write("Номер накладной: ");
            string invoiceNumber = Console.ReadLine();

            Goods product = new Goods(name, Date, price, quantity, invoiceNumber);

            Console.WriteLine("\nИнформация о товаре:");
            Console.WriteLine(product);

            while (true)
            {
                Console.WriteLine("\nВыберите действие:");
                Console.WriteLine("1) Увеличить количество товара");
                Console.WriteLine("2) Уменьшить количество товара");
                Console.WriteLine("3) Изменить цену товара");
                Console.WriteLine("4) Показать информацию о товаре");
                Console.WriteLine("5) Вернуться в главное меню");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Console.Write("На сколько увеличить количество товара? ");
                        int increaseSum = Convert.ToInt32(Console.ReadLine());
                        product.IncreaseQuantity(increaseSum);
                        break;

                    case "2":
                        Console.Write("На сколько уменьшить количество товара? ");
                        int decreaseSum = Convert.ToInt32(Console.ReadLine());
                        product.DecreaseQuantity(decreaseSum);
                        break;

                    case "3":
                        Console.Write("Введите новую цену товара: ");
                        decimal newPrice = Convert.ToDecimal(Console.ReadLine());
                        product.ChangePrice(newPrice);
                        break;

                    case "4":
                        Console.WriteLine("\nИнформация о товаре:");
                        Console.WriteLine(product);
                        break;

                    case "5":
                        Console.WriteLine("Назад");
                        return;

                    default:
                        Console.WriteLine("Неверный выбор. Выберите число от 1 до 5");
                        break;
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }

    //Задание 3
    static void ChessTask()
    {
    try
    {
        Console.WriteLine("\nЗадание 3 (Шахматы)");

        var pieces = new List<ChessPiece>
        {
            new Queen(3, 4),  // Ферзь на d5
            new Pawn(2, 3),   // Пешка на c4
            new Knight(5, 5), // Конь на f6
            new Pawn(4, 5, false) // Чёрная пешка на e6
        };

        Console.WriteLine("\nСписок фигур на доске:");
        foreach (var piece in pieces)
        {
            Console.WriteLine($"{piece.GetType().Name} на {piece.Position}");
        }

        Console.Write("\nВыберите фигуру (1-4): ");
        int selectedIndex = int.Parse(Console.ReadLine()) - 1;

        if (selectedIndex < 0 || selectedIndex >= pieces.Count)
        {
            Console.WriteLine("Некорректный выбор.");
            return;
        }

        var selectedPiece = pieces[selectedIndex];
        var possibleKills = selectedPiece.GetPossibleKills(pieces);

        Console.WriteLine($"\nФигура {selectedPiece.GetType().Name} на {selectedPiece.Position} может съесть:");
        if (possibleKills.Count == 0)
            Console.WriteLine("Никого");
        else
            foreach (var kill in possibleKills)
                Console.WriteLine($"{kill.GetType().Name} на {kill.Position}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ошибка: {ex.Message}");
    }
    }
}