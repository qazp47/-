using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Queue<string> queue = new Queue<string>();
        queue.Enqueue("Дима");
        queue.Enqueue("Денис");
        queue.Enqueue("Тимофей");
        queue.Enqueue("Артем");
        queue.Enqueue("Егор");
        Console.WriteLine("Очередь:");
        Console.WriteLine(string.Join(", ", queue));

        Console.WriteLine("Обслуживаем:");
        while (queue.Count > 0)
        {
            string currentCustomer = queue.Dequeue();
            Console.WriteLine(currentCustomer);
        }
        if (queue.Count == 0)
        {
            Console.WriteLine("Очередь пуста");
        }
    }
}