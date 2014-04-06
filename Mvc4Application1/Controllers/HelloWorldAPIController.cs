namespace Andriy.Mvc4Application1.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Helpers;
    using System.Web.Http;

    public class HelloWorldAPIController : ApiController
    {
        [Route("api/HelloWorldAPI/GetTreeNodesCheckbox")]
        public object GetTreeNodesCheckbox()
        {
            string jsonFilePath = System.Web.Hosting.HostingEnvironment.MapPath("~/Content/aciTree/checkbox.json");

            if (jsonFilePath == null || !File.Exists(jsonFilePath))
            {
                throw new FileNotFoundException("json file not found", jsonFilePath);
            }
            
            string jsonFileContents = File.ReadAllText(jsonFilePath);
            object jsonObject = Newtonsoft.Json.JsonConvert.DeserializeObject(jsonFileContents);
            return jsonObject;
        }

        [Route("api/HelloWorldAPI/GetTheObject")]
        public dynamic GetTheObject()
        {
            return new[] { new { id = 1 } };
        }
    }
}
