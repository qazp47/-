using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Dictionary<string, bool> cache = new Dictionary<string, bool>();
        Queue<string> order = new Queue<string>();
        int maxSize = 3;
        Console.WriteLine("Введите URL для добавления в кэш (или 'выход' чтобы завершить):");
        while (true)
        {
            string url = Console.ReadLine();
            if (url.ToLower() == "выход")
                break;
            if (!cache.ContainsKey(url))
            {
                if (order.Count >= maxSize)
                {
                    string oldest = order.Dequeue();
                    cache.Remove(oldest);
                }
                cache[url] = true;
                order.Enqueue(url);
            }
            Console.WriteLine("Текущий кэш:");
            Console.WriteLine(string.Join(", ", order));
        }
    }
