using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1Library.Domain_Objects
{
    class BookCopy
    {
        [Key]
        public int ID { set; get; }
        public Book BookRef { get;set;}

    }
}
