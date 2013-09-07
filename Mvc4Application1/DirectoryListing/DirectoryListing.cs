using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mvc4Application1.DirectoryListing
{
    public class DirectoryListing
    {
        public string Path { get; set; }

        public string ParentDirPath { get; set; }

        public IEnumerable<string> Subirectories { get; set; }

        public IEnumerable<string> Files { get; set; }
    }
}