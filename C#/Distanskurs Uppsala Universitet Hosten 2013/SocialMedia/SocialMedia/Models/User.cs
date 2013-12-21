using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SocialMedia.Models
{
    [Table("Users")]
    public class User
    {
        public User()
        {
            Posts = new List<Post>();
            PostReplies = new List<PostReply>();
            Followers = new List<User>();
            Roles = new List<Role>();
        }

        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        // Navigation properties
        public virtual ICollection<Post> Posts { get; set; }

        public virtual ICollection<PostReply> PostReplies { get; set; }

        public virtual ICollection<User> Followers { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}