
    class Program
    {
        static void Main(string[] args)
        {
           
            Console.WriteLine("Введите название товара: ");
            string name = Console.ReadLine();
            Console.WriteLine("Введите цену товара: ");
            int price = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Введите количество товара: ");
            int count = Convert.ToInt32(Console.ReadLine());
            Product product = new Product(name, price, count);
            Console.WriteLine(product.Inf());
            Console.WriteLine(product.Stoimost());
        }
    }

    public class Product
    {
        public Product(string name, int price, int count)
        {
            Name = name;
            Price = price;
            Count = count;
        }

        public string Name { get; set; }
        public int Price { get; set; }
        public int Count { get; set; }

        public string Inf()
        {
            return $"{Name}{Price}{Count}";
        }

        public int Stoimost()
        {
            return Price * Count;
        }
        
    }