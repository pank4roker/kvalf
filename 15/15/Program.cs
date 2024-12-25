using System;
using System.Collections.Generic;
using System.Linq;

public class Product
{
    // Поля
    private string _name;
    private DateTime _manufactureDate;
    private int _shelfLife; // Срок годности в днях
    private decimal _price;

    // Свойства
    public string Name
    {
        get => _name;
        set
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new ArgumentException("Наименование не может быть пустым.");
            _name = value;
        }
    }

    public DateTime ManufactureDate
    {
        get => _manufactureDate;
        set
        {
            if (value > DateTime.Now)
                throw new ArgumentException("Дата производства не может быть в будущем.");
            _manufactureDate = value;
        }
    }

    public int ShelfLife
    {
        get => _shelfLife;
        set
        {
            if (value < 0)
                throw new ArgumentException("Срок годности не может быть отрицательным.");
            _shelfLife = value;
        }
    }

    public decimal Price
    {
        get => _price;
        set
        {
            if (value < 0)
                throw new ArgumentException("Цена не может быть отрицательной.");
            _price = value;
        }
    }

    // Конечная дата применения (годен до)
    public DateTime ExpiryDate => ManufactureDate.AddDays(ShelfLife);

    // Конструктор
    public Product(string name, DateTime manufactureDate, int shelfLife, decimal price)
    {
        Name = name;
        ManufactureDate = manufactureDate;
        ShelfLife = shelfLife;
        Price = price;
    }

    // Переопределение метода ToString
    public override string ToString()
    {
        return $"Наименование: {Name}, Дата производства: {ManufactureDate:dd.MM.yyyy}, Срок годности: {ShelfLife} дней, Цена: {Price:C}, Годен до: {ExpiryDate:dd.MM.yyyy}";
    }
}
class Program
{
    static void Main()
    {
        // Создание списка товаров
        List<Product> products = new List<Product>
        {
            new Product("Молоко", DateTime.Now.AddDays(-10), 7, 80),
            new Product("Хлеб", DateTime.Now.AddDays(-2), 3, 40),
            new Product("Сыр", DateTime.Now.AddDays(-30), 60, 300),
            new Product("Йогурт", DateTime.Now.AddDays(-15), 15, 50),
            new Product("Шоколад", DateTime.Now.AddDays(-100), 180, 150)
        };

        // Вывод всех товаров
        Console.WriteLine("Все товары:");
        foreach (var product in products)
        {
            Console.WriteLine(product);
        }

        // Список товаров, срок годности которых истек
        List<Product> expiredProducts = products.Where(p => p.ExpiryDate < DateTime.Now).ToList();
        Console.WriteLine("\nТовары с истекшим сроком годности:");
        if (expiredProducts.Any())
        {
            foreach (var product in expiredProducts)
            {
                Console.WriteLine($"Наименование: {product.Name}, Годен до: {product.ExpiryDate:dd.MM.yyyy}");
            }
        }
        else
        {
            Console.WriteLine("Нет товаров с истекшим сроком годности.");
        }

        // Список товаров, срок годности которых заканчивается в течение ближайших 30 суток
        List<Product> expiringSoonProducts = products
            .Where(p => p.ExpiryDate >= DateTime.Now && p.ExpiryDate <= DateTime.Now.AddDays(30))
            .ToList();
        Console.WriteLine("\nТовары, срок годности которых заканчивается в течение ближайших 30 дней:");
        if (expiringSoonProducts.Any())
        {
            foreach (var product in expiringSoonProducts)
            {
                Console.WriteLine($"Наименование: {product.Name}, Годен до: {product.ExpiryDate:dd.MM.yyyy}");
            }
        }
        else
        {
            Console.WriteLine("Нет товаров с истекающим сроком годности в ближайшие 30 дней.");
        }
    }
}
