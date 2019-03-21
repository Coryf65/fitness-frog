using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Treehouse.FitnessFrog.Models;

namespace Treehouse.FitnessFrog.Security
{
    public class ApplicationSignInManager : SignInManager<User, string>
    {
        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }
    }
}