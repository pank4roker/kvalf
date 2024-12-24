using System;

namespace FurnitureApp
{
    // Базовый класс Стол
    class Table
    {
        // Поля
        public string Name { get; set; }
        public double Area { get; set; }

        // Конструктор
        public Table(string name, double area)
        {
            Name = name;
            Area = area;
        }

        // Метод для расчета стоимости стола
        public double CalculateCost()
        {
            return 50 + 100 * Area;
        }

        // Виртуальный метод для вывода информации о столе
        public virtual void PrintInfo()
        {
            Console.WriteLine($"Стол: {Name}, Площадь: {Area} м², Стоимость: {CalculateCost()} руб.");
        }
    }

    // Производный класс Письменный стол
    class WritingTable : Table
    {
        // Поля
        public string Material { get; set; }
        public double FinishingCost { get; set; }

        // Конструктор
        public WritingTable(string name, double area, string material, double finishingCost)
            : base(name, area) // Вызов конструктора базового класса
        {
            Material = material;
            FinishingCost = finishingCost;
        }

        // Переопределенный метод для вывода информации о письменном столе
        public override void PrintInfo()
        {
            double totalCost = CalculateCost() + FinishingCost;
            Console.WriteLine($"Письменный стол: {Name}, Площадь: {Area} м², Материал: {Material}, Стоимость отделки: {FinishingCost} руб., Общая стоимость: {totalCost} руб.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Создание объекта базового класса
            Table table = new Table("Обычный стол", 2.5);
            table.PrintInfo(); // Вывод информации о базовом столе

            Console.WriteLine(); // Пустая строка для разделения вывода

            // Создание объекта производного класса
            WritingTable writingTable = new WritingTable("Письменный стол", 3.0, "Дерево", 200);
            writingTable.PrintInfo(); // Вывод информации о письменном столе

            // Проверка стоимости для письменного стола
            double writingTableCost = writingTable.CalculateCost() + writingTable.FinishingCost;
            Console.WriteLine($"Стоимость письменного стола с отделкой: {writingTableCost} руб.");
        }
    }
}
