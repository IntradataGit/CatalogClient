using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions;
using IntraOffice.Nuget.Catalog.Client.Services;
using IntraOffice.Nuget.Catalog.Models.Domain;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.DocumentQueries.UpdateResultsetSortOrder
{
   [Explicit]
   public class HappyTests : TestBase<ICatalogClient4DocumentQueries>
   {
      [Test]
      public async Task Get_Set_Get_SortOrder()
      {
         //arrange
         var queryResultTicket = this.CreateQueryResult();

         //act
         ICatalogClient4DocumentQueries service = new CatalogClient4DocumentQueries(Settings);

         var response = await service.GetSortOrder(queryResultTicket);

         //print
         response.Print();

         //act2
         await service.ChangeSortOder(queryResultTicket, new SortOrderVm {OrderBy = new[] {"d-klantnummer desc"}});

         //act3
         var response2 = await service.GetSortOrder(queryResultTicket);

         //assert3
         CollectionAssert.AreEquivalent(new[] {"d-klantnummer desc"}, response2);

         //print3
         response2.Print();
      }
   }
}