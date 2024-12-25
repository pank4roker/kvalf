using System;

struct HockeyPlayer
{
    public string LastName;      // Фамилия
    public int Age;              // Возраст
    public int GamesPlayed;      // Количество игр
    public int GoalsScored;      // Количество заброшенных шайб

    // Метод для вывода информации о хоккеисте
    public void PrintInfo()
    {
        Console.WriteLine($"{LastName,-20}{Age,-10}{GamesPlayed,-15}{GoalsScored,-15}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите количество хоккеистов: ");
        int n = int.Parse(Console.ReadLine());  // Количество хоккеистов

        HockeyPlayer[] players = new HockeyPlayer[n];  // Массив хоккеистов

        // Ввод данных о хоккеистах
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nВведите данные для хоккеиста {i + 1}:");
            Console.Write("Фамилия: ");
            players[i].LastName = Console.ReadLine();
            Console.Write("Возраст: ");
            players[i].Age = int.Parse(Console.ReadLine());
            Console.Write("Количество игр: ");
            players[i].GamesPlayed = int.Parse(Console.ReadLine());
            Console.Write("Количество заброшенных шайб: ");
            players[i].GoalsScored = int.Parse(Console.ReadLine());
        }

        // Вывод всех хоккеистов в табличном виде
        Console.WriteLine("\nСведения о хоккеистах:");
        Console.WriteLine($"{"Фамилия",-20}{"Возраст",-10}{"Игры",-15}{"Шайбы",-15}");
        foreach (var player in players)
        {
            player.PrintInfo();
        }

        // Подсчет среднего возраста хоккеистов
        double averageAge = 0;
        foreach (var player in players)
        {
            averageAge += player.Age;
        }
        averageAge /= n;

        Console.WriteLine($"\nСредний возраст хоккеистов: {averageAge:F2}");

        // Вывод хоккеистов, чей возраст больше 25 лет
        var playersAbove25 = Array.FindAll(players, p => p.Age > 25);
        
        if (playersAbove25.Length > 0)
        {
            Console.WriteLine("\nХоккеисты, возраст которых больше 25 лет:");
            Console.WriteLine($"{"Фамилия",-20}{"Возраст",-10}{"Игры",-15}{"Шайбы",-15}");
            foreach (var player in playersAbove25)
            {
                player.PrintInfo();
            }
        }
        else
        {
            Console.WriteLine("\nНет хоккеистов, возраст которых больше 25 лет.");
        }
    }
}
