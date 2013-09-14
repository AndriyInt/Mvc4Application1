using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Andriy.Mvc4Application1.Localization
{
    public class Culture
    {
        public static readonly List<Culture> Cultures;

        static Culture()
        {
            Cultures = new List<Culture> 
            { 
                new Culture("en-US", "English (US)"),
                new Culture("en-GB", "English (GB)"),
                new Culture("uk-UA", "Ukrainian")
            };
        }

        public Culture(string key, string name)
        {
            this.Key = key;
            this.Name = name;
        }

        public string Key { get; private set; }

        public string Name { get; private set; }
    }
}