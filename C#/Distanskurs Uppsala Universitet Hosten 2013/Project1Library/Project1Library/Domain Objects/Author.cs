using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1Library.Domain_Objects
{
    class Author
    {
        [Key]
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
        public List<Book> Books { get; set;}

        public Author(string name)
        {
            this.ID = Guid.NewGuid().GetHashCode();
            this.Name = name;
        }

    }
}
