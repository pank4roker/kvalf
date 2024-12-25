using System;
using System.Linq;
public class Product
{
    // Поля
    private string _name;
    private decimal _price;
    private int _quantity;

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

    public decimal Price
    {
        get => _price;
        set
        {
            if(value<0)
                throw new Exception("Цена не может быть отрицательной");
            _price = value;
        }
    }

    public int Quantity
    {
        get => _quantity;
        set
        {
            if (value < 0)
                throw new ArgumentException("Количество не может быть отрицательным.");
            _quantity = value;
        }
    }

    // Конструктор
    public Product(string name, decimal price, int quantity)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
    }

    // Переопределение метода ToString для удобного вывода
    public override string ToString()
    {
        return $"Наименование: {Name}, Цена: {Price:C}, Количество: {Quantity}";
    }
}

class Program
{
    static void Main()
    {
        Console.Write("Введите количество товаров: ");
        int n = int.Parse(Console.ReadLine());

        Product[] products = new Product[n];

        // Ввод данных
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nВведите данные для товара {i + 1}:");
            Console.Write("Наименование: ");
            string name = Console.ReadLine();
            Console.Write("Цена: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("Количество: ");
            int quantity = int.Parse(Console.ReadLine());

            products[i] = new Product(name, price, quantity);
        }

        // Сортировка по наименованию
        var sortedByName = products.OrderBy(p => p.Name).ToArray();
        Console.WriteLine("\nСортировка по наименованию:");
        foreach (var product in sortedByName)
        {
            Console.WriteLine(product);
        }

        // Сортировка по цене
        var sortedByPrice = products.OrderByDescending(p => p.Price).ToArray();
        Console.WriteLine("\nСортировка по цене:");
        foreach (var product in sortedByPrice)
        {
            Console.WriteLine(product);
        }
    }
}
