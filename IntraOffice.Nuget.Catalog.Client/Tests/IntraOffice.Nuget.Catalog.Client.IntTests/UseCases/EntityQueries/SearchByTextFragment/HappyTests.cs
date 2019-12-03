using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions;
using IntraOffice.Nuget.Catalog.Client.Services;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.EntityQueries.SearchByTextFragment
{
   [Explicit]
   public class HappyTests : TestBase<ICatalogClient4EntityQueries>
   {
      [Test]
      public async Task Happy_Case()
      {
         //arrange
         var entities = this.GetAllEntities();

         foreach (var entity in entities)
         {
            //act
            ICatalogClient4EntityQueries service = new CatalogClient4EntityQueries(Settings);

            var entityId = entity.Id;

            var searchText = "a";

            var queryResultTicket = await service.FindEntities(entityId, searchText);

            //assert
            Assert.IsFalse(string.IsNullOrEmpty(queryResultTicket));

            //print
            queryResultTicket.Print();
         }
      }
   }
}