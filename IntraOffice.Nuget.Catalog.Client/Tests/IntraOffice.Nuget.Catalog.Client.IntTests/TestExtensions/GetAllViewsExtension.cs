using System.Collections.Generic;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Models.Domain.Configuration;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions
{
   public static class GetAllViewsExtension
   {
      public static IEnumerable<SchemaViewVm> GetAllViews(this TestBase test)
      {
         return test.GetInstance<ICatalogClient4Views>().GetAllViews().GetAwaiter().GetResult();
      }
   }
}