// Goods.cs
using System;

public class Goods
{
    private string name;
    private DateTime receiptDate;
    private decimal price;
    private int quantity;
    private string invoiceNumber;

    public Goods(string name, DateTime receiptDate, decimal price, int quantity, string invoiceNumber)
    {
        this.name = name;
        this.receiptDate = receiptDate;
        this.price = price >= 0 ? price : throw new ArgumentException("Цена не может быть отрицательной");
        this.quantity = quantity >= 0 ? quantity : throw new ArgumentException("Количество не может быть отрицательным");
        this.invoiceNumber = invoiceNumber;
    }

    public void ChangePrice(decimal newPrice)
    {
        if (newPrice < 0)
            throw new ArgumentException("Новая цена не может быть отрицательной");
        price = newPrice;
        Console.WriteLine($"Цена товара '{name}' изменена на {price} руб.");
    }

    public void IncreaseQuantity(int amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Увеличиваемое количество должно быть положительным");
        quantity += amount;
        Console.WriteLine($"Количество товара '{name}' увеличено на {amount}. Новое количество: {quantity}");
    }

    public void DecreaseQuantity(int amount)
    {
        if (amount <= 0)
            throw new ArgumentException("Уменьшаемое количество должно быть положительным");
        if (quantity - amount < 0)
            throw new InvalidOperationException("Нельзя уменьшить количество ниже нуля");
        quantity -= amount;
        Console.WriteLine($"Количество товара '{name}' уменьшено на {amount}. Новое количество: {quantity}");
    }

    public decimal CalculateTotalCost()
    {
        return price * quantity;
    }

    public string DisplayTotalCost()
    {
        decimal totalCost = CalculateTotalCost();
        return $"Общая стоимость товара '{name}': {totalCost:F2} руб.";
    }

    public override string ToString()
    {
        return $"Товар: {name}\n" +
               $"Дата оформления: {receiptDate:dd.MM.yyyy}\n" +
               $"Цена за единицу: {price:F2} руб.\n" +
               $"Количество: {quantity} шт.\n" +
               $"Номер накладной: {invoiceNumber}\n" +
               $"{DisplayTotalCost()}";
    }
}