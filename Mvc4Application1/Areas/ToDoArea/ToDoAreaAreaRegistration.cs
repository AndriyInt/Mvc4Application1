namespace Andriy.Mvc4Application1.Areas.ToDoArea
{
    using System.Web.Http;
    using System.Web.Mvc;

    public class ToDoAreaAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ToDoArea";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            WebApiConfig.Register(GlobalConfiguration.Configuration);

            context.MapRoute(
                "ToDoArea_default",
                "ToDoArea/{controller}/{action}/{id}",
                new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                new[] { "Andriy.Mvc4Application1.Areas.ToDoArea.Controllers" });
        }
    }
}
