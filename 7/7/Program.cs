using System;

namespace BusApp
{
    // Базовый класс Автобус
    class Bus
    {
        // Поля
        public string Brand { get; set; }
        public int Seats { get; set; }
        public double TicketPrice { get; set; }

        // Конструктор
        public Bus(string brand, int seats, double ticketPrice)
        {
            Brand = brand;
            Seats = seats;
            TicketPrice = ticketPrice;
        }

        // Метод для расчета общей стоимости всех мест
        public double TotalCost()
        {
            return Seats * TicketPrice;
        }

        // Виртуальный метод для вывода информации об автобусе
        public virtual void PrintInfo()
        {
            Console.WriteLine($"Автобус: {Brand}, Количество мест: {Seats}, Стоимость билета: {TicketPrice} руб.");
            Console.WriteLine($"Общая стоимость всех мест: {TotalCost()} руб.");
        }
    }

    // Производный класс Туристический автобус
    class TouristBus : Bus
    {
        // Поле
        public double ExcursionPrice { get; set; }

        // Конструктор
        public TouristBus(string brand, int seats, double ticketPrice, double excursionPrice)
            : base(brand, seats, ticketPrice) // Вызов конструктора базового класса
        {
            ExcursionPrice = excursionPrice;
        }

        // Переопределенный метод для вывода информации о туристическом автобусе
        public override void PrintInfo()
        {
            double totalCostWithExcursion = Seats * (TicketPrice + ExcursionPrice);
            Console.WriteLine($"Туристический автобус: {Brand}, Количество мест: {Seats}, Стоимость билета: {TicketPrice} руб., Стоимость экскурсии: {ExcursionPrice} руб.");
            Console.WriteLine($"Общая стоимость всех мест с учетом экскурсии: {totalCostWithExcursion} руб.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создание объекта базового класса (Автобус)
            Bus bus = new Bus("Mercedes", 30, 500);
            bus.PrintInfo(); // Вывод информации о автобусе

            Console.WriteLine(); // Пустая строка для разделения вывода

            // Создание объекта производного класса (Туристический автобус)
            TouristBus touristBus = new TouristBus("Volvo", 40, 600, 150);
            touristBus.PrintInfo(); // Вывод информации о туристическом автобусе

            // Проверка общей стоимости с учетом экскурсии для туристического автобуса
            double totalCostWithExcursion = touristBus.TotalCost() + touristBus.Seats * touristBus.ExcursionPrice;
            Console.WriteLine($"Общая стоимость всех мест с экскурсионной наценкой: {totalCostWithExcursion} руб.");
        }
    }
}
