using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SocialMedia.Models
{
    [Table("Posts")]
    public class Post
    {
        public Post()
        {
            Tags = new List<Tag>();
            Replies = new List<PostReply>();
            Comments = new List<Comment>();
            UpVotes = new List<User>();
            DownVotes = new List<User>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Text { get; set; }

        [Required]
        public virtual ICollection<Tag> Tags { get; set; }

        [Required]
        public DateTime TimeOfPost { get; set; }

        // Foreign key
        [Required]
        public int AuthorID { get; set; }

        // Navigation properties
        [ForeignKey("AuthorID")]
        public virtual User Author { get; set; }

        public virtual ICollection<PostReply> Replies { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<User> UpVotes { get; set; }

        public virtual ICollection<User> DownVotes { get; set; }
        
    }
}