using Microsoft.AspNet.Identity;
using Treehouse.FitnessFrog.Models;

namespace Treehouse.FitnessFrog.Security
{
    //Let's start with registering our ApplicationUserManager and ApplicationSignInManager types with the DI container.
    public class ApplicationUserManager : UserManager<User>
    {
        public ApplicationUserManager(IUserStore<User> userStore)
            : base(userStore)
        {
        }


    }
}