using System.Collections.Generic;
using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions;
using IntraOffice.Nuget.Catalog.Client.Services;
using IntraOffice.Nuget.Catalog.Models.Domain;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.DocumentQueries.SearchUsingCustomQuery
{
   [Explicit]
   public class HappyTests : TestBase<ICatalogClient4DocumentQueries>
   {
      [Test]
      public async Task Happy_Case()
      {
         //arrange
         var query = new CatalogQueryVm
         {
            Query = new CatalogQueryContentVm
            {
               Select = new[] {"d-klantnummer", "d-productCombinatie", "a-documentDateCreated"},
               Where = new Dictionary<string, string> {{"d-productCombinatie", "BO4GEM"}},
               Top = 30,
               OrderBy = new[] {"a-documentDateCreated asc"}
            }
         };

         //act
         ICatalogClient4DocumentQueries service = new CatalogClient4DocumentQueries(Settings);

         var queryResultTicket = await service.FindDocuments(query);

         //assert
         Assert.IsFalse(string.IsNullOrEmpty(queryResultTicket));

         //print
         queryResultTicket.Print();
      }
   }
}