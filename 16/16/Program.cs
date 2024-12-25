using System;
using System.Collections.Generic;
using System.Linq;

class Film
{
    public string Title { get; set; } // Название фильма
    public DateTime StartTime { get; set; } // Дата и время начала сеанса
    public TimeSpan Duration { get; set; } // Продолжительность сеанса
    public string Genre { get; set; } // Жанр

    public Film(string title, DateTime startTime, TimeSpan duration, string genre)
    {
        Title = title;
        StartTime = startTime;
        Duration = duration;
        Genre = genre;
    }

    public override string ToString()
    {
        return $"Название: {Title}, Начало: {StartTime}, Продолжительность: {Duration}, Жанр: {Genre}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создание коллекции фильмов
        List<Film> films = new List<Film>
        {
            new Film("Интерстеллар", new DateTime(2024, 12, 25, 18, 0, 0), TimeSpan.FromHours(2.5), "Фантастика"),
            new Film("Начало", new DateTime(2024, 12, 25, 20, 30, 0), TimeSpan.FromHours(2.2), "Триллер"),
            new Film("Аватар", new DateTime(2024, 12, 25, 22, 0, 0), TimeSpan.FromHours(3), "Фантастика"),
            new Film("Гарри Поттер", new DateTime(2024, 12, 26, 16, 0, 0), TimeSpan.FromHours(2.5), "Фэнтези"),
            new Film("Темный рыцарь", new DateTime(2024, 12, 26, 19, 0, 0), TimeSpan.FromHours(2.3), "Боевик")
        };

        // Вывод информации обо всех фильмах
        Console.WriteLine("Список всех фильмов:");
        foreach (var film in films)
        {
            Console.WriteLine(film);
        }

        // Подсчет количества фильмов каждого жанра
        Dictionary<string, int> genreCounts = new Dictionary<string, int>();
        foreach (var film in films)
        {
            if (genreCounts.ContainsKey(film.Genre))
            {
                genreCounts[film.Genre]++;
            }
            else
            {
                genreCounts[film.Genre] = 1;
            }
        }

        Console.WriteLine("\nКоличество фильмов по жанрам:");
        foreach (var genre in genreCounts)
        {
            Console.WriteLine($"{genre.Key}: {genre.Value}");
        }

        // Проверка наличия фильмов определенного жанра
        Console.Write("\nВведите жанр для проверки: ");
        string inputGenre = Console.ReadLine();
        bool genreExists = films.Any(film => film.Genre.Equals(inputGenre, StringComparison.OrdinalIgnoreCase));
        if (genreExists)
        {
            Console.WriteLine($"Фильмы жанра \"{inputGenre}\" есть в списке.");
        }
        else
        {
            Console.WriteLine($"Фильмов жанра \"{inputGenre}\" нет в списке.");
        }
    }
}
