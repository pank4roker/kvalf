using System;

public class Triangle
{
    // Поля для сторон треугольника
    private double _sideA;
    private double _sideB;
    private double _sideC;

    // Статические поля для подсчёта типов треугольников
    public static int EquilateralCount { get; private set; }
    public static int IsoscelesCount { get; private set; }
    public static int ScaleneCount { get; private set; }

    // Свойства для сторон с проверкой корректности
    public double SideA
    {
        get => _sideA;
        set
        {
            if (value <= 0)
                throw new ArgumentException("Сторона треугольника должна быть положительным числом.");
            _sideA = value;
        }
    }

    public double SideB
    {
        get => _sideB;
        set
        {
            if (value <= 0)
                throw new ArgumentException("Сторона треугольника должна быть положительным числом.");
            _sideB = value;
        }
    }

    public double SideC
    {
        get => _sideC;
        set
        {
            if (value <= 0)
                throw new ArgumentException("Сторона треугольника должна быть положительным числом.");
            _sideC = value;
        }
    }

    // Конструктор
    public Triangle(double sideA, double sideB, double sideC)
    {
        // Проверяем, можно ли построить треугольник
        if (sideA + sideB <= sideC || sideA + sideC <= sideB || sideB + sideC <= sideA)
            throw new ArgumentException("Треугольник с такими сторонами не может существовать.");

        SideA = sideA;
        SideB = sideB;
        SideC = sideC;

        // Определяем тип треугольника и увеличиваем соответствующий счётчик
        ClassifyTriangle();
    }

    // Метод для классификации треугольника
    private void ClassifyTriangle()
    {
        if (SideA == SideB && SideB == SideC)
        {
            EquilateralCount++;
        }
        else if (SideA == SideB || SideA == SideC || SideB == SideC)
        {
            IsoscelesCount++;
        }
        else
        {
            ScaleneCount++;
        }
    }

    // Метод для вывода информации о треугольнике
    public override string ToString()
    {
        return $"Треугольник: Стороны = {SideA}, {SideB}, {SideC}";
    }
}

class Program
{
    static void Main()
    {
        // Ввод количества треугольников
        Console.Write("Введите количество треугольников (N): ");
        int n = int.Parse(Console.ReadLine() ?? "0");

        // Создание массива треугольников
        Triangle[] triangles = new Triangle[n];

        // Ввод данных для каждого треугольника
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nВведите стороны треугольника {i + 1}:");

            Console.Write("Сторона A: ");
            double a = double.Parse(Console.ReadLine() ?? "0");

            Console.Write("Сторона B: ");
            double b = double.Parse(Console.ReadLine() ?? "0");

            Console.Write("Сторона C: ");
            double c = double.Parse(Console.ReadLine() ?? "0");

            try
            {
                triangles[i] = new Triangle(a, b, c);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                i--; // Повторяем ввод для текущего треугольника
            }
        }

        // Вывод результатов
        Console.WriteLine($"\nКоличество равносторонних треугольников: {Triangle.EquilateralCount}");
        Console.WriteLine("Список равносторонних треугольников:");
        foreach (var triangle in triangles)
        {
            if (triangle.SideA == triangle.SideB && triangle.SideB == triangle.SideC)
                Console.WriteLine(triangle);
        }

        Console.WriteLine($"\nКоличество равнобедренных треугольников: {Triangle.IsoscelesCount}");
        Console.WriteLine("Список равнобедренных треугольников:");
        foreach (var triangle in triangles)
        {
            if (triangle.SideA == triangle.SideB || triangle.SideA == triangle.SideC || triangle.SideB == triangle.SideC)
                if (!(triangle.SideA == triangle.SideB && triangle.SideB == triangle.SideC)) // Исключаем равносторонние
                    Console.WriteLine(triangle);
        }

        Console.WriteLine($"\nКоличество разносторонних треугольников: {Triangle.ScaleneCount}");
        Console.WriteLine("Список разносторонних треугольников:");
        foreach (var triangle in triangles)
        {
            if (triangle.SideA != triangle.SideB && triangle.SideA != triangle.SideC && triangle.SideB != triangle.SideC)
                Console.WriteLine(triangle);
        }
    }
}
