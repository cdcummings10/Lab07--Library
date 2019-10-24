using System;
using Xunit;
using Library;

namespace XUnitTestProject1
{
    public class UnitTest1
    {
        public static Library<Book> myLibrary = new Library<Book>();
        [Fact]
        public void TestIfYouCanAddABookToLibrary()
        {
            myLibrary.Add(new Book("Catmunism", new Author("Meow", "Zedong"), Genre.Historical));
            Book lastBook = null;
            foreach (Book book in myLibrary)
            {
                lastBook = book;
            }
            Assert.Equal("Catmunism", lastBook.Title);
        }
        [Fact]
        public void TestIfYouCanCheckOutABook()
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
            Book removedBook = myLibrary.Remove(3);
            Assert.Equal("Angela's Ashes", removedBook.Title);
        }
        [Fact]
        public void TestIfYouCantRemoveABookThatDoesntExist()
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
            Book removedBook = myLibrary.Remove(6);
            Assert.Null(removedBook);
        }
        [Fact]
        public void TestIfYouCanCreateANewBook()
        {
            Book hobbit = new Book("The Hobbit", new Author("J. R. R.", "Tolkien"), Genre.Fantasy);
            Assert.Equal("The Hobbit", hobbit.Title);
        }
        [Fact]
        public void TestIfYouCanCreateANewAuthor()
        {
            Author jrrTolkien = new Author("J. R. R.", "Tolkien");
            Assert.Equal("J. R. R.", jrrTolkien.FirstName);
            Assert.Equal("Tolkien", jrrTolkien.LastName);
        }
        [Fact]
        public void TestIfThereIsAnAccurateBookCountInLibrary()
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
            myLibrary.Remove(3);

            Assert.NotEqual(5, myLibrary.ItemCount());
        }
        
    }
}
