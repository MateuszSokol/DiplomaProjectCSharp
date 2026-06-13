using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DiplomaProjects.library
{
    internal class Book
    {
        private string bookTitle{ get; set; }
        private string author { get; set; }
        private string ISBN { get; set; }

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
