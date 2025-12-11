using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        LinkedList<string> history = new LinkedList<string>();
        LinkedListNode<string> currentNode = null;

        Console.WriteLine("Введите команды: или название страницы для посещения, или 'back' для возвращения назад. Пустая строка для завершения.");

        while (true)
        {
            string input = Console.ReadLine();
            if (string.IsNullOrEmpty(input))
                break;

            if (input.ToLower() == "back")
            {
                if (currentNode != null && currentNode.Previous != null)
                {
                    currentNode = currentNode.Previous;
                    Console.WriteLine("Текущая страница: " + currentNode.Value);
                }
                else
                {
                    Console.WriteLine("Нет предыдущей страницы.");
                }
            }
            else
            {
                var newNode = new LinkedListNode<string>(input);
                if (currentNode != null)
                {
                    var node = currentNode.Next;
                    while (node != null)
                    {
                        var next = node.Next;
                        history.Remove(node);
                        node = next;
                    }
                    history.AddAfter(currentNode, newNode);
                }
                else
                {
                    history.AddFirst(newNode);
                }

                currentNode = newNode;
                Console.WriteLine("Текущая страница: " + currentNode.Value);
            }
        }
    }
}