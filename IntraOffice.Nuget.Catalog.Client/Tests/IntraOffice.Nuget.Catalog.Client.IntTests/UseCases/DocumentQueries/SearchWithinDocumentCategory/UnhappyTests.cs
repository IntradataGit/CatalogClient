using IntraOffice.Nuget.Catalog.Client.Exceptions;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.DocumentQueries.SearchWithinDocumentCategory
{
   [Explicit]
   public class UnhappyTests : TestBase<ICatalogClient4DocumentQueries>
   {
      [Test]
      public void Bad_CategoryId()
      {
         //arrange 
         var searchText = "a";
         var categoryId = "dummy";

         //act+assert
         Assert.ThrowsAsync<BadRequestException>(() => SUT().FindDocumentsWithinCategory(categoryId, searchText));
      }
   }
}