using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        // Запросим у пользователя значения для диапазона [a, b] и размер списка n
        Console.Write("Введите размер списка (n): ");
        int n = int.Parse(Console.ReadLine());
        Console.Write("Введите начало диапазона (a): ");
        int a = int.Parse(Console.ReadLine());
        Console.Write("Введите конец диапазона (b): ");
        int b = int.Parse(Console.ReadLine());

        // Создаем список случайных чисел
        Random rand = new Random();
        List<int> numbers = new List<int>();

        for (int i = 0; i < n; i++)
        {
            numbers.Add(rand.Next(a, b + 1));  // Генерация случайных чисел в диапазоне [a, b]
        }

        // Выводим исходный список
        Console.WriteLine("\nИсходный список:");
        Console.WriteLine(string.Join(", ", numbers));

        // 1. Создание списка из положительных элементов и сортировка по возрастанию
        var positiveNumbers = numbers.Where(n => n > 0).OrderBy(n => n).ToList();
        Console.WriteLine("\nПоложительные элементы, отсортированные по возрастанию:");
        Console.WriteLine(string.Join(", ", positiveNumbers));

        // 2. Сумма положительных элементов, состоящих из двух цифр
        var sumOfTwoDigitPositives = numbers.Where(n => n > 0 && n >= 10 && n <= 99).Sum();
        Console.WriteLine($"\nСумма положительных элементов, состоящих из двух цифр: {sumOfTwoDigitPositives}");

        // 3. Подсчет количества элементов, значения которых по модулю больше 10 и кратны 5
        var countOfModGreaterThan10AndDivisibleBy5 = numbers.Count(n => Math.Abs(n) > 10 && n % 5 == 0);
        Console.WriteLine($"\nКоличество элементов, значение которых по модулю больше 10 и кратно 5: {countOfModGreaterThan10AndDivisibleBy5}");

        // 4. Нахождение максимального нечетного элемента
        var maxOddElement = numbers.Where(n => n % 2 != 0).Max();
        Console.WriteLine($"\nМаксимальный нечетный элемент: {maxOddElement}");

        // 5. Проверка наличия отрицательных элементов, кратных 3
        var hasNegativeDivisibleBy3 = numbers.Any(n => n < 0 && n % 3 == 0);
        Console.WriteLine($"\nЕсть ли отрицательные элементы, кратные 3? {hasNegativeDivisibleBy3}");

        // 6. Нахождение первого отрицательного нечетного элемента
        var firstNegativeOdd = numbers.FirstOrDefault(n => n < 0 && n % 2 != 0);
        if (firstNegativeOdd != 0)
        {
            Console.WriteLine($"\nПервый отрицательный нечетный элемент: {firstNegativeOdd}");
        }
        else
        {
            Console.WriteLine("\nОтсутствует первый отрицательный нечетный элемент.");
        }
    }
}
