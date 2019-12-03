using System.Configuration;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.Data
{
   public static class Constants
   {
      /// <summary>
      /// Required Url of Catalog API
      /// </summary>
      public static string ApiRootUrl = ConfigurationManager.AppSettings["ApiUrl"];

      /// <summary>
      /// Optional token that will be sent to Catalog API
      /// </summary>
      public static string ApiToken = ConfigurationManager.AppSettings["CatalogApiToken"];

      /// <summary>
      /// Optional tenant id that will be sent to Catalog API
      /// </summary>
      public static string TenantId = ConfigurationManager.AppSettings["TenantId"];
   }
}