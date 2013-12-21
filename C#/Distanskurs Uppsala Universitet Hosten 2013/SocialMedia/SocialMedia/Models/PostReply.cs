using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SocialMedia.Models
{
    [Table("PostReplies")]
    public class PostReply
    {
        public PostReply()
        {
            Comments = new List<Comment>();
            UpVotes = new List<User>();
            DownVotes = new List<User>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public DateTime TimeOfPost { get; set; }

        public bool CorrectAnswer { get; set; }

        // Foreign key
        [Required]
        public int HeadID { get; set; }

        [Required]
        public int AuthorID { get; set; }

        // Navigation properties
        [ForeignKey("HeadID")]
        public virtual Post Head { get; set; }

        [ForeignKey("AuthorID")]
        public virtual User Author { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<User> UpVotes { get; set; }

        public virtual ICollection<User> DownVotes { get; set; }
    
    }
}