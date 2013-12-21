using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SocialMedia.Providers;

namespace SocialMedia.Models
{
    /// <summary>
    /// Derived context.
    /// </summary>
    public class SocialMediaContext : DbContext
    {
        public SocialMediaContext()
            : base("DefaultConnection")
        {
            // Database strategy
            Database.SetInitializer<SocialMediaContext>(new SocialMediaDbInit());
        }

        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<PostReply> PostReplies { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<User> Users { get; set; }

        // If you want to try or need to (some use cases) use fluent API this is the place!
        // Reference: http://blogs.msdn.com/b/adonet/archive/2010/12/14/ef-feature-ctp5-fluent-api-samples.aspx
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PostReply>()
                .HasRequired(reply => reply.Author)
                .WithMany(post => post.PostReplies)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Post>()
                .HasRequired(post => post.Author)
                .WithMany(post => post.Posts)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Post>()
                .HasMany(post => post.Tags)
                .WithMany();

            modelBuilder.Entity<Post>()
                .HasMany(post => post.Replies)
                .WithRequired(reply => reply.Head);

            modelBuilder.Entity<User>()
                .HasMany(user => user.Followers)
                .WithMany();

            modelBuilder.Entity<Tag>()
                .HasMany(user => user.Followers)
                .WithMany();
        }
    }

    /// <summary>
    /// Derived database strategy
    /// </summary>
    class SocialMediaDbInit : DropCreateDatabaseIfModelChanges<SocialMediaContext>
    //class SocialMediaDbInit : DropCreateDatabaseAlways<SocialMediaContext>
    {
        static List<string> fnamn = new List<string>() { "Maria", "Anna", "Margareta", "Elisabeth", "Eva", "Birgitta", "Kristina", "Karin", "Elisabet", "Marie", "Ingrid", "Christina", "Linnéa", "Marianne", "Sofia", "Erik", "Lars", "Karl", "Anders", "Johan", "Per", "Nils", "Jan", "Carl", "Mikael", "Lennart", "Hans", "Olof", "Gunnar", "Peter" };
        static List<string> randomSentence = new List<string>()
        {
            "Well, I must be going.", "If he could pass for eighteen years old, he'd join the army.",
            "The book is easy.", "She was asked to convince him to get his son to paint the house.",
            "I don't care for eggs.", "I don't like studying.", "I have a lot of things to tell you.",
            "It's not easy to speak a foreign language.", "We were very tired.", "No, it wasn't expensive. It was on sale for 20 dollars.",
            "It was yesterday that he died.", "Everything is fine so far.", "Someone entered the room.",
            "May I have a receipt?", "She went to the airport to see him off.", "She got him a new hat.",
            "I don't know how to play golf at all.", "He had dark brown hair.", "He was fast asleep.",
            "Today's her birthday and she told me she wants me to buy her flowers.", "Does that price include tax?",
            "I bought every book on Japan I could find.", "I believed that he would keep his promise.",
            "He seems to make nothing of it.", "That is intriguing.", "I don't care what she eats.",
            "You must be back before ten.", "Did you buy anything?", "Can you speak French?", "What made you change your mind?"
        };

        protected override void Seed(SocialMediaContext context)
        {
            base.Seed(context);
            /// Common
            Random rand = new Random(DateTime.Now.Second);
            /// Roles
            Role admin = new Role() { Name = "Admin" };
            Role user = new Role() { Name = "User" };
            context.Roles.Add(admin);
            context.Roles.Add(user);
            context.SaveChanges();
            /// Users
            User lastUser = null;
            int i = 0;
            foreach (string name in fnamn)
            {
                User u = new User();
                u.Username = name;
                u.Password = SimpleMembershipProvider.EncryptPassword("test");
                if( null != lastUser ) {
                    u.Followers.Add(lastUser);
                }
                if (i % 5 == 0)
                {
                    u.Roles.Add(admin);
                }
                else
                {
                    u.Roles.Add(user);
                }
                context.Users.Add(u);
                context.SaveChanges();
                lastUser = u;
            }
            /// Tags
            context.Tags.Add(new Tag() { Text = "Tree", Followers = context.Users.ToList().OrderBy(u => rand.Next()).Take(rand.Next(4,8)).ToList() });
            context.SaveChanges();
            context.Tags.Add(new Tag() { Text = "Forest", Followers = context.Users.ToList().OrderBy(u => rand.Next()).Take(rand.Next(4,8)).ToList() });
            context.SaveChanges();
            context.Tags.Add(new Tag() { Text = "Ocean", Followers = context.Users.ToList().OrderBy(u => rand.Next()).Take(rand.Next(4,8)).ToList() });
            context.SaveChanges();
            context.Tags.Add(new Tag() { Text = "Fish", Followers = context.Users.ToList().OrderBy(u => rand.Next()).Take(rand.Next(4,8)).ToList() });
            context.SaveChanges();
            context.Tags.Add(new Tag() { Text = "Bird", Followers = context.Users.ToList().OrderBy(u => rand.Next()).Take(rand.Next(4,8)).ToList() });
            context.SaveChanges();
            context.Tags.Add(new Tag() { Text = "Mammal", Followers = context.Users.ToList().OrderBy(u => rand.Next()).Take(rand.Next(4,8)).ToList() });
            context.SaveChanges();
            /// Posts
            foreach ( User u in context.Users.ToList() )
            {
                // Add posts, 0 to 4 per user.
                for (int posts = 0; posts < rand.Next(4); posts++)
                {
                    Post p = new Post();
                    p.Author = context.Users.Where(asd => asd.Id == u.Id).First();
                    p.TimeOfPost = DateTime.UtcNow;
                    p.Title = randomSentence.OrderBy(text => rand.Next()).Take(1).First();
                    var sentences = randomSentence.OrderBy(text => rand.Next()).Take(rand.Next(4,8)).ToList();
                    foreach (var str in sentences)
                    {
                        p.Text += str + " ";
                    }
                    p.Tags = context.Tags.ToList().OrderBy(b => rand.Next()).Take(rand.Next(1,3)).ToList();
                    var otherUsers = context.Users.ToList().Where(a => a.Id != u.Id);
                    var randomOrder = otherUsers.OrderBy(c => rand.Next());
                    var takeLess = randomOrder.Take(rand.Next(1,10));
                    var distinct = takeLess.Distinct();
                    var asList = distinct.ToList();
                    p.UpVotes = asList;
                    var otherExceptFirstList = otherUsers.Where(b => true != p.UpVotes.Contains(b));
                    var secRandomOrder = otherExceptFirstList.OrderBy(c => rand.Next());
                    var secTakeLess = secRandomOrder.Take(rand.Next(1,10));
                    var secDistinct = secTakeLess.Distinct();
                    var secAsList = secDistinct.ToList();
                    p.DownVotes = secAsList;
                    /// Comments to posts.
                    for( int comment = 0; comment < rand.Next(6); comment++ )
                    {
                        Comment c = new Comment();
                        c.Author = context.Users.ToList().OrderBy(a => rand.Next()).Take(1).First();
                        c.Text = randomSentence.OrderBy(text => rand.Next()).Take(1).First();
                        c.TimeOfPost = DateTime.UtcNow;
                        p.Comments.Add(c);
                    }
                    /// Replies to posts
                    bool CorrectAnswer = false;
                    for( int replies = 0; replies < rand.Next(3); replies++ )
                    {
                        PostReply pr = new PostReply();
                        pr.Author = context.Users.ToList().Where(a => a.Id != u.Id).OrderBy(c => rand.Next()).Take(1).First();
                        pr.TimeOfPost = DateTime.UtcNow;
                        var prSentences = randomSentence.OrderBy(text => rand.Next()).Take(rand.Next(4,8)).ToList();
                        foreach (var str in prSentences)
                        {
                            pr.Text += str + " ";
                        }
                        pr.Head = p;
                        if( true != CorrectAnswer ) 
                        {
                            CorrectAnswer = (rand.Next(1000) % 3 == 0);
                            pr.CorrectAnswer = CorrectAnswer;
                        }
                        else 
                        {
                            pr.CorrectAnswer = false;
                        }
                        pr.UpVotes = context.Users.ToList().Where(a => a.Id != pr.Author.Id).OrderBy(c => rand.Next()).Take(rand.Next(1,10)).Distinct().ToList();
                        pr.DownVotes = context.Users.ToList().Where(a => a.Id !=  pr.Author.Id).Where(b => true != pr.UpVotes.Contains(b)).OrderBy(c => rand.Next()).Take(rand.Next(1,10)).Distinct().ToList();
                        /// Comments to posts.
                        for( int comment = 0; comment < rand.Next(6); comment++ )
                        {
                            Comment c = new Comment();
                            c.Author = context.Users.ToList().OrderBy(a => rand.Next()).Take(1).First();
                            c.Text = randomSentence.OrderBy(text => rand.Next()).Take(1).First();
                            c.TimeOfPost = DateTime.UtcNow;
                            pr.Comments.Add(c);
                        }
                        p.Replies.Add(pr);
                    }
                    /// I get a one to many constraint error here in UpVotes. Not sure why as I select Distinct.
                    try
                    {
                        //u.Posts.Add(p);
                        //context.Entry(u).CurrentValues.SetValues(u);
                        //context.SaveChanges();
                        context.Posts.Add(p);
                        context.SaveChanges();
                    }
                    catch (Exception e)
                    {
                        System.Diagnostics.Debug.WriteLine(e.Message);
                    }
                    
                }
            }
        }
    }
        
}