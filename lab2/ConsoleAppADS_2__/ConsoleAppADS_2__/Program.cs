using System;
namespace ConsoleAppADS
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("rndmatrix-виведення рандомної матрицi");
                Console.WriteLine("clear-очистка консолi");
                Console.WriteLine("controlmatrix-виведення контрольної матрицi");
                Console.WriteLine("close-закривання консолi");
                Console.WriteLine("help-навiгатор");
                try
                {
                    string command = Console.ReadLine();

                    switch (command)
                    {
                        case "rndmatrix":
                            Console.Write("M: "); int M = int.Parse(Console.ReadLine());
                            Console.Write("k: "); int k = int.Parse(Console.ReadLine());
                            int[,] matrix = new int[M, M];
                            Makingrandommatrix(matrix);
                            Following(M, k, matrix);
                            break;
                        case "clear":
                            Console.Clear();
                            break;
                        case "controlmatrix":
                            Console.Write("M: "); int M1 = int.Parse(Console.ReadLine());
                            Console.Write("k: "); int k1 = int.Parse(Console.ReadLine());
                            int[,] matrix1 = new int[M1, M1];
                            Makingcontrolmatrix(matrix1);
                            Following(M1, k1, matrix1);
                            break;
                        case "close":
                            System.Environment.Exit(1);
                            break;
                        case "help":
                            Console.WriteLine("rndmatrix-виведення рандомної матрицi");
                            Console.WriteLine("clear-очистка консолi");
                            Console.WriteLine("controlmatrix-виведення контрольної матрицi");
                            Console.WriteLine("close-закривання консолi");
                            Console.WriteLine("help-навiгатор");
                            break;
                        default:
                            Console.WriteLine("Invalid command");
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("Error");
                }
            }
        }
        static void Makingcontrolmatrix(int[,] matrix)
        {
            for (int i = 0, s = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(0); j++, s++)
                {
                    matrix[i, j] = s;
                    Console.Write($"{matrix[i, j],3}");
                }
                Console.WriteLine();
            }
        }
        static void Makingrandommatrix(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rnd.Next(1, 10);
                    Console.Write(matrix[i, j] + " ");
                }
                Console.WriteLine();
            }
        }
        static void Following(int M, int k, int[,] matrix)
        {
            int min_value = 10;
            int max_belongs = 0;
            int max = 0;
            int t = 0, p = 0;
            Console.WriteLine();
            for (int i = 0; i < M - 1; i++)
            {
                if (i % 2 == 0)
                {
                    for (int j = M - 1; j > i; j--)
                    {
                        Console.Write($"{matrix[i, j]} ({i},{j})");
                        Console.Write("  ");
                        if (matrix[i, j] % k == 0)
                        {
                            if (matrix[i, j] < min_value)
                            {
                                min_value = matrix[i, j];
                                t = i;
                                p = j;
                            }
                        }
                    }
                }
                else
                {
                    for (int j = i + 1; j <= M - 1; j++)
                    {
                        Console.Write($"{matrix[i, j]} ({i},{j})");
                        Console.Write("  ");
                        if (matrix[i, j] % k == 0)
                        {
                            if (matrix[i, j] < min_value)
                            {
                                min_value = matrix[i, j];
                                t = i;
                                p = j;
                            }
                        }
                    }
                }
            }
            Console.WriteLine();
            if (min_value == 10)
            {
                Console.WriteLine("Searching element is not found");
            }
            else { Console.WriteLine($"{min_value}({t},{p}) above diagonal"); }
            for (int i = M - 1; i >= 0; i--)
            {
                Console.Write($"{matrix[i, i]} ({i},{i})");
                Console.Write(" ");
            }
            for (int i = M - 1; i >= 0; i--)
            {
                if (min_value > matrix[i, i])
                {
                    min_value = matrix[i, i];
                    t = i;
                }
            }
            for (int i = M - 1; i >= 0; i--)
            {
                if (max_belongs < matrix[i, i])
                {
                    max_belongs = matrix[i, i];
                    p = i;
                }
            }
            Console.WriteLine();
            Console.WriteLine($"{min_value}({t},{t}) {max_belongs}({p},{p}) belongs diagonal");
            for (int j = 0; j <= M - 1; j++)
            {
                if (j % 2 == 0)
                {
                    for (int i = j + 1; i <= M - 1; i++)
                    {
                        Console.Write($"{matrix[i, j]} ({i},{j})");
                        Console.Write(" ");
                        if (matrix[i, j] % (max_belongs - min_value) == 0)
                        {
                            if (max < matrix[i, i])
                            {
                                max = matrix[i, j];
                                t = i;
                                p = j;
                            }
                        }
                    }
                }
                else
                {
                    for (int i = M - 1; i >= j + 1; i--)
                    {
                        Console.Write($"{matrix[i, j]} ({i},{j})");
                        Console.Write(" ");
                        if (matrix[i, j] % (max_belongs - min_value) == 0)
                        {
                            if (max < matrix[i, i])
                            {
                                max = matrix[i, j];
                                t = i;
                                p = j;
                            }
                        }
                    }
                }
            }
            Console.WriteLine($"\n{max}({t},{p}) Under diagonal");
        }
    }
}

