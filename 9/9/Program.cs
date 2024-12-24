public interface ISolid
{
    double Volume();       // Метод для вычисления объёма
    double SurfaceArea();  // Метод для вычисления площади поверхности
}
public class Cube : ISolid
{
    public double Side { get; }

    public Cube(double side)
    {
        Side = side;
    }

    // Вычисление объёма куба
    public double Volume()
    {
        return Math.Pow(Side, 3);
    }

    // Вычисление площади поверхности куба
    public double SurfaceArea()
    {
        return 6 * Math.Pow(Side, 2);
    }
}
public class Cylinder : ISolid
{
    public double Radius { get; }
    public double Height { get; }

    public Cylinder(double radius, double height)
    {
        Radius = radius;
        Height = height;
    }

    // Вычисление объёма цилиндра
    public double Volume()
    {
        return Math.PI * Math.Pow(Radius, 2) * Height;
    }

    // Вычисление площади поверхности цилиндра
    public double SurfaceArea()
    {
        return 2 * Math.PI * Radius * (Radius + Height);
    }
}
public class SolidPrinter
{
    public static void PrintSolidInfo(ISolid solid)
    {
        if (solid is Cube cube)
        {
            Console.WriteLine("Тело: Куб");
            Console.WriteLine($"Сторона: {cube.Side}");
            Console.WriteLine($"Объём: {cube.Volume()}");
            Console.WriteLine($"Площадь поверхности: {cube.SurfaceArea()}");
        }
        else if (solid is Cylinder cylinder)
        {
            Console.WriteLine("Тело: Цилиндр");
            Console.WriteLine($"Радиус: {cylinder.Radius}, Высота: {cylinder.Height}");
            Console.WriteLine($"Объём: {cylinder.Volume()}");
            Console.WriteLine($"Площадь поверхности: {cylinder.SurfaceArea()}");
        }
    }
}
class Program
{
    static void Main()
    {
        // Создаём экземпляры куба и цилиндра
        Cube cube = new Cube(5);
        Cylinder cylinder = new Cylinder(3, 7);

        // Выводим информацию о телах
        SolidPrinter.PrintSolidInfo(cube);
        Console.WriteLine();  // Печать пустой строки для разделения вывода
        SolidPrinter.PrintSolidInfo(cylinder);
    }
}


