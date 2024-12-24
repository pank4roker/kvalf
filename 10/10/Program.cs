using System;

using System;

public class Athlete
{
    // Поля
    private string _fullName;
    private double _height;
    private double _weight;

    // Свойства
    public string FullName
    {
        get => _fullName;
        set => _fullName = string.IsNullOrWhiteSpace(value) ? "Неизвестный спортсмен" : value;
    }

    public double Height
    {
        get => _height;
        set => _height = value > 0 ? value : 170; // Если рост некорректный, устанавливаем значение по умолчанию (170 см)
    }

    public double Weight
    {
        get => _weight;
        set => _weight = value > 0 ? value : 70; // Если вес некорректный, устанавливаем значение по умолчанию (70 кг)
    }

    // Конструктор
    public Athlete(string fullName, double height, double weight)
    {
        FullName = fullName;
        Height = height;
        Weight = weight;
    }

    // Метод для вывода информации о спортсмене
    public override string ToString()
    {
        return $"Ф.И.О.: {FullName}, Рост: {Height} см, Вес: {Weight} кг";
    }
}

class Program
{
    static void Main()
    {
        // Ввод количества спортсменов
        Console.Write("Введите количество спортсменов (N): ");
        int n = int.Parse(Console.ReadLine() ?? "0");

        // Создание массива спортсменов
        Athlete[] athletes = new Athlete[n];

        // Ввод данных для каждого спортсмена
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"Введите данные для спортсмена {i + 1}:");
            Console.Write("Ф.И.О.: ");
            string fullName = Console.ReadLine();

            Console.Write("Рост (в см): ");
            double height = double.Parse(Console.ReadLine() ?? "0");

            Console.Write("Вес (в кг): ");
            double weight = double.Parse(Console.ReadLine() ?? "0");

            athletes[i] = new Athlete(fullName, height, weight);
        }

        // Фильтрация спортсменов, чей вес превышает 70 кг
        var heavyAthletes = athletes.Where(a => a.Weight > 70).ToArray();

        // Вывод информации о спортсменах
        Console.WriteLine("\nСведения о спортсменах с весом более 70 кг:");
        foreach (var athlete in heavyAthletes)
        {
            Console.WriteLine(athlete);
        }

        // Вывод количества таких спортсменов
        Console.WriteLine($"\nКоличество спортсменов с весом более 70 кг: {heavyAthletes.Length}");
    }
}