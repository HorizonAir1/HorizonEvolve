using LogicService.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace LogicService.Controllers.Helpers
{
  public class DataAPIHandler
  {
    private WebRequestHandler _handler;

    private static DataAccountHelper _instance;

    private DataAccountHelper()
    {
      _handler
    }


    public static bool Login()
    {
      var client = new HttpClient();
      var res = client.PostAsJsonAsync<UserProfile>(ConfigurationManager.AppSettings["DataUri"] + "Account/", new UserProfile()
      {
        Username = ConfigurationManager.AppSettings["DataUser"],
        Password = ConfigurationManager.AppSettings["DataPass"]
      }).GetAwaiter().GetResult();

      return res.IsSuccessStatusCode;
    }

    public static bool Logout()
    {
      var client = new HttpClient();
      var res = client.DeleteAsync(ConfigurationManager.AppSettings["DataUri"] + "Account/").GetAwaiter().GetResult();

      return res.IsSuccessStatusCode;
    }

    public static HttpResponseMessage GetResponse(string controllerString)
    {
      WebRequestHandler handler = new WebRequestHandler();
      handler.CookieContainer = new System.Net.CookieContainer();
      handler.UseCookies = true;
      handler.UseDefaultCredentials = true;

      HttpClient client = new HttpClient(handler);
      client.BaseAddress = new Uri(ConfigurationManager.AppSettings["DataUri"]);
      return response = client.GetAsync(controllerString).Result;
    }
    
  }
}