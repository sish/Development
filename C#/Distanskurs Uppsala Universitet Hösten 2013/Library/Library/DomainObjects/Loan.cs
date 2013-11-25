using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Library.DomainObjects
{
    public class Loan
    {
        /// <summary>
        /// Property ID with database key.
        /// </summary>
        [Key]
        public int ID { get; set; }
        /// <summary>
        /// Property DateTime that is the time when the loan started.
        /// </summary>
        [Required]
        public DateTime TimeOfLoan { get; set; }
        /// <summary>
        /// Property DateTime that is the time when the book should be returned.
        /// </summary>
        [Required]
        public DateTime DueDate { get; set; }
        /// <summary>
        /// Property DateTime with the actual time of return.
        /// </summary>
        public DateTime? TimeOfReturn { get; set; }
        /// <summary>
        /// Property with the specific copy of the book loaned.
        /// </summary>
        [Required]
        public virtual BookCopy Copy { get; set; }
        /// <summary>
        /// Property referring to what member loaned the book.
        /// </summary>
        [Required]
        public virtual Member Member { get; set; }

        /// <summary>
        /// Property holding information of current ToString method to use.
        /// </summary>
        private static StringFormat CurrentFormat;

        /// <summary>
        /// Method override of ToString method.
        /// </summary>
        /// <returns>string</returns>
        public override string ToString()
        {
            string retValue = string.Empty;
            retValue += "[";
            if (null != TimeOfReturn && TimeOfReturn < DueDate )
            {
                retValue += "Returned";
            }
            else if (DateTime.Now < DueDate)
            {
                retValue += "On Loan";
            }
            else
            {
                retValue += "Overdue";
            }
            retValue += "] ";
            switch( CurrentFormat )
            {
                case StringFormat.SF_AUTHOR:
                {
                    retValue += Copy.Book.Title + " (By: " + Copy.Book.Author.Name + ")";
                    break;
                }
                case StringFormat.SF_MEMBER:
                {
                    retValue += Copy.Book.Title + " (By: " + Member.Name + ")";
                    break;
                }
            }
            return retValue;
        }

        /// <summary>
        /// Enum with selectable string formats for the ToString method.
        /// </summary>
        public enum StringFormat 
        {
            SF_MEMBER,
            SF_AUTHOR
        }

        /// <summary>
        /// Static method setting the ToString method to use.
        /// </summary>
        /// <param name="format">StringFormat with the new stringformat to use of the Loan objects.</param>
        public static void SetToStringMethod(StringFormat format)
        {
            CurrentFormat = format;
        }

    }
}
