using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Artist.DAO.IoCRegistry;

namespace Artist.UI
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : HttpApplication
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default Stuff", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new {controller = "Customer", action = "Index", id = UrlParameter.Optional} // Parameter defaults
                );
            routes.MapRoute(
                "Create Customer", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new {controller = "Customer", action = "Create", id = UrlParameter.Optional} // Parameter defaults
                );
            routes.MapRoute(
                "NextCustomerSet",
                "Customer/Page/{page}",
                new {controller = "Customer", action = "Index"}
                );

            routes.MapRoute(
                "PreviousCustomerSet",
                "Customer/Page/{page}",
                new {controller = "Customer", action = "Index"}
                );
        }

        protected void Application_Start()
        {
            ControllerBuilder.Current.SetControllerFactory(new StructureMapUtil.StructureMapController());
            AreaRegistration.RegisterAllAreas();

            RegisterRoutes(RouteTable.Routes);

            new RegisterProject();
        }
    }
}