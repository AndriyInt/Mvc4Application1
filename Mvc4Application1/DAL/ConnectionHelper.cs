namespace Mvc4Application1.DAL
{
    public class ConnectionHelper
    {
        public static readonly string SiteDBModelConnectionString;

        static ConnectionHelper()
        {
            SiteDBModelConnectionString = GetSiteDBModelConnStr("DefaultConnection");
        }

        private static string GetSiteDBModelConnStr(string sqlConnStr)
        {
            var siteSqlConn = System.Configuration.ConfigurationManager.ConnectionStrings[sqlConnStr];
            string conStrIntegratedSecurity =
                new System.Data.EntityClient.EntityConnectionStringBuilder
                {
                    Metadata = "res://*/DAL.SiteDBModel.csdl|res://*/DAL.SiteDBModel.ssdl|res://*/DAL.SiteDBModel.msl",
                    Provider = siteSqlConn.ProviderName,
                    ProviderConnectionString = siteSqlConn.ConnectionString
                }.ConnectionString;
            return conStrIntegratedSecurity;
        }
    }
}