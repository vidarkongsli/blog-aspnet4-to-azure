using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Dapper;
using Kongsli.LegacyNetFramework.Web.Dapper;
using Kongsli.LegacyNetFramework.Web.DependencyInjection;
using StructureMap;
using WebApi.StructureMap;

namespace Kongsli.LegacyNetFramework.Web
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            SqlMapper.AddTypeHandler(new DapperUriTypeHandler());

            var container = new Container(x => x.AddRegistry<DependencyInjectionRegistry>());
            var controllerFactory = new StructureMapControllerFactory(container);
            ControllerBuilder.Current.SetControllerFactory(controllerFactory);
            GlobalConfiguration.Configuration.UseStructureMap(container);

            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}
