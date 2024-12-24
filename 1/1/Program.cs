
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите стороны треугольнгика: ");
            Console.Write("A =  ");
            int a = Convert.ToInt32(Console.ReadLine());
            Console.Write("B =  ");
            int b = Convert.ToInt32(Console.ReadLine());
            Console.Write("C =  ");
            int c = Convert.ToInt32(Console.ReadLine());
            Triangle triangle = new Triangle(a, b, c);
            triangle.ShowInformation();
            Console.WriteLine(triangle.TriangleTip());
        }
    }

    public class Triangle
    {
        public int A { get; set; }
        public int B { get; set; }
        public int C { get; set; }

        public Triangle(int a, int b, int c)
        {
            A = a;
            B = b;
            C = c;
        }

        public void ShowInformation()
        {
            Console.WriteLine($"Треугольник со сторонами:\na = {A}\nb = {B}\nc = {C}");
        }

        public string TriangleTip()
        {
            if (A <= 0 || B <= 0 || C <= 0)
            {
                return "Ошибка: длина стороны должна быть положительным числом";
            }

            if (A == B && B == C)
            {
                return "Равносторонний";
            }
            else if(A==B||B==C||A==C)
            {
                return "Равнобедренный";
            }
            else
            {
                return "Разносторонний";
            }
        }
    }