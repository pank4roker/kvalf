using System;

class Program
{
    // Статический метод для вычисления среднего арифметического
    public static double Average(int m, int n)
    {
        // Убедимся, что m меньше или равно n, поменяем их местами, если это не так
        if (m > n)
        {
            int temp = m;
            m = n;
            n = temp;
        }

        // Количество чисел в диапазоне
        int count = n - m + 1;

        // Сумма всех чисел в диапазоне
        int sum = (m + n) * count / 2;

        // Возвращаем среднее арифметическое
        return (double)sum / count;
    }

    static void Main()
    {
        // Ввод значений a и b с клавиатуры
        Console.Write("Введите значение a: ");
        int a = int.Parse(Console.ReadLine() ?? "0");

        Console.Write("Введите значение b: ");
        int b = int.Parse(Console.ReadLine() ?? "0");

        // Вычисляем среднее арифметическое
        double average = Average(a, b);

        // Вывод результата
        Console.WriteLine($"Среднее арифметическое всех чисел от {a} до {b}: {average:F2}");
    }
}
