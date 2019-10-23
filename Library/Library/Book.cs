using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public enum Genre
    {
        Fantasy = 1,
        ScienceFiction,
        Historical,
        Biography,
        YoungAdult,
        Other
    }
    public class Book
    {
        public string Title { get; set; }
        public Author Author { get; set; }
        public Genre Genre { get; set; }

        public Book(string title, Author author, Genre genre)
        {
            Title = title;
            Author = author;
            Genre = genre;
        }
        
    }
}
