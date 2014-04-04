using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Andriy.Mvc4Application1.Models.DTO
{
    public class AciTreeNode
    {
        public int id { get; set; }
        public int label { get; set; }
        public bool inode { get; set; }
        public bool checkbox { get; set; }
        public bool radio { get; set; }
        public IEnumerable<AciTreeNode> branch { get; set; }
    }
}