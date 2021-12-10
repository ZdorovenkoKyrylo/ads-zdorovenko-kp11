using System;
namespace ConsoleAppADS_3
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            int M, N;
            Console.Write("M: "); M = int.Parse(Console.ReadLine());
            Console.Write("N: "); N = int.Parse(Console.ReadLine());
            int[] array = new int[M];
            int[,] matrix = new int[M, N];
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] = rnd.Next(1, 100);                    
                }
            }
            var c = choosing(M, N, matrix);
            painting(matrix, c, M, N);
            Console.WriteLine("*****************");
            sorting(M, N, matrix, array);
            finalfilling(matrix, N, M, array);
            painting(matrix, c, M, N);
        }
        static int [] sorting(int M, int N, int [,] matrix, int [] array)
        {
            int k = 0; int maxvalue = matrix[k, 0];
            bool sorted = false;
            for (int i = 0; i < M; i++, k++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (maxvalue < matrix[i, j])
                    {
                        maxvalue = matrix[i, j];
                    }
                }
                array[i] = maxvalue;
                maxvalue = 0;
            }
            while (!sorted)
            {
                sorted = true;
                for (int j = 1; j <= M - 2; j += 2)
                {
                    if (array[j] < array[j + 1])
                    {
                        int p = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = p;
                        sorted = false;
                    }
                }
                for (int j = 0; j <= M - 2; j += 2)
                {
                    if (array[j] < array[j + 1])
                    {
                        int g = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = g;
                        sorted = false;
                    }
                }
            }
            return array;
        }
        static void finalfilling(int [,] matrix, int N, int M, int [] array)
        {
            for (int i = 0; i < M; i++)
            {
                int y = 0, max_value = matrix[i, 0];
                for (int j = 0; j < N; j++)
                {
                    if (max_value < matrix[i, j])
                    {
                        max_value = matrix[i, j];
                        y = j;
                    }
                }
                matrix[i, y] = array[i];
            }
        }
        static bool [,] choosing(int M, int N, int [,]matrix)
        {
            bool[,] matrix1 = new bool[M, N];
            for (int i = 0; i < M; i++)
            {
                int x=0, max__value= matrix[i, 0];
                for (int j = 0; j < N; j++)
                {
                    if (max__value < matrix[i, j])
                    {
                        max__value = matrix[i, j];
                        x = j;
                        
                    }
                }
                matrix1[i, x] = true;
            }
            return matrix1;
        }
        static void painting(int [,]matrix, bool [,] matrix1, int M, int N)
        {
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (matrix1[i,j])
                    {
                        Console.BackgroundColor = ConsoleColor.Magenta;                       
                    }
                    Console.Write($"{matrix[i,j],3}");
                    Console.ResetColor();
                }
                Console.WriteLine();
            }
        }
    }
}
