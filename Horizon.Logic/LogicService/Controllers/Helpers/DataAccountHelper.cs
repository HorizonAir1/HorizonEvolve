using LogicService.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace LogicService.Controllers.Helpers
{
  public class DataAccountHelper
  {
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
  }
}