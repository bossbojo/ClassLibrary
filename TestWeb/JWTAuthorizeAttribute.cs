using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using TestWeb.Authen;
namespace TestWeb
{
    public class JWTAuthorizeAttribute : AuthorizeAttribute
    {
        //authen
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            string token = HttpContext.Current.Request.Headers["Authorization"];
            if (token != null)
            {
                var decode = AuthTest.Auth.GetAuthenticated(token);
                if (decode != null)
                {
                    AuthTest.Auth.SetAuthenticated(decode.User);
                    return;
                }
              //throw new System.Security.Authentication.AuthenticationException("Can not access this page.");
            }
            base.OnAuthorization(actionContext); 
        }
    }
}