class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите количество треугольников: ");
        int N = int.Parse(Console.ReadLine());

        List<Triangle> triangles = new List<Triangle>();

        for (int i = 0; i < N; i++)
        {
            Console.WriteLine($"Введите углы для треугольника {i + 1}:");
            Console.Write("Угол 1: ");
            double angle1 = double.Parse(Console.ReadLine());

            Console.Write("Угол 2: ");
            double angle2 = double.Parse(Console.ReadLine());

            Console.Write("Угол 3: ");
            double angle3 = double.Parse(Console.ReadLine());

            Triangle triangle = new Triangle(angle1, angle2, angle3);
            triangles.Add(triangle);
        }
        Console.WriteLine("\nОстроугольные треугольники:");
        foreach (var triangle in triangles)
        {
            if (triangle.IsAcute())
            {
                triangle.Print();
            }
        }
        Console.WriteLine("\nПрямоугольные треугольники:");
        foreach (var triangle in triangles)
        {
            if (triangle.IsRight())
            {
                triangle.Print();
            }
        }

        Console.WriteLine("\nТупоугольные треугольники:");
        foreach (var triangle in triangles)
        {
            if (triangle.IsObtuse())
            {
                triangle.Print();
            }
        }

        // Вывод количества каждого типа треугольников
        Console.WriteLine($"\nКоличество остроугольных: {Triangle.AcuteCount}");
        Console.WriteLine($"Количество прямоугольных: {Triangle.RightCount}");
        Console.WriteLine($"Количество тупоугольных: {Triangle.ObtuseCount}");
    
    }
}
class Triangle
{
    public double Angle1 { get; set; }
    public double Angle2 { get; set; }
    public double Angle3 { get; set; }

    // Статические поля для подсчета количества треугольников каждого типа
    public static int AcuteCount { get; private set; } = 0;
    public static int RightCount { get; private set; } = 0;
    public static int ObtuseCount { get; private set; } = 0;

    // Конструктор для инициализации углов треугольника
    public Triangle(double angle1, double angle2, double angle3)
    {
        Angle1 = angle1;
        Angle2 = angle2;
        Angle3 = angle3;

        // Определяем тип треугольника и увеличиваем соответствующий счетчик
        if (IsAcute())
        {
            AcuteCount++;
        }
        else if (IsRight())
        {
            RightCount++;
        }
        else if (IsObtuse())
        {
            ObtuseCount++;
        }
    }

    // Метод для определения, является ли треугольник остроугольным
    public bool IsAcute()
    {
        return Angle1 < 90 && Angle2 < 90 && Angle3 < 90;
    }

    // Метод для определения, является ли треугольник прямоугольным
    public bool IsRight()
    {
        return Math.Abs(Angle1) == 90 || Math.Abs(Angle2) == 90 || Math.Abs(Angle3) == 90;
    }

    // Метод для определения, является ли треугольник тупоугольным
    public bool IsObtuse()
    {
        return Angle1 > 90 || Angle2 > 90 || Angle3 > 90;
    }

    // Метод для вывода информации о треугольнике
    public void Print()
    {
        Console.WriteLine($"Углы треугольника: {Angle1}, {Angle2}, {Angle3}");
    }
}