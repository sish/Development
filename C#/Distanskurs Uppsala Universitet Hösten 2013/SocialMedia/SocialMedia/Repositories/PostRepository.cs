using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SocialMedia.Repositories
{
    public class PostRepository : IRepository<Post, int>
    {
        // The context
        protected SocialMediaContext db;

        /// <summary>
        /// Initialize a new instance of the 
        /// PostRepository with the provided context.
        /// </summary>
        /// <param name="context">The context.</param>
        public PostRepository(SocialMediaContext context)
        {
            db = context;
        }

        /// <summary>
        /// Method to add an item to the database.
        /// </summary>
        /// <param name="item">Post</param>
        public void Add(Post item)
        {
            db.Posts.Add(item);
            db.SaveChanges();
        }

        /// <summary>
        /// Method to remove an item from the database.
        /// </summary>
        /// <param name="item">Post</param>
        public void Remove(Post item)
        {
            db.Posts.Remove(item);
            db.SaveChanges();
        }

        /// <summary>
        /// Method to find a Post from database using ID.
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Post</returns>
        public Post Find(int id)
        {
            return db.Posts.Find(id);
        }

        /// <summary>
        /// Method to edit an existing item from the database.
        /// </summary>
        /// <param name="item">Post</param>
        /// <exception cref="ArgumentException">Thrown if the edit item doesn't exist in the database using the key.</exception>
        public void Edit(Post item)
        {
            Post postToUpdate = db.Posts.
                Where(a => a.Id == item.Id).FirstOrDefault();

            if (null == postToUpdate)
            {
                throw new ArgumentException("Post with ID " + item.Id +
                    " and author " + item.Author.Username + "is unknown to the database, " +
                    "Edit operations is unavailable.", "Comment");
            }
            else
            {
                db.Entry(postToUpdate).CurrentValues.SetValues(item);
            }
            db.SaveChanges();
        }

        /// <summary>
        /// Method to get an enumerator with all Posts in the database.
        /// </summary>
        /// <returns>IEnumerable&lt;Post&gt;</returns>
        public IEnumerable<Post> All()
        {
            return db.Posts
                .Include(post => post.Author)
                .Include(post => post.Tags)
                .Include(post => post.Replies)
                .Include(post => post.Comments)
                .Include(post => post.UpVotes)
                .Include(post => post.DownVotes)
                .ToList();
        }
    }
}