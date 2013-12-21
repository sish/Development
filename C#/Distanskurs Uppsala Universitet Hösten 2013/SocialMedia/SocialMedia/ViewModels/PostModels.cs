using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SocialMedia.ViewModels
{
    public class IDLight
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="id">int</param>
        /// <param name="text">string</param>
        public IDLight(int id, string text)
        {
            ID = id;
            Text = text;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="author">Author object.</param>
        public IDLight(User author)
        {
            ID = author.Id;
            Text = author.Username;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tag">Tag object.</param>
        public IDLight(Tag tag)
        {
            ID = tag.Id;
            Text = tag.Text;
        }

        /// <summary>
        /// ID property that is unique for a text.
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Text property that the ID is connected to, not unique.
        /// </summary>
        public string Text { get; set; }
    }

    public class PostLight
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public PostLight()
        {
            PostID = -1;
            Posted = DateTime.MinValue;
            Title = string.Empty;
            Author = null;
            Answers = -1;
            Comments = -1;
            Votes = -1;
            Tags = new List<IDLight>();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="post">Post object.</param>
        public PostLight(Post post)
        {
            PostID = post.Id;
            Posted = post.TimeOfPost;
            Title = post.Title;
            Author = new IDLight(post.Author);
            Answers = post.Replies.Count;
            Comments = post.Comments.Count;
            Votes = post.UpVotes.Count + post.DownVotes.Count;
            Tags = new List<IDLight>();
            if( 0 < post.Tags.Count )
                Tags.AddRange(post.Tags
                    .Select(tag => new IDLight(tag)));
        }

        /// <summary>
        /// Unique id for the post property
        /// </summary>
        public int PostID { get; set; }

        /// <summary>
        /// Poperty holding info about when the post was posted.
        /// </summary>
        public DateTime Posted { get; set; }

        /// <summary>
        /// Propert with the title of the post.
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Property holding the author of the post.
        /// </summary>
        public IDLight Author { get; set; }

        /// <summary>
        /// Property holding the number of Answers to the post.
        /// </summary>
        public int Answers { get; set; }

        /// <summary>
        /// Propery holding the number of comments in the post.
        /// </summary>
        public int Comments { get; set; }

        /// <summary>
        /// Propery holding the number of votes of the post.
        /// </summary>
        public int Votes { get; set; }

        /// <summary>
        /// Property with a list of all tags in the post.
        /// </summary>
        public List<IDLight> Tags { get; set; }
    }

    public class PostOverview
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public PostOverview()
        {
            Posts = new List<PostLight>();
            SubMenu = null;
            Key = null;
        }

        /// <summary>
        /// Propery with all posts in a light manner.
        /// </summary>
        public List<PostLight> Posts { get; set; }

        /// <summary>
        /// Propery with the key to use.
        /// </summary>
        public IDLight Key { get; set; }

        /// <summary>
        /// Property with the sub menu model that should be used.
        /// </summary>
        public SubMenuModel SubMenu { get; set; }
    }

    public class PostOverviewPartial
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="overview">PostOverview object</param>
        /// <param name="onClick">string with the onclick method to add.</param>
        public PostOverviewPartial(PostOverview overview, string onClick)
        {
            this.PostOverview = overview;
            this.OnClick = onClick;
            this.ButtonName = null;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="overview">PostOverview object</param>
        /// <param name="onClick">string with the onclick method to add.</param>
        /// <param name="buttonName">String with the name of the name if other than Create.</param>
        public PostOverviewPartial(PostOverview overview, string onClick, string buttonName) :
            this(overview, onClick)
        {
            this.ButtonName = buttonName;
        }

        /// <summary>
        /// Property with the PostOverview object.
        /// </summary>
        public PostOverview PostOverview { get; set; }
        /// <summary>
        /// String property with the onclick method.
        /// </summary>
        public string OnClick { get; set; }
        /// <summary>
        /// String propery with the new button name.
        /// </summary>
        public string ButtonName { get; set; }
    }

    public class CommentModel
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public CommentModel()
        {
            Comments = new List<Comment>();
            PostID = -1;
            ReplyID = -1;
            this.AddComment = false;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="post">Post object param</param>
        public CommentModel(Post post)
        {
            this.Comments = post.Comments.ToList();
            this.PostID = post.Id;
            this.ReplyID = -1;
            this.AddComment = false;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reply">PostReply object.</param>
        public CommentModel(PostReply reply)
        {
            this.Comments = reply.Comments.ToList();
            this.PostID = -1;
            this.ReplyID = reply.Id;
            this.AddComment = false;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="comment">CreateComment method.</param>
        public CommentModel(CreateComment comment)
        {
            this.Comments = comment.Comments;
            this.PostID = comment.HeadID;
            this.ReplyID = (comment.IsReply ? comment.ID : -1);
            this.AddComment = true;
        }

        /// <summary>
        /// Propery with a list of comments.
        /// </summary>
        public List<Comment> Comments { get; set; }
        /// <summary>
        /// Property with the postId for the comments.
        /// </summary>
        public int PostID { get; set; }
        /// <summary>
        /// Property with the replyId for the comments.
        /// </summary>
        public int ReplyID { get; set; }
        /// <summary>
        /// Property with information if we add or show comments.
        /// </summary>
        public bool AddComment { get; set; }
    }

    public class ViewLeftSideModel
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public ViewLeftSideModel()
        {
            this.ID = -1;
            this.HeadID = -1;
            this.UpVotes = new List<User>();
            this.DownVotes = new List<User>();
            this.IsSolution = false;
            this.IsReply = true;
            this.HasSolution = false;
            this.PostAuthor = string.Empty;
            this.Author = string.Empty;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="post">Post object.</param>
        public ViewLeftSideModel(Post post)
        {
            this.ID = post.Id;
            this.HeadID = post.Id;
            this.UpVotes = post.UpVotes.ToList();
            this.DownVotes = post.DownVotes.ToList();
            this.IsSolution = false;
            this.IsReply = false;
            this.HasSolution = post.Replies
                .Where(p => p.CorrectAnswer == true)
                .SingleOrDefault() == null ? false : true;
            this.PostAuthor = post.Author.Username.ToLower();
            this.Author = post.Author.Username.ToLower();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reply">PostReply object.</param>
        public ViewLeftSideModel(PostReply reply)
        {
            this.ID = reply.Id;
            this.HeadID = reply.Head.Id;
            this.UpVotes = reply.UpVotes.ToList();
            this.DownVotes = reply.DownVotes.ToList();
            this.IsSolution = reply.CorrectAnswer;
            this.IsReply = true;
            this.HasSolution = reply.Head.Replies
                .Where(post => post.CorrectAnswer == true)
                .SingleOrDefault() == null ? false : true;
            this.PostAuthor = reply.Head.Author.Username.ToLower();
            this.Author = reply.Author.Username.ToLower();
        }

        /// <summary>
        /// Construcotr
        /// </summary>
        /// <param name="comment">CreateComment object.</param>
        public ViewLeftSideModel(CreateComment comment)
        {
            this.ID = comment.ID;
            this.HeadID = comment.HeadID;
            this.UpVotes = comment.UpVotes;
            this.DownVotes = comment.DownVotes;
            this.HasSolution = comment.HasSolution;
            this.IsSolution = false;
            this.IsReply = comment.IsReply;
            this.PostAuthor = comment.Author.ToLower();
            this.Author = comment.Author.ToLower();
        }

        /// <summary>
        /// Property holding the id of the reply or post.
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Property holding the if of the post
        /// </summary>
        public int HeadID { get; set; }
        /// <summary>
        /// Property with a list of the users that votes up for the post or reply.
        /// </summary>
        public List<User> UpVotes { get; set; }
        /// <summary>
        /// Property with a list of the users that votes down for the post or reply.
        /// </summary>
        public List<User> DownVotes { get; set; }
        /// <summary>
        /// Property if the post has a valid solution.
        /// </summary>
        public bool HasSolution { get; set; }
        /// <summary>
        /// Property if this reply is the correct solution
        /// </summary>
        public bool IsSolution { get; set; }
        /// <summary>
        /// Property if this is a reply.
        /// </summary>
        public bool IsReply { get; set; }
        /// <summary>
        /// Property with the post or replys author.
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// Property with the post author.
        /// </summary>
        public string PostAuthor { get; set; }
    }

    public class CreateComment
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public CreateComment()
        {
            Comments = new List<Comment>();
            DownVotes = new List<User>();
            UpVotes = new List<User>();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="post">Post object.</param>
        public CreateComment(Post post)
            : this()
        {
            ID = post.Id;
            HeadID = post.Id;
            HasSolution = post.Replies
                .Where(p => p.CorrectAnswer == true)
                .SingleOrDefault() == null ? false : true;
            IsReply = false;
            Title = post.Title;
            Text = post.Text;
            Author = post.Author.Username;
            TimeOfPost = post.TimeOfPost;
            UpVotes = post.UpVotes.ToList();
            DownVotes = post.DownVotes.ToList();
            Comments = post.Comments.ToList();
            AuthorID = post.Author.Id;
        }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="reply">PostReply object.</param>
        public CreateComment(PostReply reply) :
            this()
        {
            ID = reply.Id;
            HeadID = reply.Head.Id;
            HasSolution = reply.Head.Replies
                .Where(post => post.CorrectAnswer == true)
                .SingleOrDefault() == null ? false : true;
            IsReply = true;
            Title = reply.Head.Title;
            Text = reply.Text;
            Author = reply.Author.Username;
            TimeOfPost = reply.TimeOfPost;
            UpVotes = reply.UpVotes.ToList();
            DownVotes = reply.DownVotes.ToList();
            Comments = reply.Comments.ToList();
            AuthorID = reply.Author.Id;
        }

        /// <summary>
        /// Property holding the ID
        /// </summary>
        public int ID { get; set; }
        /// <summary>
        /// Property holdng the post ID
        /// </summary>
        public int HeadID { get; set; }
        /// <summary>
        /// Property holding if we have a solution.
        /// </summary>
        public bool HasSolution { get; set; }
        /// <summary>
        /// Property with information if this is a reply.
        /// </summary>
        public bool IsReply { get; set; }
        /// <summary>
        /// Property with the title of the post.
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// Property with the text.
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Property with the author of the post or reply.
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// Property with the id of the author.
        /// </summary>
        public int AuthorID { get; set; }
        /// <summary>
        /// Property with the user voted this reply or post up.
        /// </summary>
        public List<User> UpVotes { get; set; }
        /// <summary>
        /// Property with the user voted this reply or post down.
        /// </summary>
        public List<User> DownVotes { get; set; }
        /// <summary>
        /// Property with the time of the post.
        /// </summary>
        public DateTime TimeOfPost { get; set; }
        /// <summary>
        /// Property with a list of comments for the post or reply.
        /// </summary>
        public List<Comment> Comments { get; set; }
    }

    public class PostCreate
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public PostCreate()
        {
            this.Title = string.Empty;
            this.Text = string.Empty;
            this.FreeTags = string.Empty;
            this.Tags = new List<Tag>();
            this.SelectedTags = new List<int>();
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="tags">List of tags</param>
        public PostCreate(List<Tag> tags)
        {
            this.Title = string.Empty;
            this.Text = string.Empty;
            this.FreeTags = string.Empty;
            this.Tags = tags;
            this.SelectedTags = new List<int>();
        }

        /// <summary>
        /// Property with the Title of the post.
        /// </summary>
        [Required]
        public string Title { get; set; }
        /// <summary>
        /// Property with the Text of the post.
        /// </summary>
        [Required]
        public string Text { get; set; }
        /// <summary>
        /// Property with a list of the selected tags.
        /// </summary>
        public List<int> SelectedTags { get; set; }
        /// <summary>
        /// Property with a list of selectable tags.
        /// </summary>
        public ICollection<Tag> Tags { get; set; }
        /// <summary>
        /// Property with newly created tags.
        /// </summary>
        public string FreeTags { get; set; }
    }

    public class CreateReply
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public CreateReply()
        {
            this.PostID = -1;
            this.PostAuthor = string.Empty;
            this.PostText = string.Empty;
            this.PostTitle = string.Empty;
            this.Text = string.Empty;
            this.PostTime = DateTime.MinValue;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="post">Post object.</param>
        public CreateReply(Post post)
        {
            this.PostID = post.Id;
            this.PostAuthor = post.Author.Username;
            this.PostText = post.Text;
            this.PostTitle = post.Title;
            this.PostTime = post.TimeOfPost;
            this.Text = string.Empty;
        }

        /// <summary>
        /// Property with the post id to create reply to.
        /// </summary>
        public int PostID { get; set; }
        /// <summary>
        /// Property with the post title.
        /// </summary>
        public string PostTitle { get; set; }
        /// <summary>
        /// Property with the post text.
        /// </summary>
        public string PostText { get; set; }
        /// <summary>
        /// Property with the post author.
        /// </summary>
        public string PostAuthor { get; set; }
        /// <summary>
        /// Property of the time of the post.
        /// </summary>
        public DateTime PostTime { get; set; }
        /// <summary>
        /// Property of the postReply text.
        /// </summary>
        [Required]
        public string Text { get; set; }
    }

}