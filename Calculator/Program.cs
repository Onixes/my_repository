using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Calculator
    {
        private Dictionary<string, Func<double, double, double>> container = new Dictionary<string, Func<double, double, double>>
        {
            ["+"] = (x,y) => x + y,
            ["-"] = (x,y) => x - y,
            ["/"] = (x,y) => x / y,
            ["*"] = (x,y) => x * y
        };

        public double Calc(string str, double x, double y)
        {
            if(!container.ContainsKey(str))
            {
                throw new ArgumentException(string.Format($"Недопустимый ключ {str}"));
            }
            return container[str](x, y);

        }

    }
    class Program
    {
        static void Main(string[] args)
        {
            Calculator instance = new Calculator();
            //instance.container.Add("mod", (x, y) => x % y);
            while (true)
            {
                Console.WriteLine("Введите число x -> ");
                double x = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Введите число y -> ");
                double y = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Выберите операцию: + - / * mod");
                string str = Console.ReadLine();
                if (!string.IsNullOrEmpty(str))
                {
                    Console.WriteLine(instance.Calc(str, x, y));
                }
            }

            Console.ReadKey();
        }
    }
}
