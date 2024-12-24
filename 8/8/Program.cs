using System;

namespace SettlementApp
{
    // Абстрактный класс Населенный пункт
    abstract class Settlement
    {
        public string Name { get; set; }  // Название населенного пункта

        // Конструктор
        public Settlement(string name)
        {
            Name = name;
        }

        // Абстрактный метод для расчета плотности населения
        public abstract double PopulationDensity();

        // Метод для вывода описания объекта
        public virtual void PrintDescription()
        {
            Console.WriteLine($"Населенный пункт: {Name}");
        }
    }

    // Класс Село
    class Village : Settlement
    {
        public int HousesCount { get; set; }  // Количество домов
        public double AverageResidentsPerHouse { get; set; }  // Среднее количество жителей в доме
        public double Area { get; set; }  // Площадь села

        // Конструктор
        public Village(string name, int housesCount, double averageResidentsPerHouse, double area)
            : base(name)
        {
            HousesCount = housesCount;
            AverageResidentsPerHouse = averageResidentsPerHouse;
            Area = area;
        }

        // Переопределенный метод для расчета плотности населения
        public override double PopulationDensity()
        {
            // Плотность населения = (Количество домов * Среднее количество жителей в доме) / Площадь
            return (HousesCount * AverageResidentsPerHouse) / Area;
        }

        // Переопределенный метод для вывода описания объекта
        public override void PrintDescription()
        {
            base.PrintDescription();
            Console.WriteLine($"Тип: Село");
            Console.WriteLine($"Количество домов: {HousesCount}, Среднее число жителей в доме: {AverageResidentsPerHouse}, Площадь: {Area} кв. км");
        }
    }

    // Класс Город
    class City : Settlement
    {
        public int Population { get; set; }  // Количество жителей
        public double Area { get; set; }  // Площадь города

        // Конструктор
        public City(string name, int population, double area)
            : base(name)
        {
            Population = population;
            Area = area;
        }

        // Переопределенный метод для расчета плотности населения
        public override double PopulationDensity()
        {
            // Плотность населения = Количество жителей / Площадь
            return Population / Area;
        }

        // Переопределенный метод для вывода описания объекта
        public override void PrintDescription()
        {
            base.PrintDescription();
            Console.WriteLine($"Тип: Город");
            Console.WriteLine($"Количество жителей: {Population}, Площадь: {Area} кв. км");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создаем объект класса Село
            Village village = new Village("Село Лесное", 50, 4.5, 120.5);
            village.PrintDescription();
            Console.WriteLine($"Плотность населения в селе: {village.PopulationDensity()} человек на кв. км.");
            Console.WriteLine();

            // Создаем объект класса Город
            City city = new City("Город Полиция", 500000, 300);
            city.PrintDescription();
            Console.WriteLine($"Плотность населения в городе: {city.PopulationDensity()} человек на кв. км.");
            Console.WriteLine();
        }
    }
}
