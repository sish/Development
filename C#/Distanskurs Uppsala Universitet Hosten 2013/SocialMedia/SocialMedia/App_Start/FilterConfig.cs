using System.Web;
using System.Web.Mvc;

namespace SocialMedia
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            // Adds Authorize to all controllers and 
            // actions except whitelisted by AllowAnonymous
            //filters.Add(new System.Web.Mvc.AuthorizeAttribute());
        }
    }
}