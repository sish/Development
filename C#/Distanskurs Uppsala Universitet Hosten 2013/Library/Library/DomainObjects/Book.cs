using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Library.DomainObjects
{
    public class Book
    {
        /// <summary>
        /// ISBN property that is unique key for books.
        /// </summary>
        [Key]
        public string ISBN { get; set; }
        /// <summary>
        /// Title of the book
        /// </summary>
        [Required]
        public string Title { get; set; }
        /// <summary>
        /// Description of the book.
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// Which Author that has written the book.
        /// </summary>
        public virtual Author Author { get; set; }
        /// <summary>
        /// How many copies of the book there is.
        /// </summary>
        public virtual ICollection<BookCopy> Copies { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public Book()
        {
            Copies = new List<BookCopy>();
        }

        /// <summary>
        /// Method override of ToString method.
        /// </summary>
        /// <returns>string in format "Title"</returns>
        public override string ToString()
        {
            return this.Title;
        }

        /// <summary>
        /// Overidden Equals method for book.
        /// </summary>
        /// <param name="obj">object to compare to</param>
        /// <returns>bool</returns>
        public override bool Equals(object obj)
        {
            // If parameter is null return false.
            if (obj == null)
            {
                return false;
            }

            // If parameter cannot be cast to Book return false.
            Book p = obj as Book;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return this == p;
        }

        /// <summary>
        /// Overidden GetHasCode, just to stop warnings.
        /// </summary>
        /// <returns>int</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Overloaded == operator.
        /// </summary>
        /// <param name="a">Book</param>
        /// <param name="b">Book</param>
        /// <returns>bool</returns>
        public static bool operator ==(Book a, Book b)
        {
            if (System.Object.ReferenceEquals(a, b))
            {
                return true;
            }

            // If one is null, but not both, return false.
            if (((object)a == null) || ((object)b == null))
            {
                return false;
            }

            // Return true if the fields match:
            return a.ISBN.Equals(b.ISBN) && a.Title.Equals(b.Title) && a.Description.Equals(b.Description) && a.Author == b.Author;
        }

        /// <summary>
        /// Overloaded != operator.
        /// </summary>
        /// <param name="a">Book</param>
        /// <param name="b">Book</param>
        /// <returns>bool</returns>
        public static bool operator !=(Book a, Book b)
        {
            return !(a == b);
        }

    }
}
