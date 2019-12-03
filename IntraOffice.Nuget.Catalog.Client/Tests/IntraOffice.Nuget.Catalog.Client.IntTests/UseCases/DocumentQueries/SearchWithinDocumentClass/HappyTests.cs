using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions;
using IntraOffice.Nuget.Catalog.Client.Services;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.DocumentQueries.SearchWithinDocumentClass
{
   [Explicit]
   public class HappyTests : TestBase<ICatalogClient4DocumentQueries>
   {
      [Test]
      public async Task Happy_Case()
      {
         //arrange 
         var documentClasses = this.GetAllClasses();
         var searchText = "a";

         //act
         ICatalogClient4DocumentQueries service = new CatalogClient4DocumentQueries(Settings);

         foreach (var documentClass in documentClasses)
         {
            var queryResultTicket = await service.FindDocumentsWithinClass(documentClass.Id, searchText);

            //assert
            Assert.IsNotNull(queryResultTicket);

            //print
            queryResultTicket.Print();
         }
      }
   }
}