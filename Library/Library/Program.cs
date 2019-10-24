using System;
using System.Collections.Generic;

namespace Library
{
    class Program
    {
        public static Library<Book> myLibrary = new Library<Book>();
        public static List<Book> BookBag = new List<Book>();
        public Genre myGenre = new Genre();
        static void Main(string[] args)
        {
            LoadBooks();
            bool appOn = true;
            while (appOn)
            {
                Console.WriteLine("Welcome to Phil's Lending Library!");
                Console.WriteLine("Main Menu:");
                Console.WriteLine("1) View All Books");
                Console.WriteLine("2) Add a Book");
                Console.WriteLine("3) Borrow a Book");
                Console.WriteLine("4) Return a Book");
                Console.WriteLine("5) View Book Bag");
                Console.WriteLine("6) Exit");
                Console.Write("Input: ");

                string input = Console.ReadLine();
                switch (input)
                {
                    case "1":
                        ViewAllBooks();
                        break;
                    case "2":
                        AddABook();
                        break;
                    case "3":
                        BorrowABook();
                        break;
                    case "4":
                        ReturnBook();
                        break;
                    case "5":
                        ViewBookBag();
                        break;
                    case "6":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter a correct input.");
                        break;
                }
            }
        }
        /// <summary>
        /// Loads a set of 5 default books into the library.
        /// </summary>
        public static void LoadBooks()
        {
            Book hobbit = new Book("The Hobbit", new Author("J. R. R.", "Tolkien"), Genre.Fantasy);
            Book endersGame = new Book("Ender's Game", new Author("Orson", "Scott Card"), Genre.ScienceFiction);
            Book goldenCompass = new Book("The Golden Compass", new Author("Philip", "Pullman"), Genre.Fantasy);
            Book angelasAshes = new Book("Angela's Ashes", new Author("Frank", "McCourt"), Genre.Biography);
            Book theFaultInOurStars = new Book("The Fault In Our Stars", new Author("John", "Green"), Genre.YoungAdult);
            Book[] defaultBooks = new Book[] { hobbit, endersGame, goldenCompass, angelasAshes, theFaultInOurStars, };
            foreach (Book book in defaultBooks)
            {
                myLibrary.Add(book);
            }
        }
        /// <summary>
        /// Runs a foreach over the library and prints all books and their details to the console.
        /// </summary>
        public static void ViewAllBooks()
        {
            foreach (Book book in myLibrary)
            {
                if (book != null)
                {
                    Console.WriteLine($"{book.Title} by {book.Author.FirstName} {book.Author.LastName}. Genre: {book.Genre}");
                }
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Prompts user for book details: title, first and last name of author and has user choose a genre.
        /// Creates a new Book object and calls the Library Add function to add it to the existing library.
        /// </summary>
        public static void AddABook()
        {
            Console.Write("Please enter the title:");
            string title = Console.ReadLine();
            Console.Write("Please enter the author's first name:");
            string firstName = Console.ReadLine();
            Console.Write("Please enter the author's last name:");
            string lastName = Console.ReadLine();

            //logic taken from https://stackoverflow.com/questions/972307/how-to-loop-through-all-enum-values-in-c
            var genres = Enum.GetValues(typeof(Genre));
            int displayCount = 1;
            foreach (Genre genre in genres)
            {
                Console.WriteLine($"{displayCount}: {genre}");
                displayCount++;
            }
            Console.Write("Please choose a genre:");
            string inputGenre = Console.ReadLine();
            Genre chosenGenre = Genre.Other;
            foreach (Genre genre in genres)
            {
                if ((int)genre == Convert.ToInt32(inputGenre))
                {
                    chosenGenre = genre;
                }
            }
            Console.WriteLine(chosenGenre);

            Book newBook = new Book(title, new Author(firstName, lastName), chosenGenre);
            myLibrary.Add(newBook);
            Console.WriteLine("Added new book!\n");
        }
        /// <summary>
        /// Displays current books in library and takes a user input to remove book from library and 
        /// store the book in the BookBag.
        /// </summary>
        public static void BorrowABook()
        {
            Console.WriteLine("Which book would you like to borrow?");
            int displayCount = 1;
            foreach (Book book in myLibrary)
            {
                if (book != null)
                {
                    Console.WriteLine($"{displayCount}: {book.Title} by {book.Author.FirstName} {book.Author.LastName}." +
                        $" Genre: {book.Genre}");
                    displayCount++;
                }
            }
            string userChoice = Console.ReadLine();

            Book chosenBook = myLibrary.Remove(Convert.ToInt32(userChoice) - 1);

            BookBag.Add(chosenBook);
            myLibrary.GetEnumerator();
            Console.WriteLine($"{chosenBook.Title} added to Book Bag!");
            Console.WriteLine();
        }
        /// <summary>
        /// Displays current contents of BookBag.
        /// </summary>
        public static void ViewBookBag()
        {
            int count = 1;
            foreach (Book book in BookBag)
            {
                if (book != null)
                {
                    Console.WriteLine($"{count}: {book.Title} by {book.Author.FirstName} {book.Author.LastName}." +
                        $" Genre: {book.Genre}");
                    count++;
                }
            }
        }
        /// <summary>
        /// Displays current book bag and takes users input. Adds the book back to the library and removes
        /// book from the BookBag collection.
        /// </summary>
        public static void ReturnBook()
        {
            Dictionary<int, Book> bookList = new Dictionary<int, Book>();
            int count = 1;
            Console.WriteLine("Please choose a book to return: ");
            foreach (Book book in BookBag)
            {
                Console.WriteLine($"{count}: {book.Title}");
                bookList.Add(count, book);
                count++;
            }
            Console.Write("Choice: ");
            string input = Console.ReadLine();
            Book chosenBook = bookList.GetValueOrDefault(Convert.ToInt32(input));
            myLibrary.Add(chosenBook);
            BookBag.Remove(chosenBook);
            Console.WriteLine(chosenBook.Title + " has been returned!");
        }
    }
}
