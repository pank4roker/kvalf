using System;

struct Book
{
    public string Author;    // Автор
    public string Genre;     // Жанр
    public string Title;     // Название
    public int Circulation;  // Тираж
    public decimal Price;    // Цена

    // Метод для вывода данных о книге
    public void PrintInfo()
    {
        Console.WriteLine($"{Author,-20}{Genre,-15}{Title,-30}{Circulation,-10}{Price,-10:C}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите количество книг: ");
        int n = int.Parse(Console.ReadLine());  // Количество книг

        Book[] books = new Book[n];  // Массив книг

        // Ввод данных о книгах
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nВведите данные для книги {i + 1}:");
            Console.Write("Автор: ");
            books[i].Author = Console.ReadLine();
            Console.Write("Жанр: ");
            books[i].Genre = Console.ReadLine();
            Console.Write("Название: ");
            books[i].Title = Console.ReadLine();
            Console.Write("Тираж: ");
            books[i].Circulation = int.Parse(Console.ReadLine());
            Console.Write("Цена: ");
            books[i].Price = decimal.Parse(Console.ReadLine());
        }

        // Вывод всех книг в табличном виде
        Console.WriteLine("\nСведения о книгах:");
        Console.WriteLine($"{"Автор",-20}{"Жанр",-15}{"Название",-30}{"Тираж",-10}{"Цена",-10}");
        foreach (var book in books)
        {
            book.PrintInfo();
        }

        // Фильтруем книги с тиражом, не превышающим 10000 экземпляров
        var filteredBooks = Array.FindAll(books, b => b.Circulation <= 10000);

        // Вывод информации о книгах с тиражом <= 10000
        if (filteredBooks.Length > 0)
        {
            Console.WriteLine($"\nКниги с тиражом не более 10,000 экземпляров:");
            Console.WriteLine($"{"Автор",-20}{"Жанр",-15}{"Название",-30}{"Тираж",-10}{"Цена",-10}");
            decimal totalCost = 0;
            foreach (var book in filteredBooks)
            {
                book.PrintInfo();
                totalCost += book.Price * book.Circulation;
            }
            Console.WriteLine($"\nОбщая стоимость книг с тиражом не более 10,000 экземпляров: {totalCost:C}");
        }
        else
        {
            Console.WriteLine("\nНет книг с тиражом не более 10,000 экземпляров.");
        }
    }
}
