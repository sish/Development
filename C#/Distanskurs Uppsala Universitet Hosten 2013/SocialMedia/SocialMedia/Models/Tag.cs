using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SocialMedia.Models
{
    [Table("Tags")]
    public class Tag
    {
        public Tag()
        {
            Followers = new List<User>();
        }

        public Tag(string text) :
            this()
        {
            this.Text = text;
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        // Navigation properties
        public virtual ICollection<User> Followers { get; set; }


    }
}