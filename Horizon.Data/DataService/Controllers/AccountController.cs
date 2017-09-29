using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DataService.Controllers
{
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
        var id = new ClaimsIdentity(claims, "ApplicationCookie");
        _UserStore.Add(ConfigurationManager.AppSettings["user"], id);
      }
    }

    // GET: api/Account
    public HttpResponseMessage Get()
    {
      return Request.CreateResponse<string>(HttpStatusCode.Forbidden, "No access");
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


      return Request.CreateResponse<string>(HttpStatusCode.Forbidden, "No access");
    }

  }
}
