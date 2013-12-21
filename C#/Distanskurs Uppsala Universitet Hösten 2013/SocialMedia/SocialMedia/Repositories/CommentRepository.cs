using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SocialMedia.Repositories
{
    public class CommentRepository : IRepository<Comment, int>
    {
        // The context
        protected SocialMediaContext db;

        /// <summary>
        /// Initialize a new instance of the 
        /// CommentRepository with the provided context.
        /// </summary>
        /// <param name="context">The context.</param>
        public CommentRepository(SocialMediaContext context)
        {
            db = context;
        }

        /// <summary>
        /// Method to add an item to the database.
        /// </summary>
        /// <param name="item">Comment</param>
        public void Add(Comment item)
        {
            db.Comments.Add(item);
            db.SaveChanges();
        }

        /// <summary>
        /// Method to remove an item from the database.
        /// </summary>
        /// <param name="item">Comment</param>
        public void Remove(Comment item)
        {
            db.Comments.Remove(item);
            db.SaveChanges();
        }

        /// <summary>
        /// Method to find a Comment from database using ID.
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Comment</returns>
        public Comment Find(int id)
        {
            return db.Comments.Find(id);
        }

        /// <summary>
        /// Method to edit an existing item from the database.
        /// </summary>
        /// <param name="item">Comment</param>
        /// <exception cref="ArgumentException">Thrown if the edit item doesn't exist in the database using the key.</exception>
        public void Edit(Comment item)
        {
            Comment commentToUpdate = db.Comments.
                Where(a => a.Id == item.Id).FirstOrDefault();

            if (null == commentToUpdate)
            {
                throw new ArgumentException("Comment with ID " + item.Id +
                    " and author " + item.Author.Username + "is unknown to the database, " +
                    "Edit operations is unavailable.", "Comment");
            }
            else
            {
                db.Entry(commentToUpdate).CurrentValues.SetValues(item);
            }
            db.SaveChanges();
        }

        /// <summary>
        /// Method to get an enumerator with all Comments in the database.
        /// </summary>
        /// <returns>IEnumerable&lt;Comment&gt;</returns>
        public IEnumerable<Comment> All()
        {
            return db.Comments
                .Include(comment => comment.Author)
                .ToList();
        }
    }
}