using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using SocialMedia.Repositories;
using SocialMedia.Models;

namespace SocialMedia.Providers
{
    public class SimpleRoleProvider : RoleProvider
    {
        /// <summary>
        /// Property to acces a user repository.
        /// </summary>
        IUserRepository _userRepository
        {
            get
            {
                IUserRepository userRepository = RepositoryFactory.GetUserRepository();

                return userRepository;
            }
        }

        /// <summary>
        /// Determines if a user has a specific role.
        /// </summary>
        /// <param name="username">The name of the user.</param>
        /// <param name="roleName">The name of the role.</param>
        public override bool IsUserInRole(string username, string roleName)
        {
            var roles = GetRolesForUser(username);

            bool isUserInRole = roles.Contains(roleName);

            return isUserInRole;
        }        

        /// <summary>
        /// Gets all roles for user.
        /// </summary>
        /// <param name="username">The name of the user.</param>
        public override string[] GetRolesForUser(string username)
        {
            User user = _userRepository.GetByUserName(username);
            if (user != null)
                return user.Roles.Select(r => r.Name).ToArray();
            else
                return new string[0];
        }

        // Abstract methods that is not implemented on purpose
        #region
        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override string ApplicationName
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }


        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}