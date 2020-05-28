using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WeatherForecast.Data.Services;

namespace WeatherForecast
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
    public class CustomAuthorizeAttribute : AuthorizeAttribute
    {
        private readonly string[] _allowedroles;
        private IUserData _userData; //in a real application this will just be the datacontext 

        public CustomAuthorizeAttribute(params string[] roles)
        {
            _allowedroles = roles;
        }

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            bool authorize = false;

            _userData = new InMemoryUserData(); //in a real application this will just be the datacontext 
            var userRole = _userData.GetUserRoleByUserId(Convert.ToInt32(httpContext.Session["UserId"]));
            if(userRole != null)
            {
                foreach (var role in _allowedroles)
                {
                    if (userRole.Name == role)
                    {
                        authorize = true;
                    }
                }
            }
            return authorize;
        }

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            var dic = new ViewDataDictionary();
            dic.Add("Message", "You don't have sufficient privileges for this operation!");
            filterContext.Result = new ViewResult() { ViewName = "AuthorizeFailed", ViewData = dic };
        }
    }
}