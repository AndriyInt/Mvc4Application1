namespace Andriy.Mvc4Application1.Controllers
{
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using System.Web.Mvc;

    using Andriy.Mvc4Application1.Models;

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
            var fullPath = this.Server.MapPath(string.Format("{0}{1}/", LogDir, path));
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

        /// <summary>
        /// Downloads file
        /// </summary>
        /// <param name="relFname">relative to LogDir directory</param>
        [Authorize(Roles = "Admin, Super User")]
        public void DownloadFile(string relFname)
        {
            ////this.Response.WriteFile(Server.MapPath("~/Logs/2013.09.07.log.resources"));

            var fullFilePath = this.Server.MapPath(string.Format("{0}/{1}", LogDir, relFname));
            var file = new System.IO.FileInfo(fullFilePath);
            
            this.Response.Clear();
            this.Response.ClearHeaders();
            this.Response.ClearContent();
            this.Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
            this.Response.AddHeader("Content-Length", file.Length.ToString(CultureInfo.InvariantCulture));
            this.Response.ContentType = "text/plain";

            this.Response.Flush();

            this.Response.TransmitFile(file.FullName);

            this.Response.End();
        }
    }
}
