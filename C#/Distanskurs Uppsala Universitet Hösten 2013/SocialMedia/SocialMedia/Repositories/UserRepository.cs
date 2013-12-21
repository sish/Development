using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SocialMedia.Models;
using SocialMedia.Providers;

namespace SocialMedia.Repositories
{
    /// <summary>
    /// Interface that is used together with the SimpleMembershipProvider.
    /// </summary>
    public interface IUserRepository
    {
        User GetByUserName(string username);
    }

    public class UserRepository : IUserRepository, IRepository<User, int>
    {
        // The context
        protected SocialMediaContext db;

        /// <summary>
        /// Initialize a new instance of the 
        /// UserRepository with the provided context.
        /// </summary>
        /// <param name="context">The context.</param>
        public UserRepository(SocialMediaContext context)
        {
            db = context;
        }

        /// <summary>
        /// Add a user to the data storage.
        /// </summary>
        /// <param name="user">The user to add.</param>
        public void Add(User user)
        {
            // Encrypt password before saving to database
            user.Password = SimpleMembershipProvider.EncryptPassword(user.Password);

            db.Users.Add(user);

            db.SaveChanges();
        }

        /// <summary>
        /// Retrive a user by its username.
        /// </summary>
        /// <param name="username">The username.</param>
        public User GetByUserName(string username)
        {
            var user = db.Users.FirstOrDefault(u => u.Username.ToLower() == username.ToLower());

            return user;
        }

        /// <summary>
        /// Method to remove an item from the database.
        /// </summary>
        /// <param name="item">User</param>
        public void Remove(User item)
        {
            db.Users.Remove(item);
            db.SaveChanges();
        }

        /// <summary>
        /// Method to find a User from database using ID.
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>User</returns>
        public User Find(int id)
        {
            return db.Users.Find(id);
        }

        /// <summary>
        /// Method to edit an existing item from the database.
        /// </summary>
        /// <param name="item">User</param>
        /// <exception cref="ArgumentException">Thrown if the edit item doesn't exist in the database using the key.</exception>
        public void Edit(User item)
        {
            User userToUpdate = db.Users.
                Where(a => a.Id == item.Id).FirstOrDefault();

            if (null == userToUpdate)
            {
                throw new ArgumentException("User with ID " + item.Id +
                    " and name " + item.Username + "is unknown to the database, " +
                    "Edit operations is unavailable.", "Comment");
            }
            else
            {
                db.Entry(userToUpdate).CurrentValues.SetValues(item);
            }
            db.SaveChanges();
        }

        /// <summary>
        /// Method to get an enumerator with all Users in the database.
        /// </summary>
        /// <returns>IEnumerable&lt;User&gt;</returns>
        public IEnumerable<User> All()
        {
            return db.Users
                .Include(user => user.Posts)
                .Include(user => user.PostReplies)
                .Include(user => user.Roles)
                .Include(user => user.Followers)
                .ToList();
        }
    }
}