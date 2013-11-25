using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project1Library.Domain_Objects
{
    class Loan
    {
        [Key]
        public int ID { set; get; }
        [Required]
        public DateTime TimeOfLoan { set; get;}
        [Required]
        public DateTime DueDate { set; get; }
        public DateTime TimeOfReturn { set; get; }
        public BookCopy BookCopyRef { set; get; }
        public Member MemberRef { set; get; }

    }
}
