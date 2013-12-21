using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialMedia.Repositories
{
    public class RoleRepository : IRepository<Role, int>
    {
        // The context
        protected SocialMediaContext db;

        /// <summary>
        /// Initialize a new instance of the 
        /// RoleRepository with the provided context.
        /// </summary>
        /// <param name="context">The context.</param>
        public RoleRepository(SocialMediaContext context)
        {
            db = context;
        }

        /// <summary>
        /// Method to add an item to the database.
        /// </summary>
        /// <param name="item">Role</param>
        public void Add(Role item)
        {
            db.Roles.Add(item);
            db.SaveChanges();
        }

        /// <summary>
        /// Method to remove an item from the database.
        /// </summary>
        /// <param name="item">Role</param>
        public void Remove(Role item)
        {
            db.Roles.Remove(item);
            db.SaveChanges();
        }

        /// <summary>
        /// Method to find a Role from database using ID.
        /// </summary>
        /// <param name="id">int</param>
        /// <returns>Role</returns>
        public Role Find(int id)
        {
            return db.Roles.Find(id);
        }

        /// <summary>
        /// Method to edit an existing item from the database.
        /// </summary>
        /// <param name="item">Role</param>
        /// <exception cref="ArgumentException">Thrown if the edit item doesn't exist in the database using the key.</exception>
        public void Edit(Role item)
        {
            Role roleToUpdate = db.Roles.
                Where(a => a.Id == item.Id).FirstOrDefault();

            if (null == roleToUpdate)
            {
                throw new ArgumentException("Role with ID " + item.Id +
                    " and role " + item.Name + "is unknown to the database, " +
                    "Edit operations is unavailable.", "Comment");
            }
            else
            {
                db.Entry(roleToUpdate).CurrentValues.SetValues(item);
            }
            db.SaveChanges();
        }

        /// <summary>
        /// Method to get an enumerator with all Roles in the database.
        /// </summary>
        /// <returns>IEnumerable&lt;Role&gt;</returns>
        public IEnumerable<Role> All()
        {
            return db.Roles.ToList();
        }
    }
}