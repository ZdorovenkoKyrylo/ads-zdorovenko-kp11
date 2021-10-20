using System;
namespace Lab_01_ADS
{
    class Program
    {
        static void Main(string[] args)
        {
            double x, y, z, a, b;
            Console.Write("x: "); x = double.Parse(Console.ReadLine());
            Console.Write("y: "); y = double.Parse(Console.ReadLine());
            Console.Write("z: "); z = double.Parse(Console.ReadLine());
            if (x == -z)
            {
                Console.WriteLine("Error");
            }
            else if (x == y)
            {
                Console.WriteLine("Error");
            }
            else if (Math.Log(Math.Abs(y - x)) == -2)
            {
                Console.WriteLine("Error");
            }
            else
            {
                a = Math.Log10((Math.Abs(x + z)) / (1.0 + Math.Log(Math.Abs(y - x)) / 2) + (2 * y));
                Console.WriteLine("a: " + a.ToString());
                if (a == 0)
                {
                    Console.WriteLine("Error");
                }
                else if (a <= -z)
                {
                    Console.WriteLine("Error");
                }
                else if (x == 0)
                {
                    if (a > 0)
                    {
                        Console.WriteLine("Error");
                    }
                }
                else if (x < 0)
                {
                    if ((1 / a) % 2 == 0)
                    {
                        Console.WriteLine("Error");
                    }
                }
                b = Math.Log(a + z) / Math.Pow(a, 2) + Math.Pow(x, -a);
                Console.WriteLine("b: " + b.ToString());
            }
        }
    }
}
