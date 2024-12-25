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

        // 1. Список элементов, кратных 3, отсортированный по возрастанию
        var multiplesOf3 = numbers.Where(n => n % 3 == 0).OrderBy(n => n).ToList();
        Console.WriteLine("\nЭлементы, кратные 3, отсортированные по возрастанию:");
        Console.WriteLine(string.Join(", ", multiplesOf3));

        // 2. Сумма элементов, значения которых кратны 4
        var sumOfMultiplesOf4 = numbers.Where(n => n % 4 == 0).Sum();
        Console.WriteLine($"\nСумма элементов, кратных 4: {sumOfMultiplesOf4}");

        // 3. Подсчет количества элементов, значения которых положительны и не превосходят 20
        var countOfPositivesNotExceeding20 = numbers.Count(n => n > 0 && n <= 20);
        Console.WriteLine($"\nКоличество положительных элементов, не превосходящих 20: {countOfPositivesNotExceeding20}");

        // 4. Нахождение минимального по модулю элемента
        var minAbsElement = numbers.OrderBy(n => Math.Abs(n)).First();
        Console.WriteLine($"\nМинимальный по модулю элемент: {minAbsElement}");

        // 5. Проверка наличия отрицательных элементов, кратных 5
        var hasNegativeMultipleOf5 = numbers.Any(n => n < 0 && n % 5 == 0);
        Console.WriteLine($"\nЕсть ли отрицательные элементы, кратные 5? {hasNegativeMultipleOf5}");

        // 6. Нахождение первого нечетного элемента
        var firstOddElement = numbers.FirstOrDefault(n => n % 2 != 0);
        if (firstOddElement != 0)
        {
            Console.WriteLine($"\nПервый нечетный элемент: {firstOddElement}");
        }
        else
        {
            Console.WriteLine("\nОтсутствует первый нечетный элемент.");
        }
    }
}
