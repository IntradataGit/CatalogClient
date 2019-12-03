using System.Linq;
using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions;
using IntraOffice.Nuget.Catalog.Client.Services;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.DocumentQueries.ReadResultsetSpecificRow
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

         ICatalogClient4DocumentQueries service = new CatalogClient4DocumentQueries(Settings);

         for (var rowIndex = 0; rowIndex < rows.Length; rowIndex++)
         {
            var row = await service.GetSpecificRow(queryResultTicket, rowIndex);

            //assert
            Assert.IsNotNull(row);

            //print
            row.Print();
         }
      }
   }
}