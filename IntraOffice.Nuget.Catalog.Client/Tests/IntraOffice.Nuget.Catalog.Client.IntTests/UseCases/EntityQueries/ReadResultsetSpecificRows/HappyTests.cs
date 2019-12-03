using System.Linq;
using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions;
using IntraOffice.Nuget.Catalog.Client.Services;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.EntityQueries.ReadResultsetSpecificRows
{
   [Explicit]
   public class HappyTests : TestBase<ICatalogClient4EntityQueries>
   {
      [Test]
      public async Task Happy_Case()
      {
         //arrange
         var queryResultTicket = this.CreateEntityResultset();

         //act
         ICatalogClient4EntityQueries service = new CatalogClient4EntityQueries(Settings);

         var numberRowsToSkip = 1;

         var numberRowsToTake = 2;

         var rows = await service.GetSpecificRows(queryResultTicket, numberRowsToSkip, numberRowsToTake);

         //assert
         CollectionAssert.IsNotEmpty(rows);
         Assert.AreEqual(2, rows.Count());

         //print
         rows.Print();
      }
   }
}