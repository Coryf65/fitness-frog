[assembly: WebActivator.PostApplicationStartMethod(typeof(Treehouse.FitnessFrog.App_Start.SimpleInjectorInitializer), "Initialize")]

namespace Treehouse.FitnessFrog.App_Start
{

    using System.Reflection;
    using System.Web;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Microsoft.Owin;
    using SimpleInjector;
    using SimpleInjector.Integration.Web;
    using SimpleInjector.Integration.Web.Mvc;
    using Treehouse.FitnessFrog.Data;
    using Treehouse.FitnessFrog.Models;
    using Treehouse.FitnessFrog.Security;

    public static class SimpleInjectorInitializer
    {
        /// <summary>Initialize the container and register it as MVC3 Dependency Resolver.</summary>
        public static void Initialize()
        {
            var container = new Container();
            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            InitializeContainer(container);

            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }

        //The Lifestyle enumeration value that we pass to the Register generic method 
        //tells the container how many instances of a type should be created and how long each 
        //of those instances should live. With the "Scoped" lifetime, for every request within 
        //an implicitly or explicitly defined scope, a single instance will be returned and that 
        //instance will be disposed when the scope ends.
        private static void InitializeContainer(Container container)
        {
            container.Register<Context>(Lifestyle.Scoped);
            container.Register<EntriesRepository>(Lifestyle.Scoped);
            container.Register<ActivitiesRepository>(Lifestyle.Scoped);

            container.Register<ApplicationUserManager>(Lifestyle.Scoped);
            container.Register<ApplicationSignInManager>(Lifestyle.Scoped);
            container.Register(() =>
                container.IsVerifying
                    ? new OwinContext().Authentication
                    : HttpContext.Current.GetOwinContext().Authentication,
                Lifestyle.Scoped);
            container.Register<IUserStore<User>>(() =>
                new UserStore<User>(container.GetInstance<Context>()),
                Lifestyle.Scoped);
        }
    }


}