using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using AdventureMVC.Core.Helpers;
using StructureMap;

namespace AdventureMVC
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default",                                              // Route name
                "{controller}.mvc/{action}/{id}",                           // URL with parameters
                new { controller = "Home", action = "Index", id = "" }  // Parameter defaults
            );

            routes.MapRoute(
              "Root",
              "",
              new { controller = "Employee", action = "PTO", id = "" }
            );
        }
        protected void Application_Start()
        {
            RegisterRepository();
            RegisterRoutes(RouteTable.Routes);
            RegisterControllerFactory();
        }

        private static void RegisterControllerFactory()
        {
            ControllerBuilder.Current.SetControllerFactory(new StructureMapControllerFactory());
        }

        private static void RegisterRepository()
        {
            ObjectFactory.Initialize(x => x.Scan(s =>
            {
                s.Assembly(Config.GetSetting("data-assembly"));
                s.Assembly("AdventureMVC.Core");
                s.WithDefaultConventions();
            }));
        }
       
    }
}