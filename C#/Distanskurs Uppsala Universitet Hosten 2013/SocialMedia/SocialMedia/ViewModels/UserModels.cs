using SocialMedia.Models;
using SocialMedia.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialMedia.ViewModels
{

    public class UserOverView
    {
        /// <summary>
        /// Constant for checkbox handling
        /// </summary>
        public const int FOLLOW_MYSELF = -2;
        /// <summary>
        /// Constant for checkbox handling
        /// </summary>
        public const int FOLLOW_NOT_FOLLOWING = -1;
        /// <summary>
        /// Constant for checkbox handling
        /// </summary>
        public const int FOLLOW_UNDEFINED = 0;
        /// <summary>
        /// Constant for checkbox handling
        /// </summary>
        public const int FOLLOW_FOLLOWING = 1;

        /// <summary>
        /// Constructor
        /// </summary>
        public UserOverView()
        {
            this.ID = -1;
            this.Following = FOLLOW_UNDEFINED;
            this.Name = string.Empty;
            this.Posts = -1;
            this.Replies = -1;
            this.Followers = -1;
            this.Answers = -1;
            this.Comments = -1;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="user">User object</param>
        /// <param name="userLoggedIn">User object</param>
        public UserOverView(User user, User userLoggedIn)
        {
            this.ID = user.Id;
            this.Name = user.Username;
            this.Posts = user.Posts.Count();
            this.Replies = user.PostReplies.Count();
            this.Followers = user.Followers.Count();
            this.Comments = RepositoryFactory.GetCommentRepository().All()
                .Where(comment => comment.Author.Id == user.Id)
                .Count();
            this.Answers = RepositoryFactory.GetPostReplyRepository().All()
                .Where(reply => reply.Author.Id == user.Id)
                .Where(reply => reply.CorrectAnswer == true)
                .Count();
            if( null == userLoggedIn )
            {
                this.Following = FOLLOW_UNDEFINED;
            }
            else if ( user.Id == userLoggedIn.Id )
            {
                this.Following = FOLLOW_MYSELF;
            }
            else if (user.Followers.Contains(userLoggedIn))
            {
                this.Following = FOLLOW_FOLLOWING;
            }
            else
            {
                this.Following = FOLLOW_NOT_FOLLOWING;
            }
        }
        /// <summary>
        /// Property holding the id
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Property holding the name
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Number of users the user is following
        /// </summary>
        public int Following { get; set; }
        /// <summary>
        /// Number of posts by the user.
        /// </summary>
        public int Posts { get; set; }
        /// <summary>
        /// Number of replies by the user.
        /// </summary>
        public int Replies { get; set; }
        /// <summary>
        /// Number of followers the user have.
        /// </summary>
        public int Followers { get; set; }
        /// <summary>
        /// Number of correct answers by the user.
        /// </summary>
        public int Answers { get; set; }
        /// <summary>
        /// Number of commments by the user.
        /// </summary>
        public int Comments { get; set; }
    }

    public class UsersModel
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="isLoggedIn">Bool if a user is logged in.</param>
        public UsersModel(bool isLoggedIn)
        {
            this.Users = new List<UserOverView>();
            this.IsLoggedIn = isLoggedIn;
            Pages = null;
        }

        /// <summary>
        /// List of the user overview items
        /// </summary>
        public List<UserOverView> Users { get; set; }
        /// <summary>
        /// Property if a user is loggedin
        /// </summary>
        public bool IsLoggedIn { get; set; }
        /// <summary>
        /// Property holding the paging attribute
        /// </summary>
        public Paging Pages { get; set; }
    }

    public class Paging
    {
        /// <summary>
        /// Default setting of the Page size, maybe change this to a user setting later.
        /// </summary>
        public const int ConstPageSize = 20;
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="totalCount">int with the total number of items</param>
        /// <param name="pageIndex">int with the current pageindex</param>
        public Paging(int totalCount, int pageIndex)
        {
            PageIndex = pageIndex;
            PageSize = ConstPageSize;
            TotalCount = totalCount;
            TotalPages = (int)Math.Ceiling(TotalCount / (double)PageSize);
        }
        /// <summary>
        /// Property for the current page index
        /// </summary>
        public int PageIndex { get; private set; }
        /// <summary>
        /// Propert for the number of items per page.
        /// </summary>
        public int PageSize { get; private set; }
        /// <summary>
        /// Property for the total number of items.
        /// </summary>
        public int TotalCount { get; private set; }
        /// <summary>
        /// Property for the total number of pages.
        /// </summary>
        public int TotalPages { get; private set; }
        /// <summary>
        /// Property if we have a previous page available.
        /// </summary>
        public bool HasPreviousPage
        {
            get
            {
                return (PageIndex > 0);
            }
        }
        /// <summary>
        /// Property if we have a next page available.
        /// </summary>
        public bool HasNextPage
        {
            get
            {
                return (PageIndex + 1 < TotalPages);
            }
        }
    }
}