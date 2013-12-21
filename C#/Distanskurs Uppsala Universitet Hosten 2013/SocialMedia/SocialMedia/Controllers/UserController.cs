using SocialMedia.Repositories;
using SocialMedia.ViewModels;
using SocialMedia.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace SocialMedia.Controllers
{
    public class UserController : Controller
    {

        private PostRepository PostDB;
        private UserRepository UserDB;
        private TagRepository TagDB;

        public UserController()
        {
            this.PostDB = RepositoryFactory.GetPostRepository();
            this.UserDB = RepositoryFactory.GetUserRepository();
            this.TagDB = RepositoryFactory.GetTagRepository();
        }

        //
        // GET: /User/
        public ActionResult Index(int page = 0)
        {
            UsersModel model = new UsersModel(User.Identity.IsAuthenticated);
            var All = this.UserDB.All()
                .Select(user => new UserOverView(user, this.UserDB.GetByUserName(User.Identity.Name)));
            model.Users.AddRange(All.Skip((page) * Paging.ConstPageSize).Take(Paging.ConstPageSize));
            model.Pages = new Paging(All.Count(), page);
            return View(model);
        }

        //
        // Post: /User/
        [HttpPost]
        [Authorize]
        public ActionResult Index(int[] users, int[] following, int redirect = 0)
        {
            User loggedIn = this.UserDB.GetByUserName(User.Identity.Name);
            var RemoveFrom = this.UserDB.All()
                .Where(user => true == users.Contains(user.Id))
                .Where(user => true == user.Followers.Contains(loggedIn))
                .Where(user => true != following.Contains(user.Id))
                .ToList();
            foreach (User u in RemoveFrom)
            {
                u.Followers.Remove(loggedIn);
                this.UserDB.Edit(u);
            }
            var SubscribeTo = this.UserDB.All()
                .Where(user => true == users.Contains(user.Id))
                .Where(user => true != user.Followers.Contains(loggedIn))
                .Where(user => true == following.Contains(user.Id))
                .ToList();
            foreach (User u in SubscribeTo)
            {
                u.Followers.Add(loggedIn);
                this.UserDB.Edit(u);
            }
            return RedirectToAction("Index", "User", new { page = redirect });
        }

        //
        // GET: /User/Stream
        public ActionResult Stream(string type, string search = null)
        {
            if (true != User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                var controller = new SubMenuModel();
                controller.Items.Add(new MenuItem("Stream", "User", "Stream", true));
                controller.Items.Add(new MenuItem("Members Followed", "User", "StreamUsers"));
                controller.Items.Add(new MenuItem("Tags Followed", "User", "StreamTags"));
                controller.Items.Add(new MenuItem("My Posts", "User", "StreamOwn"));
                PostOverview model = new PostOverview();
                model.SubMenu = controller;
                User user = this.UserDB.GetByUserName(User.Identity.Name);
                var Posts = this.PostDB.All()
                    .Where(post => post.Author.Id == user.Id ||
                                   post.Author.Followers.Contains(user) ||
                                   post.Tags
                                        .Where(tag => tag.Followers.Contains(user))
                                        .FirstOrDefault() != null)
                    .Distinct();
                if (null == search)
                {
                    model.Posts.AddRange(Posts
                        .OrderByDescending(post => post.TimeOfPost)
                        .Select(post => new PostLight(post)));
                }
                else // Add filtering
                { 
                    model.Posts.AddRange(Posts
                        .Where(post => "title" == type && post.Title.ToLower().Contains(search.ToLower()) ||
                                       "user" == type && post.Author.Username.ToLower().Contains(search.ToLower()) ||
                                       "text" == type && post.Text.ToLower().Contains(search.ToLower()))
                        .OrderByDescending(post => post.TimeOfPost)
                        .Select(post => new PostLight(post)));

                }
                return View(model);
            }
        }

        //
        // GET: /User/StreamUsers
        public ActionResult StreamUsers(string type, string search = null)
        {
            if (true != User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                var controller = new SubMenuModel();
                controller.Items.Add(new MenuItem("Stream", "User", "Stream"));
                controller.Items.Add(new MenuItem("Members Followed", "User", "StreamUsers", true));
                controller.Items.Add(new MenuItem("Tags Followed", "User", "StreamTags"));
                controller.Items.Add(new MenuItem("My Posts", "User", "StreamOwn"));
                PostOverview model = new PostOverview();
                model.SubMenu = controller;
                User user = this.UserDB.GetByUserName(User.Identity.Name);
                var Posts = this.PostDB.All()
                    .Where(post => post.Author.Followers.Contains(user))
                    .Distinct();
                if (null == search)
                {
                    model.Posts.AddRange(Posts
                        .OrderByDescending(post => post.TimeOfPost)
                        .Select(post => new PostLight(post)));
                }
                else // Add filtering
                {
                    model.Posts.AddRange(Posts
                        .Where(post => "title" == type && post.Title.ToLower().Contains(search.ToLower()) ||
                                       "user" == type && post.Author.Username.ToLower().Contains(search.ToLower()) ||
                                       "text" == type && post.Text.ToLower().Contains(search.ToLower()))
                        .OrderByDescending(post => post.TimeOfPost)
                        .Select(post => new PostLight(post)));

                }
                return View(model);
            }
        }

        //
        // GET: /User/StreamTags
        public ActionResult StreamTags(string type, string search = null)
        {
            if (true != User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                var controller = new SubMenuModel();
                controller.Items.Add(new MenuItem("Stream", "User", "Stream"));
                controller.Items.Add(new MenuItem("Members Followed", "User", "StreamUsers"));
                controller.Items.Add(new MenuItem("Tags Followed", "User", "StreamTags", true));
                controller.Items.Add(new MenuItem("My Posts", "User", "StreamOwn"));
                PostOverview model = new PostOverview();
                model.SubMenu = controller;
                User user = this.UserDB.GetByUserName(User.Identity.Name);
                var Posts = this.PostDB.All()
                    .Where(post => post.Tags
                        .Where(tag => tag.Followers.Contains(user))
                        .FirstOrDefault() != null)
                    .Distinct();
                if (null == search)
                {
                    model.Posts.AddRange(Posts
                        .OrderByDescending(post => post.TimeOfPost)
                        .Select(post => new PostLight(post)));
                }
                else // Add filtering
                {
                    model.Posts.AddRange(Posts
                        .Where(post => "title" == type && post.Title.ToLower().Contains(search.ToLower()) ||
                                       "user" == type && post.Author.Username.ToLower().Contains(search.ToLower()) ||
                                       "text" == type && post.Text.ToLower().Contains(search.ToLower()))
                        .OrderByDescending(post => post.TimeOfPost)
                        .Select(post => new PostLight(post)));

                }
                return View(model);
            }
        }

        //
        // GET: /User/StreamOwn
        public ActionResult StreamOwn(string type, string search = null)
        {
            if (true != User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Login", "Account");
            }
            else
            {
                var controller = new SubMenuModel();
                controller.Items.Add(new MenuItem("Stream", "User", "Stream"));
                controller.Items.Add(new MenuItem("Members Followed", "User", "StreamUsers"));
                controller.Items.Add(new MenuItem("Tags Followed", "User", "StreamTags"));
                controller.Items.Add(new MenuItem("My Posts", "User", "StreamOwn", true));
                PostOverview model = new PostOverview();
                model.SubMenu = controller;
                User user = this.UserDB.GetByUserName(User.Identity.Name);
                var Posts = this.PostDB.All()
                    .Where(post => post.Author.Id == user.Id)
                    .Distinct();
                if (null == search)
                {
                    model.Posts.AddRange(Posts
                        .OrderByDescending(post => post.TimeOfPost)
                        .Select(post => new PostLight(post)));
                }
                else // Add filtering
                {
                    model.Posts.AddRange(Posts
                        .Where(post => "title" == type && post.Title.ToLower().Contains(search.ToLower()) ||
                                       "user" == type && post.Author.Username.ToLower().Contains(search.ToLower()) ||
                                       "text" == type && post.Text.ToLower().Contains(search.ToLower()))
                        .OrderByDescending(post => post.TimeOfPost)
                        .Select(post => new PostLight(post)));

                }
                return View(model);
            }
        }

        //
        // GET: User/ToggleFollowTag/3
        [Authorize]
        public ActionResult ToggleFollowTag(int id)
        {
            User user = this.UserDB.GetByUserName(User.Identity.Name);
            Tag tag = this.TagDB.Find(id);
            if (null != user && null != tag)
            {
                if (tag.Followers.Contains(user))
                {
                    tag.Followers.Remove(user);
                }
                else
                {
                    tag.Followers.Add(user);
                }
                this.TagDB.Edit(tag);
            }
            return RedirectToAction("ByTag", "Post", new { Id = id });
        }

        //
        // GET: User/ToggleFollowUser/3
        [Authorize]
        public ActionResult ToggleFollowUser(int id)
        {
            User user = this.UserDB.GetByUserName(User.Identity.Name);
            User toFollow = this.UserDB.Find(id);
            if (null != user && null != toFollow)
            {
                if (toFollow.Followers.Contains(user))
                {
                    toFollow.Followers.Remove(user);
                }
                else
                {
                    toFollow.Followers.Add(user);
                }
                this.UserDB.Edit(toFollow);
            }
            return RedirectToAction("ByAuthor", "Post", new { Id = id });
        }

    }
}
