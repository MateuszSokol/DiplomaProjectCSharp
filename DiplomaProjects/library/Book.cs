using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DiplomaProjects.Library
{
    public class Book
    {
        public string bookTitle{ get; set; }
        public string author { get; set; }
        public string ISBN { get; set; }

        public Book(string bookTitle, string author, string ISBN)
        {
            this.bookTitle = bookTitle;
            this.author = author;
            this.ISBN = ISBN;
        }

        public override string ToString()
        {
            return $"Book title: {bookTitle}, Author: {author}, ISBN:{ISBN}";
        }
    }
}
