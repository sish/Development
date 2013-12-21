using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialMedia.ViewModels
{

    public class MenuItem
    {
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="text">String with the text to show.</param>
        /// <param name="controller">String with the controller to call.</param>
        /// <param name="page">String with the action to call.</param>
        /// <param name="currentpage">bool if this is the current page or not, default false.</param>
        public MenuItem(string text, string controller, string page, bool currentpage = false)
        {
            Text = text;
            Controller = controller;
            Page = page;
            CurrentPage = currentpage;
        }

        /// <summary>
        /// Property with the text to show.
        /// </summary>
        public string Text { get; set; }
        /// <summary>
        /// Property with the controller to call.
        /// </summary>
        public string Controller { get; set; }
        /// <summary>
        /// Property with the action to call.
        /// </summary>
        public string Page { get; set; }
        /// <summary>
        /// Property if this is the currently showed page or not.
        /// </summary>
        public bool CurrentPage { get; set; }
    }

    public class SubMenuModel
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public SubMenuModel()
        {
            Items = new List<MenuItem>();
        }

        /// <summary>
        /// List with the MenuItems to show.
        /// </summary>
        public List<MenuItem> Items { get; set; }
    }
}