using SocialMedia.Models;
using SocialMedia.Repositories;
using SocialMedia.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SocialMedia.Controllers
{
    public class PostController : Controller
    {
        private PostRepository PostDB;
        private TagRepository TagDB;
        private PostReplyRepository PostReplyDB;
        private CommentRepository CommentDB;
        private UserRepository UserDB;

        public PostController()
        {
            this.PostDB = RepositoryFactory.GetPostRepository();
            this.TagDB = RepositoryFactory.GetTagRepository();
            this.PostReplyDB = RepositoryFactory.GetPostReplyRepository();
            this.CommentDB = RepositoryFactory.GetCommentRepository();
            this.UserDB = RepositoryFactory.GetUserRepository();
        }

        //
        // GET: /Post/
        public ActionResult Index(string type, string search = null)
        {
            var controller = new SubMenuModel();
            controller.Items.Add(new MenuItem("Latest Posts", "Post", "Index", true));
            controller.Items.Add(new MenuItem("Not Answered", "Post", "NotAnswered"));
            var posts = this.PostDB.All()
                .Where(post => search == null || 
                    "title" == type && post.Title.ToLower().Contains(search.ToLower()) ||
                    "user" == type && post.Author.Username.ToLower().Contains(search.ToLower()) ||
                    "text" == type && post.Text.ToLower().Contains(search.ToLower()))
                .OrderByDescending(post => post.TimeOfPost)
                .ToList();
            PostOverview model = new PostOverview();
            model.SubMenu = controller;
            model.Posts.AddRange(posts.Select(post => new PostLight(post)));
            return View(model);
        }

        //
        // GET: /Post/NotAnswered
        public ActionResult NotAnswered(string type, string search = null)
        {
            var controller = new SubMenuModel();
            controller.Items.Add(new MenuItem("Latest Posts", "Post", "Index"));
            controller.Items.Add(new MenuItem("Not Answered", "Post", "NotAnswered", true));
            var posts = this.PostDB.All()
                .Where(post => post.Replies.Count == 0)
                .Where(post => search == null ||
                    "title" == type && post.Title.ToLower().Contains(search.ToLower()) ||
                    "user" == type && post.Author.Username.ToLower().Contains(search.ToLower()) ||
                    "text" == type && post.Text.ToLower().Contains(search.ToLower()))
                .OrderByDescending(post => post.TimeOfPost)
                .ToList();
            PostOverview model = new PostOverview();
            model.SubMenu = controller;
            model.Posts.AddRange(posts.Select(post => new PostLight(post)));
            return View(model);
        }

        //
        // GET: /Post/Create
        [HttpGet]
        public ActionResult Create()
        {
            if (true != User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                PostCreate post = new PostCreate(this.TagDB.All().ToList());
                return View(post);
            }
        }

        //
        // POST: /Post/Create
        [HttpPost]
        [Authorize]
        public ActionResult Create(PostCreate p, int[] selectedtags)
        {
            if (null != p.FreeTags)
            {
                string[] split = p.FreeTags.Split(';');
                if (null != this.TagDB.All().Where(tag => split.Contains(tag.Text)).FirstOrDefault())
                {
                    ModelState.AddModelError("freetags", "Cannot add already existing tags.");
                }
            }
            if ((null == selectedtags || 0 == selectedtags.Length) && (null == p.FreeTags || string.Empty == p.FreeTags))
            {
                ModelState.AddModelError("CheckBox", "Need to have at least one tag.");
            }
            if (ModelState.IsValid)
            {
                Post post = new Post();
                post.Title = p.Title;
                post.Text = p.Text;
                post.Author = this.UserDB.GetByUserName(User.Identity.Name);
                if (null != selectedtags)
                {
                    post.Tags = this.TagDB.All()
                        .Where(tag => selectedtags.Contains(tag.Id))
                        .ToList();
                }
                if (null != p.FreeTags)
                {
                    string[] split = p.FreeTags.Split(';');
                    foreach (string str in split)
                    {
                        post.Tags.Add(new Tag(str));
                    }
                }
                post.TimeOfPost = DateTime.UtcNow;
                this.PostDB.Add(post);
                return RedirectToAction("Index", "Post");
            }
            else
            {
                p.Tags = this.TagDB.All().ToList();
                if (null != selectedtags)
                {
                    p.SelectedTags = selectedtags.ToList();
                }
                return View(p);
            }
        }

                //
        // GET: /Post/CreateReply/30
        [HttpGet]
        public ActionResult CreateReply(int id)
        {
            if (true != User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                CreateReply rep = new CreateReply(this.PostDB.Find(id));
                return View(rep);
            }
        }

        //
        // POST: /Post/CreateReply
        [HttpPost]
        [Authorize]
        public ActionResult CreateReply(int id, CreateReply reply)
        {
            if (ModelState.IsValid)
            {
                PostReply pReply = new PostReply();
                pReply.Author = this.UserDB.GetByUserName(User.Identity.Name);
                pReply.Head = this.PostDB.Find(id);
                pReply.Text = reply.Text;
                pReply.TimeOfPost = DateTime.UtcNow;
                this.PostReplyDB.Add(pReply);
                return RedirectToAction("View", "Post", new { Id = id });
            }
            else
            {
                return View(reply);
            }
        }

        //
        // GET: /Post/View/5

        public ActionResult View(int id)
        {
            var model = this.PostDB.Find(id);
            return View(model);
        }

        //
        // GET: /Post/ByTag/5
        public ActionResult ByTag(int id, string type, string search = null)
        {
            var tag = this.TagDB.Find(id);
            var posts = from post in this.PostDB.All()
                        where post.Tags.Contains(tag) &&
                        (null == search ||
                        "title" == type && post.Title.ToLower().Contains(search.ToLower()) ||
                        "user" == type && post.Author.Username.ToLower().Contains(search.ToLower()) ||
                        "text" == type && post.Text.ToLower().Contains(search.ToLower()))
                        orderby post.TimeOfPost descending
                        select post;
            PostOverview model = new PostOverview();
            model.Key = new IDLight(tag.Id, tag.Text);
            model.Posts.AddRange(posts.Select(post => new PostLight(post)));
            User user = this.UserDB.GetByUserName(User.Identity.Name);
            ViewBag.IsFollower = (bool)(this.TagDB.All()
                .Where(t => t.Id == id)
                .Where(t => t.Followers.Contains(user))
                .SingleOrDefault() != null);
            return View(model);
        }

        //
        // GET: /Post/ByAuthor/5
        public ActionResult ByAuthor(int id, string type, string search = null)
        {
            var author = RepositoryFactory.GetUserRepository().Find(id);
            var posts = from post in this.PostDB.All()
                        where post.Author.Id == id &&
                        ( search == null ||
                        "title" == type && post.Title.ToLower().Contains(search.ToLower()) ||
                        "user" == type && post.Author.Username.ToLower().Contains(search.ToLower()) ||
                        "text" == type && post.Text.ToLower().Contains(search.ToLower()) )
                        orderby post.TimeOfPost descending
                        select post;
            PostOverview model = new PostOverview();
            model.Key = new IDLight(author.Id, author.Username);
            model.Posts.AddRange(posts.Select(post => new PostLight(post)));
            User user = this.UserDB.GetByUserName(User.Identity.Name);
            ViewBag.IsFollower = (bool)(this.UserDB.All()
                .Where(u => u.Id == id)
                .Where(u => u.Followers.Contains(user))
                .SingleOrDefault() != null);
            ViewBag.IsMyself = (bool)(user.Id == id);
            return View(model);
        }
        
        //
        // GET: Post/AddComment?PostID=-1&ReplyID=14
        public ActionResult AddComment(int PostID, int ReplyID)
        {
            if (true != User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                CreateComment model;
                if (-1 != PostID)
                {
                    model = new CreateComment(this.PostDB.Find(PostID));
                }
                else
                {
                    model = new CreateComment(this.PostReplyDB.Find(ReplyID));
                }
                return View(model);
            }
        }

        //
        // POST: Post/AddComment
        [HttpPost]
        [Authorize]
        public ActionResult AddComment(int PostID, int ReplyID, string comment)
        {
            Comment c = new Comment();
            c.Author = this.UserDB.GetByUserName(User.Identity.Name);
            c.Text = comment;
            c.TimeOfPost = DateTime.UtcNow;
            int id = -1;
            if (-1 != ReplyID)
            {
                PostReply r = this.PostReplyDB.Find(ReplyID);
                r.Comments.Add(c);
                this.PostReplyDB.Edit(r);
                id = r.Head.Id;
            }
            else
            {
                Post p = this.PostDB.Find(PostID);
                p.Comments.Add(c);
                this.PostDB.Edit(p);
                id = PostID;
            }
            return RedirectToAction("View", "Post", new { Id = id });
        }

        //
        // GET: Post/toggleupvote/24?IsReply=True?HeadID=24
        public ActionResult toggleupvote(int id, bool IsReply, int HeadID)
        {
            User u = this.UserDB.GetByUserName(User.Identity.Name);
            if (true != IsReply)
            {
                Post p = this.PostDB.Find(id);
                if (p.UpVotes.Where(user => user.Id == u.Id).FirstOrDefault() == null)
                {
                    p.UpVotes.Add(u);
                    if (p.DownVotes.Where(user => user.Id == u.Id).FirstOrDefault() != null)
                    {
                        p.DownVotes.Remove(u);
                    }
                }
                else
                {
                    p.UpVotes.Remove(u);
                }
                this.PostDB.Edit(p);
            }
            else
            {
                PostReply r = this.PostReplyDB.Find(id);
                if (r.UpVotes.Where(user => user.Id == u.Id).FirstOrDefault() == null)
                {
                    r.UpVotes.Add(u);
                    if (r.DownVotes.Where(user => user.Id == u.Id).FirstOrDefault() != null)
                    {
                        r.DownVotes.Remove(u);
                    }
                }
                else
                {
                    r.UpVotes.Remove(u);
                }
                this.PostReplyDB.Edit(r);
            }
            return RedirectToAction("View", "Post", new { Id = HeadID });
        }

        //
        // GET: Post/toggledownvote/24?IsReply=True?HeadID=24
        public ActionResult toggledownvote(int id, bool IsReply, int HeadID)
        {
            User u = this.UserDB.GetByUserName(User.Identity.Name);
            if (true != IsReply)
            {
                Post p = this.PostDB.Find(id);
                if (p.DownVotes.Where(user => user.Id == u.Id).FirstOrDefault() == null)
                {
                    p.DownVotes.Add(u);
                    if (p.UpVotes.Where(user => user.Id == u.Id).FirstOrDefault() != null)
                    {
                        p.UpVotes.Remove(u);
                    }
                }
                else
                {
                    p.DownVotes.Remove(u);
                }
                this.PostDB.Edit(p);
            }
            else
            {
                PostReply r = this.PostReplyDB.Find(id);
                if (r.DownVotes.Where(user => user.Id == u.Id).FirstOrDefault() == null)
                {
                    r.DownVotes.Add(u);
                    if (r.UpVotes.Where(user => user.Id == u.Id).FirstOrDefault() != null)
                    {
                        r.UpVotes.Remove(u);
                    }
                }
                else
                {
                    r.DownVotes.Remove(u);
                }
                this.PostReplyDB.Edit(r);
            }
            return RedirectToAction("View", "Post", new { Id = HeadID });
        }

        //
        // GET: Post/togglesolution/24
        public ActionResult togglesolution(int id)
        {
            PostReply r = this.PostReplyDB.Find(id);
            if (r.CorrectAnswer)
            {
                r.CorrectAnswer = false;
            }
            else
            {
                Post p = this.PostDB.Find(r.Head.Id);
                if (0 < p.Replies.Count(reply => reply.CorrectAnswer == true))
                {
                    // Error, we have already a solution.
                    return RedirectToAction("Index", "Post");
                }
                r.CorrectAnswer = true;
            }
            this.PostReplyDB.Edit(r);
            return RedirectToAction("View", "Post", new { Id = r.Head.Id });
        }

    }
}
