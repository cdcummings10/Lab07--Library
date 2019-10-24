using System;
using System.Collections.Generic;
using System.Text;

namespace Library
{
    public class Author
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Author(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }
    }
}
