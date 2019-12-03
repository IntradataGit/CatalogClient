using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions;
using IntraOffice.Nuget.Catalog.Client.Services;
using IntraOffice.Nuget.Catalog.Models.Domain;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.EntityQueries.UpdateResultsetSortOrder
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

         var response = await service.GetSortOrder(queryResultTicket);

         //print
         response.Print();

         //act2
         var sortOrderVm = new SortOrderVm {OrderBy = new[] {"d-klantnummer desc"}};

         await service.ChangeSortOder(queryResultTicket, sortOrderVm);

         //act3
         var response2 = await service.GetSortOrder(queryResultTicket);

         //assert3
         CollectionAssert.AreEquivalent(new[] {"d-klantnummer desc"}, response2);

         //print3
         response2.Print();
      }
   }
}