using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace SocialMedia.Repositories
{
    public class TagRepository : IRepository<Tag, int>
    {
        // The context
        protected SocialMediaContext db;

        /// <summary>
        /// Initialize a new instance of the 
        /// TagRepository with the provided context.
        /// </summary>
        /// <param name="context">The context.</param>
        public TagRepository(SocialMediaContext context)
        {
            db = context;
        }

        /// <summary>
        /// Method to add an item to the database.
        /// </summary>
        /// <param name="item">Tag</param>
        public void Add(Tag item)
        {
            db.Tags.Add(item);
            db.SaveChanges();
        }

        /// <summary>
        /// Method to remove an item from the database.
        /// </summary>
        /// <param name="item">Tag</param>
        public void Remove(Tag item)
        {
            db.Tags.Remove(item);
            db.SaveChanges();
        }

        /// <summary>
        /// Method to find a Tag from database using ID.
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Tag</returns>
        public Tag Find(int id)
        {
            return db.Tags.Find(id);
        }

        /// <summary>
        /// Method to edit an existing item from the database.
        /// </summary>
        /// <param name="item">Tag</param>
        /// <exception cref="ArgumentException">Thrown if the edit item doesn't exist in the database using the key.</exception>
        public void Edit(Tag item)
        {
            Tag tagToUpdate = db.Tags.
                 Where(a => a.Id == item.Id).FirstOrDefault();

            if (null == tagToUpdate)
            {
                throw new ArgumentException("Tag with ID " + item.Id +
                    " and tag " + item.Text + "is unknown to the database, " +
                    "Edit operations is unavailable.", "Tag");
            }
            else
            {
                db.Entry(tagToUpdate).CurrentValues.SetValues(item);
            }
            db.SaveChanges();
        }

        /// <summary>
        /// Method to get an enumerator with all Tags in the database.
        /// </summary>
        /// <returns>IEnumerable&lt;Tag&gt;</returns>
        public IEnumerable<Tag> All()
        {
            return db.Tags
                .Include(tag => tag.Followers)
                .ToList();
        }
    }
}