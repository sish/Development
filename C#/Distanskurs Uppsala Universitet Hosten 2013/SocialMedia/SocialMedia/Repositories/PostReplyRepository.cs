using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SocialMedia.Repositories
{
    public class PostReplyRepository : IRepository<PostReply, int>
    {
        // The context
        protected SocialMediaContext db;

        /// <summary>
        /// Initialize a new instance of the 
        /// PostReplyRepository with the provided context.
        /// </summary>
        /// <param name="context">The context.</param>
        public PostReplyRepository(SocialMediaContext context)
        {
            db = context;
        }

        /// <summary>
        /// Method to add an item to the database.
        /// </summary>
        /// <param name="item">PostReply</param>
        public void Add(PostReply item)
        {
            db.PostReplies.Add(item);
            db.SaveChanges();
        }

        /// <summary>
        /// Method to remove an item from the database.
        /// </summary>
        /// <param name="item">PostReply</param>
        public void Remove(PostReply item)
        {
            db.PostReplies.Remove(item);
            db.SaveChanges();
        }

        /// <summary>
        /// Method to find a PostReply from database using ID.
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>PostReply</returns>
        public PostReply Find(int id)
        {
            return db.PostReplies.Find(id);
        }

        /// <summary>
        /// Method to edit an existing item from the database.
        /// </summary>
        /// <param name="item">PostReply</param>
        /// <exception cref="ArgumentException">Thrown if the edit item doesn't exist in the database using the key.</exception>
        public void Edit(PostReply item)
        {
            PostReply postReplyToUpdate = db.PostReplies.
                Where(a => a.Id == item.Id).FirstOrDefault();

            if (null == postReplyToUpdate)
            {
                throw new ArgumentException("PostReply with ID " + item.Id +
                    " and author " + item.Author.Username + "is unknown to the database, " +
                    "Edit operations is unavailable.", "Comment");
            }
            else
            {
                db.Entry(postReplyToUpdate).CurrentValues.SetValues(item);
            }
            db.SaveChanges();
        }

        /// <summary>
        /// Method to get an enumerator with all PostReplies in the database.
        /// </summary>
        /// <returns>IEnumerable&lt;PostReply&gt;</returns>
        public IEnumerable<PostReply> All()
        {
            return db.PostReplies
                .Include(postReply => postReply.Head)
                .Include(postReply => postReply.Author)
                .Include(postReply => postReply.Comments)
                .Include(postReply => postReply.UpVotes)
                .Include(postReply => postReply.DownVotes)
                .ToList();
        }
    }
}