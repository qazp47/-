using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Book
{
    private string[] chapters = new string[10];
    public string this[int index]
    {
        get
        {
            if (index < 0 || index >= chapters.Length)
                throw new IndexOutOfRangeException();
            return chapters[index];
        }
        set
        {
            if (index < 0 || index >= chapters.Length)
                throw new IndexOutOfRangeException();
            chapters[index] = value;
        }
    }
    public override string ToString()
    {
        var result = "";
        int count = 0;
        for (int i = 0; i < chapters.Length; i++)
        {
            if (!string.IsNullOrEmpty(chapters[i]))
            {
                count++;
                result += $"{count}. {chapters[i]}\n";
            }
        }
        return result;
    }
}
class Program
{
    static void Main()
    {
        var book = new Book();

        book[0] = "Введение";
        book[1] = "Глава 1";

        Console.WriteLine(book[0]);
        Console.WriteLine(book);
    }
}