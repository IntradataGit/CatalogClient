using System.Collections.Generic;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Models.Domain.Configuration;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions
{
   public static class GetAllEntitiesExtension
   {
      public static IEnumerable<EntityVm> GetAllEntities(this TestBase test)
      {
         return test.GetInstance<ICatalogClient4Configs>().GetEntities().GetAwaiter().GetResult();
      }
   }
}