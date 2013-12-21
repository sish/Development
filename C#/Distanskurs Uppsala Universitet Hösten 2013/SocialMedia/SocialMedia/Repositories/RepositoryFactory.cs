using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using SocialMedia.Models;

namespace SocialMedia.Repositories
{
    /// <summary>
    /// This class handles instantiation of the repositories.
    /// </summary>
    public class RepositoryFactory
    {
        /// <summary>
        /// Wrapper property to get a context instance.
        /// </summary>
        static SocialMediaContext context
        {
            get { return ContextFactory.GetContext(); }
        }

        /// <summary>
        /// Retrive a comment repository instance.
        /// </summary>
        public static CommentRepository GetCommentRepository()
        {
            return new CommentRepository(context);
        }

        /// <summary>
        /// Retrive a post reply repository instance.
        /// </summary>
        public static PostReplyRepository GetPostReplyRepository()
        {
            return new PostReplyRepository(context);
        }

        /// <summary>
        /// Retrive a post repository instance.
        /// </summary>
        public static PostRepository GetPostRepository()
        {
            return new PostRepository(context);
        }

        /// <summary>
        /// Retrive a role repository instance.
        /// </summary>
        public static RoleRepository GetRoleRepository()
        {
            return new RoleRepository(context);
        }

        /// <summary>
        /// Retrive a tag repository instance.
        /// </summary>
        public static TagRepository GetTagRepository()
        {
            return new TagRepository(context);
        }

        /// <summary>
        /// Retrive a user repository instance.
        /// </summary>
        public static UserRepository GetUserRepository()
        {
            return new UserRepository(context);
        }

        
    }
}