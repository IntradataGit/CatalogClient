using System.Collections.Generic;
using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions;
using IntraOffice.Nuget.Catalog.Client.Services;
using IntraOffice.Nuget.Catalog.Models.Domain;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.EntityQueries.SearchUsingCustomQuery
{
   [Explicit]
   public class HappyTests : TestBase<ICatalogClient4EntityQueries>
   {
      [Test]
      public async Task Happy_Case()
      {
         //arrange
         var entityId = "hr-medewerker";

         var query = new CatalogQueryVm
         {
            Query = new CatalogQueryContentVm
            {
               Select = new[] {"d-klantnummer"},
               Where = new Dictionary<string, string> {{"d-productCombinatie", "123"}},
               OrderBy = new[] {"d-klantnummer asc"},
               Top = 25
            }
         };

         //act
         ICatalogClient4EntityQueries service = new CatalogClient4EntityQueries(Settings);

         var queryResultTicket = await service.FindEntities(entityId, query);

         //assert
         Assert.IsFalse(string.IsNullOrEmpty(queryResultTicket));

         //print
         queryResultTicket.Print();
      }
   }
}