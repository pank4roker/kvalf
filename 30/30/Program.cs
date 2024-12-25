using System;

class Program
{
    static void Main()
    {
        // Ввод даты и времени визита
        Console.Write("Введите дату и время визита (в формате ГГГГ-ММ-ДД ЧЧ:ММ): ");
        string input = Console.ReadLine();
        DateTime visitDateTime;

        // Попытка распарсить введенную строку
        if (DateTime.TryParse(input, out visitDateTime))
        {
            // Текущее время
            DateTime currentDateTime = DateTime.Now;

            // Разница во времени между текущим моментом и временем визита
            TimeSpan timeDifference = visitDateTime - currentDateTime;

            // Если визит уже прошел
            if (timeDifference.TotalSeconds < 0)
            {
                Console.WriteLine("Визит к доктору уже прошел.");
                return;
            }

            // Вычисление оставшихся часов
            double remainingHours = timeDifference.TotalHours;

            // Определение, первая или вторая половина дня
            string partOfDay = visitDateTime.Hour < 12 ? "первая половина дня" : "вторая половина дня";

            // Вывод сообщения
            Console.WriteLine($"До визита осталось: {remainingHours:F1} часов.");
            Console.WriteLine($"Визит к доктору будет во {partOfDay}.");
        }
        else
        {
            Console.WriteLine("Ошибка ввода. Введите дату и время в правильном формате.");
        }
    }
}