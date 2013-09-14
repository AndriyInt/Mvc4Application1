namespace Andriy.Mvc4Application1
{
    using System;
    using System.Web.Http;
    using System.Web.Mvc;
    using System.Web.Optimization;
    using System.Web.Routing;

    using Andriy.Mvc4Application1.App_Start;

    using log4net;

    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(MvcApplication));

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            AuthConfig.RegisterAuth();

            // Role init in Application_Start
            try
            {
                new Filters.InitializeSimpleMembershipAttribute().OnActionExecuting(null);
            }
            catch (Exception ex)
            {
                Logger.Error("Role init in Application_Start", ex);
            }
            
        }

        /// <summary>
        /// Handles the Error event of the Application control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        protected void Application_Error(object sender, EventArgs e)
        {
            if (this.Server != null)
            {
                var ex = this.Server.GetLastError();

                if (this.Response.StatusCode != 404)
                {
                    Logger.Error("Caught in Global.asax", ex);
                }
            }
        }
    }
}