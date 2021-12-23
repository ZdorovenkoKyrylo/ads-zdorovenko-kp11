using System;

namespace ConsoleAppADS_4
{
    class Program
    {
        static void Main(string[] args)
        {
            DLNode dLNode = new DLNode();

            while (true)
            {
                Console.WriteLine("AddFirst-додавання першого елементу");
                Console.WriteLine("AddLast-додавання останнього елементу");
                Console.WriteLine("AddAtPosition-додавання елементу на довiльну позицiю");
                Console.WriteLine("DeLFirst-додавання першого елементу");
                Console.WriteLine("DeLLast-додавання останнього елементу");
                Console.WriteLine("DeLAtPosition-додавання елементу на довiльну позицiю");
                Console.WriteLine("Task-Додавання нового вузла перед хвостом списку, якщо вiн додатний, iнакше – пiсля хвоста списку");
                Console.WriteLine("clear-очистка консолi");
                Console.WriteLine("help-навiгатор");
                try
                {
                    string command = Console.ReadLine();

                    switch (command)
                    {
                        case "AddFirst":
                            Console.Write("Введiть значення: "); int M1 = int.Parse(Console.ReadLine());
                            dLNode.Print();
                            dLNode.AddFirst(M1);
                            dLNode.Print();
                            break;
                        case "AddLast":
                            Console.Write("Введiть значення: "); int M2 = int.Parse(Console.ReadLine());
                            dLNode.Print();
                            dLNode.AddLast(M2);
                            dLNode.Print();
                            break;
                        case "AddAtPosition":
                            Console.Write("Введiть значення елемента: "); int M3 = int.Parse(Console.ReadLine());
                            Console.Write("Введiть iндекс вузла: "); int M4 = int.Parse(Console.ReadLine());
                            dLNode.Print();
                            dLNode.AddAtPosition(M3, M4);
                            dLNode.Print();
                            break;
                        case "DeLFirst":
                            dLNode.Print();
                            dLNode.DelFirst();
                            dLNode.Print();
                            break;
                        case "DeLLast":
                            dLNode.Print();
                            dLNode.DelLast();
                            dLNode.Print();
                            break;
                        case "DeLAtPosition":
                            Console.Write("Введiть iндекс вузла: "); int M5 = int.Parse(Console.ReadLine());
                            dLNode.Print();
                            dLNode.DelAtPosition(M5);
                            dLNode.Print();
                            break;
                        case "Task":
                            Console.Write("Введiть iндекс вузла: "); int M6 = int.Parse(Console.ReadLine());
                            dLNode.Print();
                            dLNode.DelAtPosition(M6);
                            dLNode.Print();
                            break;
                        case "clear":
                            Console.Clear();
                            break;
                        case "close":
                            System.Environment.Exit(1);
                            break;
                        case "help":
                            Console.WriteLine("AddFirst-додавання першого елементу");
                            Console.WriteLine("AddLast-додавання останнього елементу");
                            Console.WriteLine("AddAtPosition-додавання елементу на довільну позицію");
                            Console.WriteLine("DeLFirst-додавання першого елементу");
                            Console.WriteLine("DeLLast-додавання останнього елементу");
                            Console.WriteLine("DeLAtPosition-додавання елементу на довiльну позицiю");
                            Console.WriteLine("Task-додавання елементу на довільну позицію");
                            Console.WriteLine("clear-очистка консолi");
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
    }

    public class DLNode
    {
        private Node head;
        public void AddFirst(int data)
        {
            if (head == null)
            {
                head = new Node(data, null, null);
            }
            else
            {
                head = new Node(data, null, head);
                head.next.prev = head;
            }
        }
        public void AddLast(int data)
        {
            if (head == null)
            {
                head = new Node(data, null, null);
                return;
            }
            Node n = head;
            while (n.next != null)
            {
                n = n.next;
            }
            n.next = new Node(data, n, null);
        }
        public void AddAtPosition(int data, int pos)
        {
            if (pos == 1)
            {
                AddFirst(data);
                return;
            }
            Node n = head;
            for (int i = 1; i < pos; i++)
            {
                if (n == null)
                {
                    throw new IndexOutOfRangeException("Incorrect position");
                }
                n = n.next;
            }

            n.next = new Node(data, n, n.next);
        }
        public void DelFirst()
        {
            if (head != null)
            {
                head = head.next;
                head.prev = null;
            }
        }
        public void DelLast()
        {
            if (head == null)
                return;
            if (head.next == null)
            {
                head = null;
                return;
            }
            Node n = head;
            while (n.next != null)
            {
                n = n.next;
            }
            n.prev.next = null;
        }
        public void DelAtPosition(int pos)
        {
            if (pos == 1)
            {
                DelFirst();
                return;
            }
            Node n = head;
            for (int i = 1; i < pos + 1; i++)
            {
                if (n == null)
                {
                    throw new IndexOutOfRangeException("Incorrect position");
                }
                n = n.next;
            }

            n.prev.next = n.next;
        }
        public void Print()
        {
            if (head == null)
            {
                Console.Write("null\n");
                return;
            }
            Node n = head;
            while (n != null)
            {
                Console.Write(n.data + " ");
                n = n.next;
            }
            Console.WriteLine();
        }
        public void Task(int data)
        {
            if (head == null)
            {
                AddFirst(data);
            }
            else
            {
                Node n = head;
                while (n.next != null)
                {
                    n = n.next;
                }
                if (n.data % 2 == 0)
                {
                    if (n.prev == null)
                    {
                        AddFirst(data);
                        return;
                    }
                    n.prev.next = new Node(data, n.prev, n);
                }
                else
                {
                    n.next = new Node(data, n, null);
                }
            }
        }
        public class Node
        {
            public int data;
            public Node prev;
            public Node next;
            public Node(int data, Node prev, Node next)
            {
                this.data = data;
                this.prev = prev;
                this.next = next;
            }
        }
    }
}

