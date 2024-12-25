using System;
using System.Collections.Generic;
using System.Linq;

class Car
{
    public string Model { get; set; } // Марка автомобиля
    public string Manufacturer { get; set; } // Производитель
    public string EngineType { get; set; } // Тип двигателя
    public int YearOfManufacture { get; set; } // Год выпуска
    public DateTime RegistrationDate { get; set; } // Дата регистрации

    public Car(string model, string manufacturer, string engineType, int yearOfManufacture, DateTime registrationDate)
    {
        Model = model;
        Manufacturer = manufacturer;
        EngineType = engineType;
        YearOfManufacture = yearOfManufacture;
        RegistrationDate = registrationDate;
    }

    public override string ToString()
    {
        return $"Марка: {Model}, Производитель: {Manufacturer}, Тип двигателя: {EngineType}, Год выпуска: {YearOfManufacture}, Дата регистрации: {RegistrationDate:dd.MM.yyyy}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создаем коллекцию автомобилей
        List<Car> cars = new List<Car>
        {
            new Car("Corolla", "Toyota", "Бензиновый", 2010, new DateTime(2014, 6, 12)),
            new Car("Camry", "Toyota", "Гибрид", 2015, new DateTime(2018, 7, 15)),
            new Car("Civic", "Honda", "Бензиновый", 2018, new DateTime(2021, 5, 20)),
            new Car("Model S", "Tesla", "Электрический", 2020, new DateTime(2022, 1, 10)),
            new Car("Rav4", "Toyota", "Бензиновый", 2012, new DateTime(2013, 8, 3))
        };

        // Вывод информации обо всех автомобилях
        Console.WriteLine("Список всех автомобилей:");
        foreach (var car in cars)
        {
            Console.WriteLine(car);
        }

        // Вывод автомобилей марки "Toyota", зарегистрированных до 01.01.2015
        Console.WriteLine("\nАвтомобили марки \"Toyota\", зарегистрированные до 01.01.2015:");
        var toyotaCars = cars.Where(car => car.Manufacturer == "Toyota" && car.RegistrationDate < new DateTime(2015, 1, 1)).ToList();
        if (toyotaCars.Any())
        {
            foreach (var car in toyotaCars)
            {
                Console.WriteLine(car);
            }
        }
        else
        {
            Console.WriteLine("Нет таких автомобилей.");
        }

        // Список автомобилей, выпущенных за последние 10 лет
        Console.WriteLine("\nАвтомобили, выпущенные за последние 10 лет:");
        var recentCars = cars.Where(car => car.YearOfManufacture >= DateTime.Now.Year - 10).ToList();
        if (recentCars.Any())
        {
            foreach (var car in recentCars)
            {
                Console.WriteLine(car);
            }
        }
        else
        {
            Console.WriteLine("Нет таких автомобилей.");
        }

        // Список автомобилей с регистрацией в 2018-2021 годах
        Console.WriteLine("\nАвтомобили с регистрацией в 2018-2021 годах:");
        var registeredCars = cars.Where(car => car.RegistrationDate.Year >= 2018 && car.RegistrationDate.Year <= 2021).ToList();
        if (registeredCars.Any())
        {
            foreach (var car in registeredCars)
            {
                Console.WriteLine(car);
            }
        }
        else
        {
            Console.WriteLine("Нет таких автомобилей.");
        }
    }
}
