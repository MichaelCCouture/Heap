using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MCoutureAssignment3
{
    public class Book : IComparable
    {
        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; }
        }
        private string author;

        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        private string publisher;

        public string Publisher
        {
            get { return publisher; }
            set { publisher = value; }
        }
        private decimal price;

        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }

        public Book(string title, string author, string publisher, decimal price) 
            : base()
        {
            this.title = title;
            this.author = author;
            this.publisher = publisher;
            this.price = price;
        }

        public int CompareTo(Object obj)
        {
            if (obj == null)
            {
                return 1;
            }
            Book otherBook = obj as Book;
            if (otherBook != null)
            {
                return this.Title.CompareTo(otherBook.Title);
            }
            else
            {
                throw new ArgumentException("Object is not a Book");
            }
        }
    }
}
