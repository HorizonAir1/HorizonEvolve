using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using DataService.Models;
using System.Configuration;

namespace DataService
{
  // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.

  public class ApplicationUserManager : UserManager<ApplicationUser>
  {


    public ApplicationUserManager() : base(new ApplicationUserStore<ApplicationUser>())
    {
     
    }

    public override Task<ApplicationUser> FindAsync(string username, string password)
    {
      var taskInvoke = Task<ApplicationUser>.Factory.StartNew(() =>
      {
        if (ConfigurationManager.AppSettings[username]==password)
        {
          return new ApplicationUser { Id = "Data", UserName = "SuccessLogin" };
        }
        return null;
      });

      return taskInvoke;
    }

    public class ApplicationUserStore<T> : IUserStore<T> where T : ApplicationUser
    {
      public Task CreateAsync(T user)
      {
        throw new System.NotImplementedException();
      }

      public Task DeleteAsync(T user)
      {
        throw new System.NotImplementedException();
      }

      public void Dispose()
      {
        throw new System.NotImplementedException();
      }

      public Task<T> FindByIdAsync(string userId)
      {
        throw new System.NotImplementedException();
      }

      public Task<T> FindByNameAsync(string userName)
      {
        throw new System.NotImplementedException();
      }

      public Task UpdateAsync(T user)
      {
        throw new System.NotImplementedException();
      }
    }


    //public ApplicationUserManager(IUserStore<ApplicationUser> store)
    //    : base(store)
    //{
    //}

    //public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
    //{
    //  var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
    //  // Configure validation logic for usernames
    //  manager.UserValidator = new UserValidator<ApplicationUser>(manager)
    //  {
    //    AllowOnlyAlphanumericUserNames = false,
    //    RequireUniqueEmail = true
    //  };
    //  // Configure validation logic for passwords
    //  manager.PasswordValidator = new PasswordValidator
    //  {
    //    RequiredLength = 6,
    //    RequireNonLetterOrDigit = true,
    //    RequireDigit = true,
    //    RequireLowercase = true,
    //    RequireUppercase = true,
    //  };
    //  var dataProtectionProvider = options.DataProtectionProvider;
    //  if (dataProtectionProvider != null)
    //  {
    //    manager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
    //  }
    //  return manager;
    //}
  }
}
