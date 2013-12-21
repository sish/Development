using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SocialMedia.Models
{
    [Table("Comments")]
    public class Comment
    {
        public Comment()
        { 
        
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime TimeOfPost { get; set; }

        // Foreign key
        [Required]
        public int AuthorID { get; set; }

        // Navigation properties
        [ForeignKey("AuthorID")]
        public virtual User Author { get; set; }

    }
}