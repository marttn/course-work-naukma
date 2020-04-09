using System.Web.Mvc;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;

namespace coursework.App_Start
{
    public class DependencyConfig
    {
        public static void Register()
        {
            InitializeSimpleInjector();
        }

        private static void InitializeSimpleInjector()
        {
            var container = new Container();

            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            ServiceResolver.Configure(container, Lifestyle.Scoped);
            container.RegisterMvcControllers();
            container.RegisterMvcIntegratedFilterProvider();
            container.Verify();
            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }
    }
}