using Microsoft.AspNet.Identity;
using Treehouse.FitnessFrog.Models;

namespace Treehouse.FitnessFrog.Security
{
    public class ApplicationUserManager : UserManager<User>
    {
        public ApplicationUserManager(IUserStore<User> userStore)
            : base(userStore)
        {
        }
    }
}