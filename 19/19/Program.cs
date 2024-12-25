using System;
using System.Collections.Generic;
using System.Linq;

class Employee
{
    public string LastName { get; set; }     // Фамилия
    public string FirstName { get; set; }    // Имя
    public string MiddleName { get; set; }   // Отчество
    public string Position { get; set; }     // Должность
    public string Gender { get; set; }       // Пол
    public DateTime HireDate { get; set; }   // Дата приема на работу

    public Employee(string lastName, string firstName, string middleName, string position, string gender, DateTime hireDate)
    {
        LastName = lastName;
        FirstName = firstName;
        MiddleName = middleName;
        Position = position;
        Gender = gender;
        HireDate = hireDate;
    }

    public override string ToString()
    {
        return $"{LastName,-15}{FirstName,-15}{MiddleName,-20}{Position,-20}{Gender,-10}{HireDate:dd.MM.yyyy}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создаем коллекцию сотрудников
        List<Employee> employees = new List<Employee>
        {
            new Employee("Иванов", "Иван", "Иванович", "Менеджер", "М", new DateTime(2015, 5, 12)),
            new Employee("Петров", "Петр", "Сергеевич", "Инженер", "М", new DateTime(2010, 3, 22)),
            new Employee("Сидорова", "Анна", "Викторовна", "Бухгалтер", "Ж", new DateTime(2020, 8, 15)),
            new Employee("Кузнецова", "Мария", "Николаевна", "Аналитик", "Ж", new DateTime(2018, 1, 5)),
            new Employee("Алексеев", "Сергей", "Владимирович", "Директор", "М", new DateTime(2008, 11, 1))
        };

        // Вывод информации обо всех сотрудниках
        Console.WriteLine("Список всех сотрудников:");
        Console.WriteLine($"{"Фамилия",-15}{"Имя",-15}{"Отчество",-20}{"Должность",-20}{"Пол",-10}{"Дата приема"}");
        foreach (var employee in employees)
        {
            Console.WriteLine(employee);
        }

        // Определяем текущую дату
        DateTime currentDate = DateTime.Now;

        // Список сотрудников со стажем меньше 10 лет
        var lessThan10Years = employees.Where(e => (currentDate - e.HireDate).TotalDays / 365 < 10).ToList();

        // Список сотрудников со стажем 10 лет и более
        var moreThan10Years = employees.Where(e => (currentDate - e.HireDate).TotalDays / 365 >= 10).ToList();

        // Вывод списка сотрудников со стажем меньше 10 лет
        Console.WriteLine("\nСотрудники со стажем меньше 10 лет:");
        if (lessThan10Years.Any())
        {
            PrintEmployees(lessThan10Years);
        }
        else
        {
            Console.WriteLine("Нет сотрудников со стажем меньше 10 лет.");
        }

        // Вывод списка сотрудников со стажем 10 лет и более
        Console.WriteLine("\nСотрудники со стажем 10 лет и более:");
        if (moreThan10Years.Any())
        {
            PrintEmployees(moreThan10Years);
        }
        else
        {
            Console.WriteLine("Нет сотрудников со стажем 10 лет и более.");
        }
    }

    static void PrintEmployees(List<Employee> employees)
    {
        Console.WriteLine($"{"Фамилия",-15}{"Имя",-15}{"Отчество",-20}{"Должность",-20}{"Пол",-10}{"Дата приема"}");
        foreach (var employee in employees)
        {
            Console.WriteLine(employee);
        }
    }
}
