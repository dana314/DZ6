using System;
using System.Collections.Generic;
public abstract class Sweet
{
    public string Name { get; private set; }
    public float Price { get; private set; }
    public int Amount { get; set; }
    public string Type { get; }

    public Sweet(string name, float price, int amount, string type)
    {
        Name = name;
        Price = price;
        Amount = amount;
        Type = type;
    }
    public abstract void Sell(int amount);
    public void UpdatePrice(float newPrice)
    {
        Price = newPrice;
    }
    public void Restock(int amount)
    {
        Amount += amount;
    }
    public override string ToString()
    {
        return $"{Name} - {Price} (доступно: {Amount}, вид: {Type})";
    }
}
public class Candy : Sweet
{
    public string Flavor { get; set; }
    public string Category { get; }

    public Candy(string name, float price, int amount, string flavor, string type)
        : base(name, price, amount, type)
    {
        Flavor = flavor;
        Category = "Candy";
    }

    public override void Sell(int amount)
    {
        if (amount > Amount)
            throw new InvalidOperationException("недостаточно конфет");

        Amount -= amount;
        Console.WriteLine($"продано {amount} конфет {Name}. Осталось: {Amount}");
    }

    public string GetFlavor()
    {
        return Flavor;
    }

    public void SetFlavor(string flavor)
    {
        Flavor = flavor;
    }

    public override string ToString()
    {
        return base.ToString() + $" (Flavor: {Flavor})";
    }
}

public class Chocolate : Candy
{
    public float Percent { get; }

    public Chocolate(string name, float price, int amount, string flavor, string type, float percent)
        : base(name, price, amount, flavor, type)
    {
        Percent = percent;
    }

    public override void Sell(int amount)
    {
        base.Sell(amount);
        Console.WriteLine($"шоколад с содержанием какао {Percent}%.");
    }

    public string GetType()
    {
        return $"шоколад с содержанием какао {Percent}%";
    }

    public override string ToString()
    {
        return base.ToString() + $" (процент какао: {Percent}%)";
    }
}

public class CandyStore
{
    public string Name { get; private set; }
    private List<Sweet> sweets;

    public CandyStore(string name)
    {
        Name = name;
        sweets = new List<Sweet>();
    }

    public void AddSweet(Sweet sweet)
    {
        sweets.Add(sweet);
    }

    public void Sale(string name, int amount)
    {
        var sweet = FindSweet(name);
        sweet.Sell(amount);
    }

    public Sweet FindSweet(string name)
    {
        var sweet = sweets.Find(s => s.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (sweet == null)
            throw new ArgumentException("такой сладости нет :( ");

        return sweet;
    }

    public void ShowAllSweets()
    {
        Console.WriteLine("сладости в магазине:");
        foreach (var sweet in sweets)
        {
            Console.WriteLine(sweet);
        }
    }
}

class Program // как можно использовать программу
{
    static void Main(string[] args)
    {
        CandyStore store = new CandyStore("магазин сладостей");
        Candy candy = new Candy("Конфета", 5, 100, "пчелка", "карамель");
        Chocolate chocolate = new Chocolate("шоколад", 6000, 5, "какао", "дубайский шоколад", 70);
        store.AddSweet(candy);
        store.AddSweet(chocolate);
        store.ShowAllSweets();
        store.Sale("Конфета", 5);
        store.ShowAllSweets();
    }
}