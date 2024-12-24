using System;
using System.Collections.Generic;

namespace TransportApp
{
    class Program
    {
        static void Main(string[] args)
        {
            // Ввод количества перевозок
            Console.Write("Введите количество перевозок: ");
            int N = int.Parse(Console.ReadLine());

            // Массив для хранения объектов перевозок
            List<Transport> transports = new List<Transport>();

            // Ввод данных для каждой перевозки
            for (int i = 0; i < N; i++)
            {
                Console.WriteLine($"Введите данные для перевозки {i + 1}:");

                Console.Write("Номер рейса: ");
                string flightNumber = Console.ReadLine();

                Console.Write("Пункт назначения: ");
                string destination = Console.ReadLine();

                Console.Write("Вес груза (кг): ");
                double weight = double.Parse(Console.ReadLine());

                // Создание объекта перевозки и добавление в список
                Transport transport = new Transport(flightNumber, destination, weight);
                transports.Add(transport);
            }

            // Вывод перевозки с минимальным весом
            Transport minWeightTransport = Transport.GetMinWeightTransport(transports);
            Console.WriteLine("\nПеревозка с минимальным весом:");
            minWeightTransport.Print();

            // Вывод суммарного объема всех перевозок
            double totalVolume = Transport.GetTotalVolume(transports);
            Console.WriteLine($"\nСуммарный объем всех перевозок: {totalVolume} м³");
        }
    }

    // Класс, представляющий перевозку
    class Transport
    {
        public string FlightNumber { get; set; }
        public string Destination { get; set; }
        public double Weight { get; set; }

        // Конструктор для инициализации данных
        public Transport(string flightNumber, string destination, double weight)
        {
            FlightNumber = flightNumber;
            Destination = destination;
            Weight = weight;
        }

        // Метод для вычисления объема перевозки (1 кг = 1 м³)
        public double CalculateVolume()
        {
            return Weight;  // Простой расчет, 1 кг = 1 м³
        }

        // Метод для вывода информации о перевозке
        public void Print()
        {
            Console.WriteLine($"№ рейса: {FlightNumber}, Пункт назначения: {Destination}, Вес: {Weight} кг, Объем: {CalculateVolume()} м³");
        }

        // Статический метод для нахождения перевозки с минимальным весом
        public static Transport GetMinWeightTransport(List<Transport> transports)
        {
            Transport minWeightTransport = transports[0];
            foreach (var transport in transports)
            {
                if (transport.Weight < minWeightTransport.Weight)
                {
                    minWeightTransport = transport;
                }
            }
            return minWeightTransport;
        }

        // Статический метод для вычисления суммарного объема всех перевозок
        public static double GetTotalVolume(List<Transport> transports)
        {
            double totalVolume = 0;
            foreach (var transport in transports)
            {
                totalVolume += transport.CalculateVolume();
            }
            return totalVolume;
        }
    }
}
