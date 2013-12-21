using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Library.DomainObjects
{
    public class Author
    {
        /// <summary>
        /// Property used in the database.
        /// </summary>
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// Property name that has the authors full name
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Property Books with all the books the author has written.
        /// </summary>
        public virtual ICollection<Book> Books { get; set; }

        /// <summary>
        /// Constructor
        /// </summary>
        public Author()
        {
            Books = new List<Book>();
        }

        /// <summary>
        /// override method tostring to show name of author.
        /// </summary>
        /// <returns>string in format "firstname lastname"</returns>
        public override string ToString()
        {
            return this.Name;
        }

        /// <summary>
        /// Equals override to skip warning.
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

            // If parameter cannot be cast to Author return false.
            Author p = obj as Author;
            if ((System.Object)p == null)
            {
                return false;
            }

            // Return true if the fields match:
            return this == p;
        }

        /// <summary>
        /// Override GetHashCode to skip warning.
        /// </summary>
        /// <returns>int</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>
        /// Override of the == operator for author.
        /// </summary>
        /// <param name="a">Author</param>
        /// <param name="b">Author</param>
        /// <returns>bool</returns>
        public static bool operator ==(Author a, Author b)
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
            return a.ID == b.ID && a.Name.Equals(b.Name);
        }

        /// <summary>
        /// Override of the != operator for author.
        /// </summary>
        /// <param name="a">Author</param>
        /// <param name="b">Author</param>
        /// <returns>bool</returns>
        public static bool operator !=(Author a, Author b)
        {
            return !(a == b);
        }

    }
}
