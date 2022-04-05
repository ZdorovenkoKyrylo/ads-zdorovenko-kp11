using System;
using System.Collections.Generic;
using System.Linq;
namespace Ads_lab5
{
    class Program
    {
        static void Main(string[] args)
        {
            int M;
            while (true)
            {
                Console.WriteLine("inputlist-сортування рандомного списку");
                Console.WriteLine("clear-очистка консолi");
                Console.WriteLine("controllist-сортування контрольного списку");
                Console.WriteLine("close-закривання консолi");
                Console.WriteLine("help-навiгатор");
                try
                {
                    string command = Console.ReadLine();
                    switch (command)
                    {
                        case "inputlist":
                            Console.Write("M: "); M = int.Parse(Console.ReadLine());
                            Console.Write("Inputlist:\n");
                            LinkedList<int> st = new LinkedList<int>(Console.ReadLine().Trim().Split(' ', StringSplitOptions.RemoveEmptyEntries).Select(t => int.Parse(t)));
                            Console.Write("Startlist: ");
                            Draw(st);
                            st = Task(st, M);
                            Console.Write("Sortedlist: ");
                            Draw(st);
                            break;
                        case "clear":
                            Console.Clear();
                            break;
                        case "controllist":
                            st = ControlList();
                            Console.WriteLine("ControlList: ");
                            Draw(st);
                            st = Task(st, 6);
                            Console.WriteLine("Sortedlist: ");
                            Draw(st);
                            break;
                        case "close":
                            System.Environment.Exit(1);
                            break;
                        case "help":
                            Console.WriteLine("inputlist - сортування рандомного списку");
                            Console.WriteLine("clear - очистка консолi");
                            Console.WriteLine("controllist - сортування контрольного списку");
                            Console.WriteLine("close - закривання консолi");
                            Console.WriteLine("help - навiгатор");
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
        static LinkedList<int> ControlList()
        {
            LinkedList<int> starting = new LinkedList<int>(new int[20] { 11, 2, 3, 15, 17, 4, 14, 6, 5, 12, 18, 19, 8, 0, 1, 7, 13, 16, 9, 10 });
            return starting;
        }
        static void Draw(LinkedList<int> st)
        {
            foreach (var item in st)
            {
                if (item < Math.Sqrt(st.Count) || st.Count < item)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.Write(item);
                    Console.ResetColor();
                    Console.Write(" ");
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.DarkRed;
                    Console.Write(item);
                    Console.ResetColor();
                    Console.Write(" ");
                }
            }
            Console.WriteLine();
        }
        static LinkedList<int> Task(LinkedList<int> st, int M)
        {
            List<int> sorted = new List<int>();
            List<int> notsorted = new List<int>();
            int N = st.Count;
            var el = st.First;
            for (int i = 0; i < st.Count; i++)
            {
                if (el.Value < Math.Sqrt(N) || N < el.Value)
                {
                    notsorted.Add(el.Value);
                }
                else
                {
                    sorted.Add(el.Value);
                }
                el = el.Next;
            }
            st.Clear();
            int[] sort = sorted.ToArray();
            int[] notsort = notsorted.ToArray();
            sort = Mergesort(sort, 0, sort.Length, M);
            for (int i = 0; i < notsort.Length; i++)
            {
                st.AddFirst(notsort[i]);
            }
            for (int i = 0; i < sort.Length; i++)
            {
                st.AddLast(sort[i]);
            }
            return st;
        }
        static int[] Vstavka(int[] array, int low, int high)
        {
            int key = 0;
            for (int i = low; i < high; i++)
            {
                key = array[i];
                int j = i - 1;
                while (j >= 0 && array[j] < key)
                {
                    array[j + 1] = array[j];
                    j -= 1;
                }
                array[j + 1] = key;
            }
            return array;
        }
        static int[] Mergesort(int[] arr, int low, int high, int M)
        {
            if (high - low < M)
            {
                return Vstavka(arr, low, high);
            }

            int mid = (high + low) / 2;
            arr = Mergesort(arr, low, mid, M);
            arr = Mergesort(arr, mid, high, M);

            for (int i = low; i < mid; i++)
            {
                if (arr[i] < arr[mid])
                {
                    (arr[i], arr[mid]) = (arr[mid], arr[i]);

                    for (int j = mid; j < high - 1; j++)
                    {
                        if (arr[j] < arr[j + 1])
                        {
                            (arr[j], arr[j + 1]) = (arr[j + 1], arr[j]);
                        }
                        else
                        {
                            break;
                        }
                    }
                }
            }
            return arr;
        }
    }
}
