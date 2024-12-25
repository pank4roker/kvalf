using System;
using System.Linq;

struct Employee
{
    public string LastName;     // Фамилия
    public string FirstName;    // Имя
    public string Patronymic;   // Отчество
    public string Position;     // Должность
    public decimal Salary;      // Зарплата
    public DateTime BirthDate;  // Дата рождения

    // Метод для вычисления возраста сотрудника
    public int GetAge()
    {
        int age = DateTime.Now.Year - BirthDate.Year;
        if (DateTime.Now.Month < BirthDate.Month || (DateTime.Now.Month == BirthDate.Month && DateTime.Now.Day < BirthDate.Day))
        {
            age--;
        }
        return age;
    }

    // Метод для вывода информации о сотруднике
    public void PrintInfo()
    {
        Console.WriteLine($"{LastName,-15}{FirstName,-10}{Patronymic,-15}{Position,-20}{Salary,-10:C}{BirthDate.ToShortDateString(),-15}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Ввод количества сотрудников
        Console.Write("Введите количество сотрудников: ");
        int n = int.Parse(Console.ReadLine());

        Employee[] employees = new Employee[n];  // Массив сотрудников

        // Ввод данных о сотрудниках
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine($"\nВведите данные для сотрудника {i + 1}:");
            Console.Write("Фамилия: ");
            employees[i].LastName = Console.ReadLine();
            Console.Write("Имя: ");
            employees[i].FirstName = Console.ReadLine();
            Console.Write("Отчество: ");
            employees[i].Patronymic = Console.ReadLine();
            Console.Write("Должность: ");
            employees[i].Position = Console.ReadLine();
            Console.Write("Зарплата: ");
            employees[i].Salary = decimal.Parse(Console.ReadLine());
            Console.Write("Дата рождения (в формате ГГГГ-ММ-ДД): ");
            employees[i].BirthDate = DateTime.Parse(Console.ReadLine());
        }

        // Вывод всех сотрудников
        Console.WriteLine("\nСведения о сотрудниках:");
        Console.WriteLine($"{"Фамилия",-15}{"Имя",-10}{"Отчество",-15}{"Должность",-20}{"Зарплата",-10}{"Дата рождения",-15}");
        foreach (var employee in employees)
        {
            employee.PrintInfo();
        }

        // Подсчет средней зарплаты
        decimal averageSalary = employees.Average(e => e.Salary);
        Console.WriteLine($"\nСредняя зарплата: {averageSalary:C}");

        // Вывод сотрудников с зарплатой выше средней и возрастом менее 30 лет
        var filteredEmployees = employees.Where(e => e.Salary > averageSalary && e.GetAge() < 30).ToArray();

        if (filteredEmployees.Length > 0)
        {
            Console.WriteLine("\nСотрудники с зарплатой выше средней и возрастом менее 30 лет:");
            Console.WriteLine($"{"Фамилия",-15}{"Имя",-10}{"Отчество",-15}{"Должность",-20}{"Зарплата",-10}{"Дата рождения",-15}");
            foreach (var employee in filteredEmployees)
            {
                employee.PrintInfo();
            }
        }
        else
        {
            Console.WriteLine("\nНет сотрудников с зарплатой выше средней и возрастом менее 30 лет.");
        }
    }
}
