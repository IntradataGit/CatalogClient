using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions;
using IntraOffice.Nuget.Catalog.Client.Services;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.EntityQueries.ReadResultsetAllRows
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

         var rows = await service.GetAllRows(queryResultTicket);

         //assert
         Assert.IsNotNull(rows);

         //print
         rows.Print();
      }
   }
}