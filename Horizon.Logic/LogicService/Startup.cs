using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LogicService
{
  public class Startup
  {
    public void Configuration(IAppBuilder app)
    {
      var opt = new CookieAuthenticationOptions()
      {
        AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
        CookieHttpOnly = false,
        CookieName = "Logic-token",
        LoginPath = new PathString("/LogicService/Account")
      };

      app.UseCookieAuthentication(opt);
    }
  }
}