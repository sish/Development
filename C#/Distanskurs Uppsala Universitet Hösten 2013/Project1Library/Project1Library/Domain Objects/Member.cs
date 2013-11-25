using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Project1Library.Domain_Objects
{
    class Member
    {
        [Key]
        public int ID { set; get; }
        [Required]
        public string PersonalID { set; get; }
        [Required]
        public string Name { set; get; }
        public List<Loan> Loans { get; set; }

    }
}
