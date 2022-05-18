// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;
using System.Linq;

class Stack<T>
{
    private Node head;
    private class Node
    {
        public char data;
        public Node refer;
    }
    private int count = 0;

    public int Count => count;

    public void Push(char elem)
    {
        Node tmp = new Node();
        tmp.data = elem;
        tmp.refer = head;
        head = tmp;
        count++;
    }

    public char Pop()
    {
        if (count == 0)
            throw new InvalidOperationException("Stack is empty");
        char value = head.data;
        head = head.refer;
        count--;
        return value;
    }
    public void show()
    {
        Node node = head;
        while (node != null)
        {
            Console.Write("{0}", node.data);
            node = node.refer;
        }
        Console.WriteLine();
    }
    public char Peek()
    {
        if (count == 0)
            throw new Exception();
        else
            return head.data;
    }
    public bool isEmpty()
    {
        return count == 0;
    }
}
class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("1- введiть рядок iнфiкснiй формi");
            Console.WriteLine("2- використайте контрольний приклад");
            Console.WriteLine("3- очистiть консоль");
            Console.WriteLine("4- закрийте консоль");
            Console.WriteLine("5- навiгатор");
            Console.Write("Choose one of the options: "); string s = Console.ReadLine();
            switch (s)
            {
                case "1":
                    Console.Write("Input string: "); string str = Console.ReadLine();
                    if (CheckofCommand(str))
                        PolandNotation(str);
                    else
                        Console.WriteLine("Incorrect line, Try again!");
                    break;
                case "2":
                    String test_case = "3*x*y+(y-5/(x*y))";
                    Console.WriteLine("Test case: " + test_case);
                    PolandNotation(test_case);
                    break;
                case "3":
                    Console.Clear();
                    break;
                case "4":
                    System.Environment.Exit(1);
                    break;
                case "5":
                    Console.WriteLine("1- введіть рядок інфіксній формі");
                    Console.WriteLine("2- використайте контрольний приклад");
                    Console.WriteLine("3- очистіть консоль");
                    Console.WriteLine("4- закрийте консоль");
                    Console.WriteLine("5- навігатор");
                    break;
                default:
                    Console.WriteLine("Invalid command, try again");
                    break;
            }
        }
    }
    static void PolandNotation(string str)
    {
        string res = "";
        Stack<char> stack = new Stack<char>();
        var dick = new Dictionary<char, int>
        {
            ['*'] = 2,
            ['/'] = 2,
            ['+'] = 1,
            ['-'] = 1
        };

        foreach (char c in str)
        {
            if (Char.IsDigit(c) || Char.IsLetter(c))
                res += c;
            else if (c == '+' || c == '-' || c == '*' || c == '/')
            {
                if (stack.Count == 0)
                    stack.Push(c);
                else
                {
                    if (dick[c] == 1)
                        while (!stack.isEmpty() && stack.Peek() != '(')
                            res += stack.Pop();
                    else if (dick[c] == 2)
                        while (!stack.isEmpty() && stack.Peek() != '(' && dick[stack.Peek()] != 1)
                            res += stack.Pop();

                    stack.Push(c);
                }
            }
            else if (c == '(')
                stack.Push(c);
            else if (c == ')')
            {
                while (stack.Peek() != '(')
                    res += stack.Pop();

                stack.Pop();
            }

            Console.Write($"Current: {res}\tStack: ");
            stack.show();
        }
        while (!stack.isEmpty())
            res += stack.Pop();

        Console.WriteLine("RES:" + res);
    }
    static bool CheckofCommand(string str)
    {
        int let = str.Where(x => char.IsLetter(x)).Count();
        int dig = str.Where(x => char.IsDigit(x)).Count();
        int temp = 0;
        foreach (var item in str)
        {
            if (item == '(')
                temp++;
            else if (item == ')')
                temp--;
            if (temp < 0)
                return false;
        }
        int symb = 0;
        foreach (var item in str)
            if (item == '+' || item == '-' || item == '*' || item == '/')
                symb++;

        if (temp == 0 && let + dig == symb + 1 && !str.Contains(' '))
            return true;

        return false;
    }
}
