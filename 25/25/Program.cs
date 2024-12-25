using System;

struct Product
{
    public string Name;           // Наименование
    public string Manufacturer;    // Изготовитель
    public int Quantity;           // Количество
    public decimal Price;          // Цена
    public int YearOfManufacture;  // Год выпуска

    // Метод для вывода данных о товаре
    public void PrintInfo()
    {
        Console.WriteLine($"{Name,-20}{Manufacturer,-20}{Quantity,-10}{Price,-10:C}{YearOfManufacture,-10}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите количество товаров: ");
        int n = int.Parse(Console.ReadLine());  // Количество товаров

        Product[] products = new Product[n];  // Массив товаров

        // Ввод данных о товарах
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nВведите данные для товара {i + 1}:");
            Console.Write("Наименование: ");
            products[i].Name = Console.ReadLine();
            Console.Write("Изготовитель: ");
            products[i].Manufacturer = Console.ReadLine();
            Console.Write("Количество: ");
            products[i].Quantity = int.Parse(Console.ReadLine());
            Console.Write("Цена: ");
            products[i].Price = decimal.Parse(Console.ReadLine());
            Console.Write("Год выпуска: ");
            products[i].YearOfManufacture = int.Parse(Console.ReadLine());
        }

        // Вывод всех товаров в табличном виде
        Console.WriteLine("\nСведения о товарах:");
        Console.WriteLine($"{"Наименование",-20}{"Изготовитель",-20}{"Количество",-10}{"Цена",-10}{"Год выпуска",-10}");
        foreach (var product in products)
        {
            product.PrintInfo();
        }

        // Определяем текущий год
        int currentYear = DateTime.Now.Year;

        // Фильтруем товары, выпущенные в текущем году
        var currentYearProducts = Array.FindAll(products, p => p.YearOfManufacture == currentYear);

        // Вывод информации о товарах текущего года
        if (currentYearProducts.Length > 0)
        {
            Console.WriteLine($"\nСведения о товарах, выпущенных в {currentYear} году:");
            Console.WriteLine($"{"Наименование",-20}{"Изготовитель",-20}{"Количество",-10}{"Цена",-10}{"Год выпуска",-10}");
            foreach (var product in currentYearProducts)
            {
                product.PrintInfo();
            }

            // Рассчитываем общую стоимость товаров текущего года
            decimal totalCost = 0;
            foreach (var product in currentYearProducts)
            {
                totalCost += product.Price * product.Quantity;
            }

            Console.WriteLine($"\nОбщая стоимость товаров, выпущенных в {currentYear} году: {totalCost:C}");
        }
        else
        {
            Console.WriteLine($"\nНет товаров, выпущенных в {currentYear} году.");
        }
    }
}
