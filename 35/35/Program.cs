using System;
using System.Linq;

class Program
{
    // Определяем делегат, принимающий параметр целого типа и возвращающий значение логического типа
    delegate bool NumberCondition(int number);

    static void Main()
    {
        // Вводим размер массива
        Console.Write("Введите размер массива: ");
        int n = int.Parse(Console.ReadLine());

        // Создаем массив случайных чисел в диапазоне [-20, 20]
        Random rand = new Random();
        int[] numbers = new int[n];
        for (int i = 0; i < n; i++)
        {
            numbers[i] = rand.Next(-20, 21);  // Случайное число от -20 до 20
        }

        // Выводим все элементы массива
        Console.WriteLine("\nВсе элементы массива:");
        Print(numbers, number => true);  // Выводим все элементы

        // Выводим четные элементы массива
        Console.WriteLine("\nЧетные элементы массива:");
        Print(numbers, number => number % 2 == 0);  // Фильтруем четные элементы

        // Подсчитываем сумму отрицательных нечетных элементов массива
        int sum = Sum(numbers, number => number < 0 && number % 2 != 0);  // Фильтруем отрицательные нечетные числа
        Console.WriteLine($"\nСумма отрицательных нечетных элементов массива: {sum}");
    }

    // Метод для вывода элементов массива, удовлетворяющих условию
    static void Print(int[] array, NumberCondition condition)
    {
        var filteredArray = array.Where(number => condition(number)).ToArray();
        if (filteredArray.Length > 0)
        {
            Console.WriteLine(string.Join(", ", filteredArray));
        }
        else
        {
            Console.WriteLine("Нет элементов, удовлетворяющих условию.");
        }
    }

    // Метод для подсчета суммы элементов массива, удовлетворяющих условию
    static int Sum(int[] array, NumberCondition condition)
    {
        return array.Where(number => condition(number)).Sum();
    }
}