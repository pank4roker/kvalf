using System;
using System.IO;
using System.Linq;

class Program
{
    static void Main()
    {
        // Вводим количество чисел
        Console.Write("Введите количество чисел: ");
        int n = int.Parse(Console.ReadLine());

        // Массив для хранения чисел
        int[] numbers = new int[n];

        // Вводим числа с клавиатуры
        Console.WriteLine("Введите числа:");
        for (int i = 0; i < n; i++)
        {
            numbers[i] = int.Parse(Console.ReadLine());
        }

        // Сохраняем числа в исходный файл
        string inputFile = "numbers.txt";
        File.WriteAllLines(inputFile, numbers.Select(num => num.ToString()));

        // Разделяем числа на положительные и отрицательные
        var negativeNumbers = numbers.Where(num => num < 0).ToList();
        var positiveNumbers = numbers.Where(num => num > 0).ToList();

        // Вычисляем суммы
        int negativeSum = negativeNumbers.Sum();
        int positiveSum = positiveNumbers.Sum();

        // Создаем файлы для отрицательных и положительных чисел с их суммами
        string negativeFile = "negative_numbers.txt";
        string positiveFile = "positive_numbers.txt";

        // Записываем отрицательные числа и их сумму в файл
        File.WriteAllLines(negativeFile, negativeNumbers.Select(num => num.ToString()));
        File.AppendAllText(negativeFile, $"\nСумма отрицательных чисел: {negativeSum}\n");

        // Записываем положительные числа и их сумму в файл
        File.WriteAllLines(positiveFile, positiveNumbers.Select(num => num.ToString()));
        File.AppendAllText(positiveFile, $"\nСумма положительных чисел: {positiveSum}\n");

        // Читаем и выводим содержимое файлов
        Console.WriteLine("\nСодержимое файла с отрицательными числами:");
        if (File.Exists(negativeFile))
        {
            Console.WriteLine(File.ReadAllText(negativeFile));
        }

        Console.WriteLine("\nСодержимое файла с положительными числами:");
        if (File.Exists(positiveFile))
        {
            Console.WriteLine(File.ReadAllText(positiveFile));
        }
    }
}
