using KareAjans.BLL.Models;
using KareAjans.WebUI.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Script.Serialization;
using System.Web.Security;

namespace KareAjans.WebUI
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
        {
            HttpCookie authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];

            if (authCookie != null)
            {
                FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);

                JavaScriptSerializer serializer = new JavaScriptSerializer();

                CustomPrincipalSerializeModel serializeModel = serializer.Deserialize<CustomPrincipalSerializeModel>(authTicket.UserData);

                if (authTicket != null && !authTicket.Expired)
                {
                    var roles = serializeModel.UserRole.Split(',');
                    CustomPrincipal newUser = new CustomPrincipal(new FormsIdentity(authTicket), roles);
                    newUser.Id = serializeModel.Id;
                    newUser.FirstName = serializeModel.FirstName;
                    newUser.LastName = serializeModel.LastName;
                    newUser.UserRole = serializeModel.UserRole;

                    HttpContext.Current.User = newUser;
                }
            }

            //protected void Application_PostAuthenticateRequest(Object sender, EventArgs e)
            //{
            //    var authCookie = HttpContext.Current.Request.Cookies[FormsAuthentication.FormsCookieName];
            //    if (authCookie != null)
            //    {
            //        FormsAuthenticationTicket authTicket = FormsAuthentication.Decrypt(authCookie.Value);
            //if (authTicket != null && !authTicket.Expired)
            //{
            //    var roles = authTicket.UserData.Split(',');
            //    var principal = new System.Security.Principal.GenericPrincipal(new FormsIdentity(authTicket), roles);

            //            principal.

            //            HttpContext.Current.User = principal;
            //        }
            //    }
            //}

        }
    }
}