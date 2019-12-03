using System.Linq;
using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions;
using IntraOffice.Nuget.Catalog.Client.Services;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.DocumentQueries.ReadResultsetSpecificRows
{
   [Explicit]
   public class HappyTests : TestBase<ICatalogClient4DocumentQueries>
   {
      [Test]
      public async Task Happy_Case()
      {
         //arrange
         var queryResultTicket = this.CreateQueryResult();
         var rows = this.GetDocumentRows(queryResultTicket).ToArray();

         if (rows.Length < 3)
         {
            Assert.Inconclusive();
         }

         ICatalogClient4DocumentQueries service = new CatalogClient4DocumentQueries(Settings);

         var numberRowsToSkip = 1;

         var numberRowsToReturn = 2;

         var subRows = await service.GetSpecificRows(queryResultTicket, numberRowsToSkip, numberRowsToReturn);

         //assert
         CollectionAssert.IsNotEmpty(subRows);
         Assert.AreEqual(numberRowsToReturn, subRows.Count());

         //print
         subRows.Print();
      }
   }
}