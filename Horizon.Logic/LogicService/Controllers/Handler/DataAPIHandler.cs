using LogicService.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace LogicService.Controllers.Handler
{
  public class DataAPIHandler
  {
    private WebRequestHandler _handler;
    private HttpClient _client;
    private static DataAPIHandler _instance;

    private DataAPIHandler()
    {
      _handler = new WebRequestHandler();
      _handler.CookieContainer = new System.Net.CookieContainer();
      _handler.UseCookies = true;
      _handler.UseDefaultCredentials = true;

      _client = new HttpClient(_handler);
      _client.BaseAddress = new Uri(ConfigurationManager.AppSettings["DataUri"]);
    }

    public static DataAPIHandler Instance 
    {
      get
      {
        if (_instance == null) _instance = new DataAPIHandler();
        return _instance;
      }
    }

    public bool Login()
    {
      var res = PostResponse<UserProfile>("Account/", new UserProfile()
      {
        Username = ConfigurationManager.AppSettings["DataUser"],
        Password = ConfigurationManager.AppSettings["DataPass"]
      });
      return res.IsSuccessStatusCode;
    }

    public bool Logout()
    {
      var res = DeleteResponse("Account/");
      return res.IsSuccessStatusCode;
    }

    public HttpResponseMessage GetResponse(string controllerString)
    {
      return _client.GetAsync(controllerString).GetAwaiter().GetResult();
    }

    public HttpResponseMessage PostResponse<T>(string controllerString, T obj)
    {
      return _client.PostAsJsonAsync<T>(controllerString, obj).GetAwaiter().GetResult();
    }

    public HttpResponseMessage DeleteResponse(string controllerString)
    {
      return _client.DeleteAsync(controllerString).GetAwaiter().GetResult();
    } 


  }
}