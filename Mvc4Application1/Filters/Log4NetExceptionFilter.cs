namespace Mvc4Application1.Filters
{
    using System;
    using System.Web;
    using System.Web.Mvc;

    using log4net;

    public class Log4NetExceptionFilter : IExceptionFilter
    {
        private static readonly ILog Logger = LogManager.GetLogger(typeof(Log4NetExceptionFilter));

        public void OnException(ExceptionContext context)
        {
            Exception ex = context.Exception;

            // ignore "file not found"
            if (!(ex is HttpException)) 
            {
                Logger.Error("Caught in Log4NetExceptionFilter", ex);
            }
        }
    }
}