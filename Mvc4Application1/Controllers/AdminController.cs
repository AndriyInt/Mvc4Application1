namespace Mvc4Application1.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using System.Web;
    using System.Web.Mvc;

    using Mvc4Application1.Models;

    public class AdminController : Controller
    {
        private const string LogDir = "~/Logs/";

        [Authorize(Roles = "Admin, Super User")]
        public ActionResult Index()
        {
            var informationalVersionAttribute =
                (AssemblyInformationalVersionAttribute)
                Assembly.GetExecutingAssembly().GetCustomAttribute(typeof(AssemblyInformationalVersionAttribute));
            this.ViewBag.Version = informationalVersionAttribute.InformationalVersion;
            return this.View();
        }

        [Authorize(Roles = "Admin, Super User")]
        public ActionResult ShowLogs(string path)
        {
            //path = "elmah";
            var fullPath = Server.MapPath(string.Format("{0}{1}/", LogDir, path));
            var fullPathLength = fullPath.Length;

            string parentDirPath = null;
            if (path != null)
            {
                var slashIdx = path.LastIndexOf('/');
                parentDirPath = slashIdx > -1 ? path.Substring(0, slashIdx) : string.Empty;
            }

            var subdirs = System.IO.Directory.EnumerateDirectories(fullPath).Select(fname => fname.Substring(fullPathLength));
            var files = System.IO.Directory.EnumerateFiles(fullPath).Select(fname => fname.Substring(fullPathLength));

            return this.View(new DirectoryListing
                                 {
                                     Path = path,
                                     FriendlyPath = path != null ? path + "/" : string.Empty,
                                     ParentDirPath = parentDirPath,
                                     Subirectories = subdirs,
                                     Files = files
                                 });
        }

        [Authorize(Roles = "Admin, Super User")]
        public void DownloadLog()
        {
            this.Response.WriteFile(Server.MapPath("~/Logs/2013.09.07.log.resources"));
        }
        
        /// <summary>
        /// Downloads file
        /// </summary>
        /// <param name="relFname">relative to LogDir directory</param>
        [Authorize(Roles = "Admin, Super User")]
        public void DownloadFile(string relFname)
        {
            ////this.Response.WriteFile(Server.MapPath("~/Logs/2013.09.07.log.resources"));

            var fullFilePath = Server.MapPath(string.Format("{0}/{1}", LogDir, relFname));
            var file = new System.IO.FileInfo(fullFilePath);
            
            Response.Clear();
            Response.ClearHeaders();
            Response.ClearContent();
            Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
            Response.AddHeader("Content-Length", file.Length.ToString(CultureInfo.InvariantCulture));
            Response.ContentType = "text/plain";

            Response.Flush();

            Response.TransmitFile(file.FullName);

            Response.End();
        }
    }
}
