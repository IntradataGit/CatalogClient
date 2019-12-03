using IntraOffice.Nuget.Catalog.Client.Configuration;
using IntraOffice.Nuget.Catalog.Client.IntTests.Data;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions
{
   public static class GetClientSettingsExtension
   {
      public static CatalogClientSettings GetClientSettings(this TestBase test)
      {
         return new CatalogClientSettings
         {
            ApiUrl = Constants.ApiRootUrl,
            AuthToken = Constants.ApiToken,
            TenantId = Constants.TenantId
         };
      }
   }
}