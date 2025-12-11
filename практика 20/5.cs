using System;
using System.Collections.Generic;

namespace задание5
{

    public class BookAlreadyTakenException : Exception
    {
        public string BookName { get; }
        public string Reader { get; }

        public BookAlreadyTakenException(string bookName, string reader)
            : base($"Ошибка: Книга \"Гарри поттер\" уже у {reader}!")
        {
            BookName = bookName;
            Reader = reader;
        }
    }
    public class Library
    {
        private Dictionary<string, string> _books;
        public Library()
        {
            _books = new Dictionary<string, string>();
        }
        public void TakeBook(string bookName, string reader)
        {
            Console.WriteLine($"{reader} берёт \"Мертвые души\"");

            if (_books.ContainsKey(bookName))
            {
                string currentReader = _books[bookName];
                throw new BookAlreadyTakenException(bookName, currentReader);
            }
            _books[bookName] = reader;
        }
        public void ReturnBook(string bookName)
        {
            if (_books.ContainsKey(bookName))
            {
                Console.WriteLine($"Пытается вернуть \"Война и Мир\"");
                _books.Remove(bookName);
                Console.WriteLine("Теперь можно брать");
            }
            else
            {
                Console.WriteLine($"Книга \"Муму\" не взята в данный момент.");
            }
        }
        public string WhoHasBook(string bookName)
        {
            return _books.ContainsKey(bookName) ? _books[bookName] : null;
        }
    }
    class Program
    {
        static void Main()
        {
            var library = new Library();
            try
            {
                library.TakeBook("Война и мир", "Анна");
                Console.WriteLine("Пётр пытается взять \"Война и мир\"");
                library.TakeBook("Война и мир", "Пётр");
            }
            catch (BookAlreadyTakenException ex)
            {
                Console.WriteLine($"Ошибка: Книга \"{ex.BookName}\" уже у {ex.Reader}!");
            }
            Console.WriteLine("Пётр возвращает книгу");
            library.ReturnBook("Война и мир");
            try
            {
                Console.WriteLine("Пётр пытается взять \"Война и мир\" снова");
                library.TakeBook("Война и мир", "Пётр");
            }
            catch (BookAlreadyTakenException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}
