using DataService.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace DataService.Controllers
{
  [AllowAnonymous]
  public class AccountController : ApiController
  {
    private static Dictionary<string, ClaimsIdentity> _UserStore = new Dictionary<string, ClaimsIdentity>();

    public AccountController() : base()
    {
      if (!_UserStore.ContainsKey(ConfigurationManager.AppSettings["user"]))
      {
        var claims = new List<Claim>()
        {
          new Claim(ClaimTypes.Role, "Logic", ClaimValueTypes.String),
          new Claim("username", ConfigurationManager.AppSettings["user"]),
          new Claim("password", ConfigurationManager.AppSettings["pass"])
        };
        var id = new ClaimsIdentity(claims, DefaultAuthenticationTypes.ApplicationCookie);
        _UserStore.Add(ConfigurationManager.AppSettings["user"], id);
      }
    }

    // GET: api/Account
    public HttpResponseMessage Get()
    {
      var user = Request.GetOwinContext().Authentication.User;
      if (user.HasClaim("username", ConfigurationManager.AppSettings["user"]))
        return Request.CreateResponse<string>(HttpStatusCode.Accepted, "Signed In");
      return Request.CreateResponse<string>(HttpStatusCode.Accepted, "Logged Out");
    }

    //// GET: api/Account/5
    //public string Get(int id)
    //{
    //  return "value";
    //}

    // POST: api/Account
    public HttpResponseMessage Post(UserProfile p)
    {
      if (ModelState.IsValid && _UserStore.ContainsKey(p.Username))
      {
        var auth = Request.GetOwinContext().Authentication;
        var props = new AuthenticationProperties()
        {
          IsPersistent = true,
          ExpiresUtc = DateTime.UtcNow.AddHours(1)
        };

        auth.SignIn(props, _UserStore[p.Username]);
        return Request.CreateResponse<string>(HttpStatusCode.Accepted, "Signed In");
      }


      return Request.CreateResponse<string>(HttpStatusCode.Unauthorized, "No access");
    }

    [Authorize]
    public HttpResponseMessage Delete()
    {
      var req = Request.GetOwinContext().Authentication;
      req.SignOut();
      return Request.CreateResponse<string>(HttpStatusCode.Accepted, "Logged Out");
    }

  }
}
