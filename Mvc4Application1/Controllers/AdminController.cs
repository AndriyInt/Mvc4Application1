namespace Andriy.Mvc4Application1.Controllers
{
    using System.Globalization;
    using System.Linq;
    using System.Reflection;
    using System.Web.Mvc;

    using Andriy.Mvc4Application1.Models;

    public class AdminController : Controller
    {
        ////[Authorize(Roles = "Admin, Super User")]
        [Authorize(Roles = Consts.AdminRoleName)]
        public ActionResult Index()
        {
            var informationalVersionAttribute =
                (AssemblyInformationalVersionAttribute)
                Assembly.GetExecutingAssembly().GetCustomAttribute(typeof(AssemblyInformationalVersionAttribute));
            this.ViewBag.Version = informationalVersionAttribute.InformationalVersion;
            return this.View();
        }

        [Authorize(Roles = Consts.AdminRoleName)]
        public ActionResult ShowLogs(string path)
        {
            ////path = "elmah";
            var fullPath = this.Server.MapPath(string.Format("{0}/{1}/", Consts.LogDir, path));
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
                                     Root = Consts.LogDir,
                                     Path = path,
                                     FriendlyPath = path != null ? path + "/" : string.Empty,
                                     ParentDirPath = parentDirPath,
                                     Subirectories = subdirs,
                                     Files = files,
                                     VirtualPath = string.Format(
                                         "{0}{1}{2}", 
                                         Consts.LogDir, 
                                         path != null ? "/" : string.Empty, 
                                         path)
                                 });
        }

        [Authorize(Roles = Consts.AdminRoleName)]
        public ActionResult ShowUploads(string path)
        {
            var fullPath = this.Server.MapPath(string.Format("{0}/{1}/", Consts.UploadPath, path));
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
                Root = Consts.UploadPath,
                Path = path,
                FriendlyPath = path != null ? path + "/" : string.Empty,
                ParentDirPath = parentDirPath,
                Subirectories = subdirs,
                Files = files,
                VirtualPath = string.Format(
                    "{0}{1}{2}",
                    Consts.UploadPath,
                    path != null ? "/" : string.Empty,
                    path)
            });
        }

        /// <summary>
        /// Downloads file
        /// </summary>
        /// <param name="virtualFilePath">Virtual path</param>
        [Authorize(Roles = Consts.AdminRoleName)]
        public void DownloadFile(string virtualFilePath)
        {
            ////this.Response.WriteFile(Server.MapPath("~/Logs/2013.09.07.log.resources"));
            var fullFilePath = this.Server.MapPath(virtualFilePath);
            ////var fullFilePath = this.Server.MapPath(string.Format("{0}/{1}", LogDir, relFname));
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

        /// <summary>
        /// Show file in browser
        /// </summary>
        /// <param name="virtualFilePath">The virtual path in form ~/Folder/file.ext</param>
        [Authorize(Roles = Consts.AdminRoleName)]
        public void ShowFile(string virtualFilePath)
        {
            ////this.Response.WriteFile(Server.MapPath("~/Logs/2013.09.07.log.resources"));
            string fullFilePath = this.Server.MapPath(virtualFilePath);
            var file = new System.IO.FileInfo(fullFilePath);
            string extension = file.Extension.Substring(1);
            
            if (Consts.ImageExtensions.Contains(extension))
            {
                this.Response.ContentType = "image/" + extension;
            }
            else if (Consts.PlainTextExtensions.Contains(extension))
            {
                this.Response.ContentType = "text/plain";
            }
            else
            {
                this.RedirectToAction("DownloadFile");
                return;
            }

            this.Response.TransmitFile(file.FullName);
            this.Response.End();
        }
    }
}
