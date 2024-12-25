using System;

struct Employee
{
    public string LastName;     // Фамилия
    public string FirstName;    // Имя
    public string Patronymic;   // Отчество
    public string Position;     // Должность
    public DateTime HireDate;   // Дата приема на работу

    // Метод для вывода информации о сотруднике
    public void PrintInfo()
    {
        Console.WriteLine($"{LastName,-15}{FirstName,-10}{Patronymic,-15}{Position,-20}{HireDate.ToShortDateString(),-15}");
    }

    // Метод для вычисления стажа работы
    public int GetYearsOfService()
    {
        return DateTime.Now.Year - HireDate.Year;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.Write("Введите количество сотрудников: ");
        int n = int.Parse(Console.ReadLine());  // Количество сотрудников

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
            Console.Write("Дата приема на работу (в формате ГГГГ-ММ-ДД): ");
            employees[i].HireDate = DateTime.Parse(Console.ReadLine());
        }

        // Вывод всех сотрудников в табличном виде
        Console.WriteLine("\nСведения о сотрудниках:");
        Console.WriteLine($"{"Фамилия",-15}{"Имя",-10}{"Отчество",-15}{"Должность",-20}{"Дата приема",-15}");
        foreach (var employee in employees)
        {
            employee.PrintInfo();
        }

        // Подсчет среднего стажа работы
        double averageYearsOfService = 0;
        foreach (var employee in employees)
        {
            averageYearsOfService += employee.GetYearsOfService();
        }
        averageYearsOfService /= n;

        Console.WriteLine($"\nСредний стаж работы сотрудников: {averageYearsOfService:F2} лет");

        // Вывод сотрудников с стажем более 30 лет
        var employeesOver30Years = Array.FindAll(employees, e => e.GetYearsOfService() > 30);

        if (employeesOver30Years.Length > 0)
        {
            Console.WriteLine("\nСотрудники с стажем более 30 лет:");
            Console.WriteLine($"{"Фамилия",-15}{"Имя",-10}{"Отчество",-15}{"Должность",-20}{"Дата приема",-15}");
            foreach (var employee in employeesOver30Years)
            {
                employee.PrintInfo();
            }
        }
        else
        {
            Console.WriteLine("\nНет сотрудников с стажем более 30 лет.");
        }
    }
}
