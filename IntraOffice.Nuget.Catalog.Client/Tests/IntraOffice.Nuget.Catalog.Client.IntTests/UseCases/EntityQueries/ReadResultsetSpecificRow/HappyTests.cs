using System.Linq;
using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions;
using IntraOffice.Nuget.Catalog.Client.Services;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.EntityQueries.ReadResultsetSpecificRow
{
   [Explicit]
   public class HappyTests : TestBase<ICatalogClient4EntityQueries>
   {
      [Test]
      public async Task Happy_Case()
      {
         //arrange
         var queryResultTicket = this.CreateEntityResultset();
         var rows = this.GetEntityRows(queryResultTicket).ToArray();

         for (var i = 0; i < rows.Length; i++)
         {
            var rowIndex = i;

            ICatalogClient4EntityQueries service = new CatalogClient4EntityQueries(Settings);

            var row = await service.GetSpecificRow(queryResultTicket, rowIndex);

            //assert
            Assert.IsNotNull(row);

            //print
            row.Print();
         }
      }
   }
}