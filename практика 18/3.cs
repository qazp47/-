using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        HashSet<string> names = new HashSet<string>();
        Console.WriteLine("Введите имена (пустая строка — конец):");

        while (true)
        {
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
            {
                break;
            }
            names.Add(input);
        }
        List<string> uniqueNames = new List<string>(names);
        uniqueNames.Sort(StringComparer.Ordinal);

        Console.WriteLine("Уникальные:");
        Console.WriteLine(string.Join(", ", uniqueNames));
    }
}