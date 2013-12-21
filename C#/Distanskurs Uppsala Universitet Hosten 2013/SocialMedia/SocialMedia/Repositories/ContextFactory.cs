using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SocialMedia.Models;

namespace SocialMedia.Repositories
{
    /// <summary>
    /// This class is a wrapper class that handles the lifetime of the context.
    /// </summary>
    public class ContextFactory
    {
        /// <summary>
        /// Retrive the current context instance, for each 
        /// request a new instance of the context is created.
        /// </summary>
        public static SocialMediaContext GetContext()
        {
            var context = HttpContext.Current.Items["_Context"] as SocialMediaContext;

            return context;
        }
    }
}