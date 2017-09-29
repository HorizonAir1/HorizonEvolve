using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace LogicService.Controllers
{
  public class AccountController : ApiController
  {
    private static Dictionary<string, ClaimsPrincipal> _UserStore = new Dictionary<string, ClaimsPrincipal>();

    public AccountController() : base()
    {
      if (_UserStore[ConfigurationManager.AppSettings["user"]] == null)
      {
        var claims = new List<Claim>()
        {
          new Claim(ClaimTypes.Role, "Logic", ClaimValueTypes.String),
          new Claim("username", ConfigurationManager.AppSettings["user"]),
          new Claim("password", ConfigurationManager.AppSettings["pass"])
        };
        var id = new ClaimsIdentity(claims);
        var user = new ClaimsPrincipal(id);
        _UserStore.Add(ConfigurationManager.AppSettings["user"], user);
      }
    }
      
    // GET: api/Account
    public IEnumerable<string> Get()
    {
      return new string[] { "value1", "value2" };
    }

    //// GET: api/Account/5
    //public string Get(int id)
    //{
    //  return "value";
    //}

    // POST: api/Account
    public void Post([FromBody]string value)
    {
    }

    //// PUT: api/Account/5
    //public void Put(int id, [FromBody]string value)
    //{
    //}

    //// DELETE: api/Account/5
    //public void Delete(int id)
    //{
    //}
  }
}
