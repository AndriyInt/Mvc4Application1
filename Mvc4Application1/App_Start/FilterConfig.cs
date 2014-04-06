namespace Andriy.Mvc4Application1
{
    using System.Web.Mvc;

    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new Filters.Log4NetExceptionFilter());
        }
    }
}