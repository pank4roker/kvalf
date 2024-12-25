using System;
using System.Collections.Generic;
using System.Linq;

class Employee
{
    public int EmployeeId { get; set; }
    public string FullName { get; set; }
    public DateTime BirthDate { get; set; }
    public string Gender { get; set; }
    public DateTime DateOfJoining { get; set; }
    public string Position { get; set; }
    public decimal Salary { get; set; }

    // Конструктор для удобства создания объектов
    public Employee(int employeeId, string fullName, DateTime birthDate, string gender, DateTime dateOfJoining, string position, decimal salary)
    {
        EmployeeId = employeeId;
        FullName = fullName;
        BirthDate = birthDate;
        Gender = gender;
        DateOfJoining = dateOfJoining;
        Position = position;
        Salary = salary;
    }

    // Метод для отображения информации о сотруднике
    public override string ToString()
    {
        return $"{EmployeeId,-10}{FullName,-20}{BirthDate.ToShortDateString(),-15}{Gender,-5}{DateOfJoining.ToShortDateString(),-20}{Position,-15}{Salary,-10:C2}";
    }
}

class Program
{
    static void Main()
    {
        // Создание списка сотрудников
        List<Employee> employees = new List<Employee>
        {
            new Employee(1, "Иванов Иван Иванович", new DateTime(1985, 6, 15), "м", new DateTime(2010, 3, 1), "Менеджер", 50000),
            new Employee(2, "Петрова Мария Сергеевна", new DateTime(1990, 8, 25), "ж", new DateTime(2015, 7, 12), "Бухгалтер", 40000),
            new Employee(3, "Сидоров Александр Викторович", new DateTime(1980, 1, 30), "м", new DateTime(2005, 10, 20), "Директор", 100000),
            new Employee(4, "Федорова Ольга Валерьевна", new DateTime(1988, 11, 10), "ж", new DateTime(2018, 5, 18), "Маркетолог", 45000),
            new Employee(5, "Кузнецов Сергей Александрович", new DateTime(1975, 4, 8), "м", new DateTime(2000, 9, 15), "Разработчик", 60000)
        };

        // Вывод информации обо всех сотрудниках
        Console.WriteLine("Информация о всех сотрудниках:");
        Console.WriteLine($"{"Табельный номер",-10}{"ФИО",-20}{"Дата рождения",-15}{"Пол",-5}{"Дата поступления",-20}{"Должность",-15}{"Оклад",-10}");
        foreach (var employee in employees)
        {
            Console.WriteLine(employee);
        }

        // Сортировка по табельному номеру
        var sortedByEmployeeId = employees.OrderBy(e => e.EmployeeId).ToList();
        Console.WriteLine("\nОтсортировано по табельному номеру:");
        Console.WriteLine($"{"Табельный номер",-10}{"ФИО",-20}{"Дата рождения",-15}{"Пол",-5}{"Дата поступления",-20}{"Должность",-15}{"Оклад",-10}");
        foreach (var employee in sortedByEmployeeId)
        {
            Console.WriteLine(employee);
        }

        // Сортировка по ФИО
        var sortedByFullName = employees.OrderBy(e => e.FullName).ToList();
        Console.WriteLine("\nОтсортировано по ФИО:");
        Console.WriteLine($"{"Табельный номер",-10}{"ФИО",-20}{"Дата рождения",-15}{"Пол",-5}{"Дата поступления",-20}{"Должность",-15}{"Оклад",-10}");
        foreach (var employee in sortedByFullName)
        {
            Console.WriteLine(employee);
        }

        // Сортировка по окладу
        var sortedBySalary = employees.OrderBy(e => e.Salary).ToList();
        Console.WriteLine("\nОтсортировано по окладу:");
        Console.WriteLine($"{"Табельный номер",-10}{"ФИО",-20}{"Дата рождения",-15}{"Пол",-5}{"Дата поступления",-20}{"Должность",-15}{"Оклад",-10}");
        foreach (var employee in sortedBySalary)
        {
            Console.WriteLine(employee);
        }
    }
}
