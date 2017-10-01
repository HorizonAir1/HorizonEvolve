using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataService
{
  public class Startup
  {
    public void Configuration(IAppBuilder app)
    {
      var opt = new CookieAuthenticationOptions()
      {
        AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
        CookieHttpOnly = false,
        CookieName = "Data-token",
        LoginPath = new PathString("/DataService/Account")
      };

      app.UseCookieAuthentication(opt);
    }
  }
}