using System;
using System.Collections.Generic;
using System.Linq;

class FurnitureOrder
{
    public int OrderNumber { get; set; } // Номер заказа
    public DateTime OrderDate { get; set; } // Дата заказа
    public string CustomerName { get; set; } // ФИО заказчика
    public string CustomerAddress { get; set; } // Адрес заказчика
    public int CompletionTime { get; set; } // Срок выполнения в днях
    public decimal OrderCost { get; set; } // Стоимость заказа

    public FurnitureOrder(int orderNumber, DateTime orderDate, string customerName, string customerAddress, int completionTime, decimal orderCost)
    {
        OrderNumber = orderNumber;
        OrderDate = orderDate;
        CustomerName = customerName;
        CustomerAddress = customerAddress;
        CompletionTime = completionTime;
        OrderCost = orderCost;
    }

    public override string ToString()
    {
        return $"{OrderNumber,-10}{OrderDate:dd.MM.yyyy,-15}{CustomerName,-25}{CustomerAddress,-30}{CompletionTime,-15}{OrderCost,-10:C}";
    }
}

class Program
{
    static void Main(string[] args)
    {
        // Создаем коллекцию заказов
        List<FurnitureOrder> orders = new List<FurnitureOrder>
        {
            new FurnitureOrder(1, new DateTime(2024, 12, 1), "Иванов Иван Иванович", "ул. Ленина, д. 10", 7, 15000),
            new FurnitureOrder(2, new DateTime(2024, 12, 5), "Петров Петр Петрович", "ул. Пушкина, д. 5", 10, 20000),
            new FurnitureOrder(3, new DateTime(2024, 12, 10), "Сидоров Сергей Викторович", "ул. Советская, д. 20", 5, 12000),
            new FurnitureOrder(4, new DateTime(2024, 12, 3), "Кузнецова Анна Васильевна", "ул. Мира, д. 15", 3, 18000),
            new FurnitureOrder(5, new DateTime(2024, 12, 8), "Алексеева Мария Николаевна", "ул. Гоголя, д. 8", 14, 25000)
        };

        // Вывод информации обо всех заказах
        Console.WriteLine("Список всех заказов:");
        Console.WriteLine($"{"№ заказа",-10}{"Дата заказа",-15}{"ФИО заказчика",-25}{"Адрес заказчика",-30}{"Срок (дни)",-15}{"Стоимость",-10}");
        foreach (var order in orders)
        {
            Console.WriteLine(order);
        }

        // Сортировка по ФИО заказчика
        var sortedByName = orders.OrderBy(o => o.CustomerName).ToList();
        Console.WriteLine("\nСписок заказов, отсортированный по ФИО заказчика:");
        PrintOrders(sortedByName);

        // Сортировка по сроку выполнения
        var sortedByCompletionTime = orders.OrderBy(o => o.CompletionTime).ToList();
        Console.WriteLine("\nСписок заказов, отсортированный по сроку выполнения:");
        PrintOrders(sortedByCompletionTime);

        // Сортировка по стоимости заказа
        var sortedByCost = orders.OrderBy(o => o.OrderCost).ToList();
        Console.WriteLine("\nСписок заказов, отсортированный по стоимости:");
        PrintOrders(sortedByCost);
    }

    static void PrintOrders(List<FurnitureOrder> orders)
    {
        Console.WriteLine($"{"№ заказа",-10}{"Дата заказа",-15}{"ФИО заказчика",-25}{"Адрес заказчика",-30}{"Срок (дни)",-15}{"Стоимость",-10}");
        foreach (var order in orders)
        {
            Console.WriteLine(order);
        }
    }
}
