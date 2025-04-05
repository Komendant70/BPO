using System;
using System.Collections.Generic;

public abstract class ChessPiece
{
    public int X { get; set; }     public int Y { get; set; } 

    public ChessPiece(int x, int y)
    {
        if (x < 0 || x > 7 || y < 0 || y > 7)
            throw new ArgumentException("Позиция должна быть в пределах шахматной доски (0-7)");
        X = x;
        Y = y;
    }

    public string Position => $"{(char)('a' + X)}{Y + 1}";


    public abstract List<ChessPiece> GetPossibleKills(List<ChessPiece> pieces);
}

public class Queen : ChessPiece
{
    public Queen(int x, int y) : base(x, y) { }

    public override List<ChessPiece> GetPossibleKills(List<ChessPiece> pieces)
    {
        var kills = new List<ChessPiece>();

        foreach (var piece in pieces)
        {
            if (piece == this) continue; 


            bool canKill = (piece.X == X || piece.Y == Y) || 
                          (Math.Abs(piece.X - X) == Math.Abs(piece.Y - Y));

            if (canKill)
                kills.Add(piece);
        }

        return kills;
    }
}

public class Pawn : ChessPiece
{
    public bool IsWhite { get; set; } 

    public Pawn(int x, int y, bool isWhite = true) : base(x, y)
    {
        IsWhite = isWhite;
    }

    public override List<ChessPiece> GetPossibleKills(List<ChessPiece> pieces)
    {
        var kills = new List<ChessPiece>();

        foreach (var piece in pieces)
        {
            if (piece == this) continue;

            int direction = IsWhite ? 1 : -1;
            bool canKill = (piece.Y == Y + direction) && 
                          (Math.Abs(piece.X - X) == 1);

            if (canKill)
                kills.Add(piece);
        }

        return kills;
    }
}


public class Knight : ChessPiece
{
    public Knight(int x, int y) : base(x, y) { }

    public override List<ChessPiece> GetPossibleKills(List<ChessPiece> pieces)
    {
        var kills = new List<ChessPiece>();

        foreach (var piece in pieces)
        {
            if (piece == this) continue;

            int dx = Math.Abs(piece.X - X);
            int dy = Math.Abs(piece.Y - Y);
            bool canKill = (dx == 2 && dy == 1) || (dx == 1 && dy == 2);

            if (canKill)
                kills.Add(piece);
        }

        return kills;
    }
}