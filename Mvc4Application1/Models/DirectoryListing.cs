namespace Andriy.Mvc4Application1.Models
{
    using System.Collections.Generic;

    public class DirectoryListing
    {
        /// <summary>
        /// Virtual path of current root. Example: ~/Logs
        /// </summary>
        public string Root { get; set; }

        public string Path { get; set; }

        public string FriendlyPath { get; set; }

        public string ParentDirPath { get; set; }

        /// <summary>
        /// Directory path without ending slash. Example: ~/Logs/subdir
        /// </summary>
        public string VirtualPath { get; set; }

        public IEnumerable<string> Subirectories { get; set; }

        public IEnumerable<string> Files { get; set; }
    }
}