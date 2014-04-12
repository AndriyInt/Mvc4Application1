namespace Andriy.Mvc4Application1.DTOs
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    public class AciTreeNode
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("label")]
        public string Label { get; set; }

        ////[JsonProperty("icon")]
        ////public string Icon { get; set; }

        [JsonProperty("inode")]
        public bool Inode { get; set; }

        ////[JsonProperty("checkbox")]
        ////public bool Checkbox { get; set; }

        ////[JsonProperty("branch")]
        ////public IEnumerable<AciTreeNode> Branch { get; set; }
    }
}