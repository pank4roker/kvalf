using System;
using System.Collections.Generic;

namespace School
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ввод количества школьников
            Console.Write("Введите количество школьников: ");
            int N = int.Parse(Console.ReadLine());

            // Массив для хранения объектов школьников
            List<Student> students = new List<Student>();

            // Ввод данных для каждого школьника
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine($"Введите данные для школьника {i + 1}:");

                Console.Write("Ф.И.О: ");
                string name = Console.ReadLine();

                Console.Write("Пол (М/Ж): ");
                string genderInput = Console.ReadLine().ToLower();
                string gender = (genderInput == "м" || genderInput == "мальчик") ? "мальчик" :
                                (genderInput == "ж" || genderInput == "девочка") ? "девочка" :
                                "неизвестно";  // Добавим проверку на неправильный ввод

                Console.Write("Год рождения: ");
                int birthYear;
                while (!int.TryParse(Console.ReadLine(), out birthYear) || birthYear < 1900 || birthYear > DateTime.Now.Year)
                {
                    Console.Write("Неверный ввод. Введите год рождения (например, 2005): ");
                }

                // Создание объекта школьника и добавление в список
                Student student = new Student(name, gender, birthYear);
                students.Add(student);
            }

            // Вывод статистики по мальчикам и девочкам
            Console.WriteLine("\nСписок мальчиков:");
            foreach (var student in students)
            {
                if (student.IsBoy())
                {
                    student.Print();
                }
            }

            Console.WriteLine("\nСписок девочек:");
            foreach (var student in students)
            {
                if (student.IsGirl())
                {
                    student.Print();
                }
            }

            // Вывод количества мальчиков и девочек
            Console.WriteLine($"\nКоличество мальчиков: {Student.BoysCount}");
            Console.WriteLine($"Количество девочек: {Student.GirlsCount}");
        }
    }

    // Класс школьника
    class Student
    {
        public string FullName { get; set; }
        public string Gender { get; set; }
        public int BirthYear { get; set; }

        // Статические поля для подсчета количества мальчиков и девочек
        public static int BoysCount { get; private set; } = 0;
        public static int GirlsCount { get; private set; } = 0;

        // Конструктор для инициализации данных школьника
        public Student(string fullName, string gender, int birthYear)
        {
            FullName = fullName;
            Gender = gender;
            BirthYear = birthYear;

            // Увеличиваем соответствующие счетчики в зависимости от пола
            if (Gender == "мальчик")
            {
                BoysCount++;
            }
            else if (Gender == "девочка")
            {
                GirlsCount++;
            }
        }

        // Метод для проверки, является ли школьник мальчиком
        public bool IsBoy()
        {
            return Gender == "мальчик";
        }

        // Метод для проверки, является ли школьник девочкой
        public bool IsGirl()
        {
            return Gender == "девочка";
        }

        // Метод для вывода информации о школьнике
        public void Print()
        {
            Console.WriteLine($"Ф.И.О: {FullName}, Пол: {Gender}, Год рождения: {BirthYear}");
        }
    }
}
