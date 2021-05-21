using Ninject.Modules;
using ToDoLayer.BLL.Infrastructure;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Ninject;
using Ninject.Web.Mvc;
using ToDoLayer.Util;

namespace ToDoLayer
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // внедрение зависимостей
            NinjectModule userModule = new UserModule();
            NinjectModule serviceModule = new ServiceModule("Data Source=(localdb)\\mssqllocaldb; Database=TODOapp; Persist Security Info=false; MultipleActiveResultSets=True; Trusted_Connection=False;");  //   Data Source=(localdb)\\mssqllocaldb; Database=TODOapp; Persist Security Info=false; MultipleActiveResultSets=True; Trusted_Connection=False;
            var kernel = new StandardKernel(userModule, serviceModule);
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
        }
    }
}
