using System;
using System.Collections.Generic;

namespace LibrarySystem
{
    class Program
    {
        class Book
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public int Year { get; set; }

            public Book(string title, string author, int year)
            {
                Title = title;
                Author = author;
                Year = year;
            }

            public override string ToString()
            {
                return $"\"{Title}\" - {Author} ({Year} г.)";
            }
        }

        static List<Book> books = new List<Book>();

        static void Main(string[] args)
        {
            bool isRunning = true;
            Console.WriteLine("=== Информационная система 'Библиотека' ===");

            while (isRunning)
            {
                Console.WriteLine("\n1. Добавить книгу");
                Console.WriteLine("2. Показать все книги");
                Console.WriteLine("3. Найти книгу по автору");
                Console.WriteLine("4. Выйти");
                Console.Write("Выберите действие: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddBook(); break;
                    case "2": ShowBooks(); break;
                    case "3": FindByAuthor(); break;
                    case "4": isRunning = false; break;
                    default: Console.WriteLine("Неверный выбор."); break;
                }
            }
        }

        static void AddBook()
        {
            Console.Write("Название книги: ");
            string title = Console.ReadLine();
            Console.Write("Автор: ");
            string author = Console.ReadLine();
            Console.Write("Год издания: ");
            if (int.TryParse(Console.ReadLine(), out int year))
            {
                books.Add(new Book(title, author, year));
                Console.WriteLine("Книга добавлена!");
            }
            else
            {
                Console.WriteLine("Ошибка: год должен быть числом.");
            }
        }

        static void ShowBooks()
        {
            if (books.Count == 0)
            {
                Console.WriteLine("Библиотека пуста.");
                return;
            }
            Console.WriteLine("\n--- Каталог книг ---");
            foreach (var book in books)
            {
                Console.WriteLine(book);
            }
        }

        static void FindByAuthor()
        {
            Console.Write("Введите фамилию автора: ");
            string author = Console.ReadLine();
            bool found = false;
            foreach (var book in books)
            {
                if (book.Author.Contains(author, StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine(book);
                    found = true;
                }
            }
            if (!found) Console.WriteLine("Книги этого автора не найдены.");
        }
    }
}