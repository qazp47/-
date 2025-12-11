using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Stack<string> stack = new Stack<string>();
        Console.WriteLine("Введите строки (пустая строка — конец):");

        while (true)
        {
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                break;
            }
            stack.Push(input);
        }
        Console.WriteLine("Вывод в обратном порядке:");
        while (stack.Count > 0)
        {
            string line = stack.Pop();
            Console.WriteLine(line);
        }
    }
}