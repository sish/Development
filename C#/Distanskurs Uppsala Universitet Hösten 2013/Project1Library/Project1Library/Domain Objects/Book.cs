using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1Library.Domain_Objects
{
    class Book
    {
        [Key]
        public int ID { set; get; }
        [Required]
        public string ISBN { set; get; }
        [Required]
        public string Title { set; get; }
        public string Description { set; get; }
        public Author AuthorRef { set; get; }
        [Required]
        public int Copies { set; get; }

        public Book(string isbn, string title, Author author)
        {
            this.ID = Guid.NewGuid().GetHashCode();
            this.ISBN = isbn;
            this.Title = title;
            this.AuthorRef = author;
        }

    }
}
