using System.Collections.Generic;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Models.Domain.Configuration;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions
{
   public static class GetAllCategoriesExtension
   {
      public static IEnumerable<CategoryVm> GetAllCategories(this TestBase test)
      {
         return test.GetInstance<ICatalogClient4Configs>().GetCategories().GetAwaiter().GetResult();
      }
   }
}