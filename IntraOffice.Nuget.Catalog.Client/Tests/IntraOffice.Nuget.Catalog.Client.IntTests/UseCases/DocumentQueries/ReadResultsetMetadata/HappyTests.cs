using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions;
using IntraOffice.Nuget.Catalog.Client.Services;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.DocumentQueries.ReadResultsetMetadata
{
   [Explicit]
   public class HappyTests : TestBase<ICatalogClient4DocumentQueries>
   {
      [Test]
      public async Task Happy_Case()
      {
         //arrange
         var queryResultTicket = this.CreateQueryResult();

         //act
         ICatalogClient4DocumentQueries service = new CatalogClient4DocumentQueries(Settings);

         var queryResultMetadata = await service.GetQueryResultMetadata(queryResultTicket);

         //assert
         Assert.IsNotNull(queryResultMetadata);

         //print
         queryResultMetadata.Print();
      }
   }
}