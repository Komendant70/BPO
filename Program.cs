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
            Console.WriteLine("3. Работа с шахматными фигурами (ChessPiece)");
            Console.WriteLine("4. Выйти");
            Console.Write("Ваш выбор (1-4): ");

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
                    RunChessTask();
                    break;

                case "4":
                    Console.WriteLine("Программа завершена.");
                    return;

                default:
                    Console.WriteLine("Неверный выбор. Пожалуйста, выберите число от 1 до 4.");
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

    // Задание 3: Работа с шахматными фигурами
    static void RunChessTask()
    {
        try
        {
            Console.WriteLine("\n=== Задание 3: Работа с шахматными фигурами ===");
            List<ChessPiece> pieces = new List<ChessPiece>();

            // Выбор атакующей фигуры
            Console.WriteLine("Выберите фигуру для атаки:");
            Console.WriteLine("1. Ферзь");
            Console.WriteLine("2. Пешка");
            Console.WriteLine("3. Конь");
            Console.Write("Ваш выбор (1-3): ");
            string pieceChoice = Console.ReadLine();

            Console.Write("Введите позицию фигуры (например, e4): ");
            string position = Console.ReadLine();
            int x = position[0] - 'a' + 1; // Преобразуем букву в число (a=1, b=2, ..., h=8)
            int y = int.Parse(position[1].ToString());

            ChessPiece attackingPiece;
            switch (pieceChoice)
            {
                case "1":
                    attackingPiece = new Queen(x, y);
                    break;
                case "2":
                    attackingPiece = new Pawn(x, y);
                    break;
                case "3":
                    attackingPiece = new Knight(x, y);
                    break;
                default:
                    throw new ArgumentException("Неверный выбор фигуры");
            }

            pieces.Add(attackingPiece);
            Console.WriteLine($"Вы выбрали: {attackingPiece}");

            // Добавление других фигур
            while (true)
            {
                Console.WriteLine("\nДобавить фигуру на доску?");
                Console.WriteLine("1. Да");
                Console.WriteLine("2. Нет (показать, кого может атаковать)");
                Console.Write("Ваш выбор (1-2): ");
                string addChoice = Console.ReadLine();

                if (addChoice == "2")
                    break;

                Console.WriteLine("Выберите тип фигуры:");
                Console.WriteLine("1. Ферзь");
                Console.WriteLine("2. Пешка");
                Console.WriteLine("3. Конь");
                Console.Write("Ваш выбор (1-3): ");
                pieceChoice = Console.ReadLine();

                Console.Write("Введите позицию фигуры (например, d5): ");
                position = Console.ReadLine();
                x = position[0] - 'a' + 1;
                y = int.Parse(position[1].ToString());

                ChessPiece piece;
                switch (pieceChoice)
                {
                    case "1":
                        piece = new Queen(x, y);
                        break;
                    case "2":
                        piece = new Pawn(x, y);
                        break;
                    case "3":
                        piece = new Knight(x, y);
                        break;
                    default:
                        throw new ArgumentException("Неверный выбор фигуры");
                }

                pieces.Add(piece);
                Console.WriteLine($"Добавлена фигура: {piece}");
            }

            // Определение фигур, которые может атаковать выбранная фигура
            Console.WriteLine($"\nФигура {attackingPiece} может атаковать:");
            var attackMoves = attackingPiece.GetAttackMoves();
            bool canAttack = false;

            foreach (var piece in pieces)
            {
                if (piece == attackingPiece) continue; // Пропускаем саму атакующую фигуру

                foreach (var move in attackMoves)
                {
                    int pieceX = piece.GetPosition()[0] - 'a' + 1;
                    int pieceY = int.Parse(piece.GetPosition()[1].ToString());
                    if (move.x == pieceX && move.y == pieceY)
                    {
                        Console.WriteLine(piece);
                        canAttack = true;
                        break;
                    }
                }
            }

            if (!canAttack)
                Console.WriteLine("Ни одна фигура не может быть атакована.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}