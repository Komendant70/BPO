// ChessPiece.cs
using System;
using System.Collections.Generic;

public abstract class ChessPiece
{
    protected string Name { get; set; }
    protected int X { get; set; } // Координата X (1-8, соответствует a-h)
    protected int Y { get; set; } // Координата Y (1-8, соответствует 1-8)

    public ChessPiece(string name, int x, int y)
    {
        Name = name;
        if (x < 1 || x > 8 || y < 1 || y > 8)
            throw new ArgumentException("Координаты должны быть в диапазоне от 1 до 8");
        X = x;
        Y = y;
    }

    // Метод для получения позиции в формате "a1", "b2" и т.д.
    public string GetPosition()
    {
        char file = (char)('a' + X - 1); // Преобразуем X (1-8) в буквы a-h
        return $"{file}{Y}";
    }

    // Абстрактный метод для определения возможных ходов атаки
    public abstract List<(int x, int y)> GetAttackMoves();

    // Метод для отображения информации о фигуре
    public override string ToString()
    {
        return $"{Name} на позиции {GetPosition()}";
    }
}

public class Queen : ChessPiece
{
    public Queen(int x, int y) : base("Ферзь", x, y) { }

    public override List<(int x, int y)> GetAttackMoves()
    {
        List<(int x, int y)> moves = new List<(int x, int y)>();

        // Ферзь ходит по горизонтали, вертикали и диагоналям
        // Горизонталь
        for (int x = 1; x <= 8; x++)
        {
            if (x != X) moves.Add((x, Y));
        }

        // Вертикаль
        for (int y = 1; y <= 8; y++)
        {
            if (y != Y) moves.Add((X, y));
        }

        // Диагонали
        for (int i = -7; i <= 7; i++)
        {
            if (i == 0) continue;
            int newX = X + i;
            int newY = Y + i;
            if (newX >= 1 && newX <= 8 && newY >= 1 && newY <= 8)
                moves.Add((newX, newY));

            newY = Y - i;
            if (newX >= 1 && newX <= 8 && newY >= 1 && newY <= 8)
                moves.Add((newX, newY));
        }

        return moves;
    }
}

public class Pawn : ChessPiece
{
    public Pawn(int x, int y) : base("Пешка", x, y) { }

    public override List<(int x, int y)> GetAttackMoves()
    {
        List<(int x, int y)> moves = new List<(int x, int y)>();

        // Пешка атакует по диагонали на одну клетку вперед (предполагаем, что пешка белая, движется вверх)
        int direction = 1; // Для белых пешек (для черных можно сделать -1)
        int newY = Y + direction;

        if (newY >= 1 && newY <= 8)
        {
            // Атака влево-вперед
            int newX = X - 1;
            if (newX >= 1) moves.Add((newX, newY));

            // Атака вправо-вперед
            newX = X + 1;
            if (newX <= 8) moves.Add((newX, newY));
        }

        return moves;
    }
}

public class Knight : ChessPiece
{
    public Knight(int x, int y) : base("Конь", x, y) { }

    public override List<(int x, int y)> GetAttackMoves()
    {
        List<(int x, int y)> moves = new List<(int x, int y)>();

        // Конь ходит буквой "Г": 2 клетки в одну сторону и 1 в перпендикулярную
        int[] dx = { 2, 2, -2, -2, 1, 1, -1, -1 };
        int[] dy = { 1, -1, 1, -1, 2, -2, 2, -2 };

        for (int i = 0; i < 8; i++)
        {
            int newX = X + dx[i];
            int newY = Y + dy[i];
            if (newX >= 1 && newX <= 8 && newY >= 1 && newY <= 8)
                moves.Add((newX, newY));
        }

        return moves;
    }
}