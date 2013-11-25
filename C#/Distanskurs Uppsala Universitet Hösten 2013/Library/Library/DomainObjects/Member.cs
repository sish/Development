using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Library.DomainObjects
{
    public class Member
    {
        /// <summary>
        /// Property with the database ID of the member.
        /// </summary>
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// Property personalid in the format YYYYMMDD-XXXX
        /// </summary>
        [Required,MaxLength(13)]
        public string PersonalID { get; set; }
        /// <summary>
        /// Property name of the member, in format "firstname lastname".
        /// </summary>
        [Required]
        public string Name { get; set; }
        /// <summary>
        /// Property with all loans by this member.
        /// </summary>
        public virtual ICollection<Loan> Loans { get; set; }

        /// <summary>
        /// Default Constructor.
        /// </summary>
        public Member()
        {
            Loans = new List<Loan>();
        }

        /// <summary>
        /// Method override of ToString method.
        /// </summary>
        /// <returns>String in format "Name"</returns>
        public override string ToString()
        {
            return this.Name + " (" + this.PersonalID + ")";
        }
    }
}
