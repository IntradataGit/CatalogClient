using System.Collections.Generic;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Models.Domain.EntityQueries;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions
{
   public static class EntityResultsetExtensions
   {
      public static IEnumerable<EntityRowVm> GetEntityRows(this TestBase test, string resultsetId)
      {
         return test.GetInstance<ICatalogClient4EntityQueries>().GetAllRows(resultsetId).GetAwaiter().GetResult();
      }

      //public static string CreateEntityResultset(this TestBase test)
      //{
      //   var model = new CatalogQueryVm
      //   {
      //      Query = new CatalogQueryContentVm
      //      {
      //         Select = new[] { "d-klantnummer", "d-productCombinatie", "d-medewerkerNummer" }
      //      }
      //   };

      //   var resultsetLocation = test.GetInstance<ICatalogClient4EntityQueries>().FindEntities("hr-medewerker", model).GetAwaiter().GetResult();

      //   return resultsetLocation.Split('/').Last();
      //}

      public static string CreateEntityResultset(this TestBase test)
      {
         var queryResultTicket = test.GetInstance<ICatalogClient4EntityQueries>().FindEntities("hr-medewerker", "a").GetAwaiter().GetResult();
         return queryResultTicket;
      }
   }
}