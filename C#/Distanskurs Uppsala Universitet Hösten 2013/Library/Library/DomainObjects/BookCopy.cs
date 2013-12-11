using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Library.DomainObjects
{
    public class BookCopy
    {
        /// <summary>
        /// Property for the key ID to the database.
        /// </summary>
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// Property referring to the specific Book copy.
        /// </summary>
        public virtual Book Book { get; set; }
    }
}
