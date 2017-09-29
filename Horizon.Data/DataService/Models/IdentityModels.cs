using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace DataService.Models
{
  public class ApplicationUser : IUser
  {
    public string Id { get; set; }

    public string UserName { get; set; }

  }
}