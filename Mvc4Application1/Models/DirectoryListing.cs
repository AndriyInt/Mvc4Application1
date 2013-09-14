namespace Andriy.Mvc4Application1.Models
{
    using System.Collections.Generic;

    public class DirectoryListing
    {
        public string Path { get; set; }

        public string FriendlyPath { get; set; }

        public string ParentDirPath { get; set; }

        public IEnumerable<string> Subirectories { get; set; }

        public IEnumerable<string> Files { get; set; }
    }
}