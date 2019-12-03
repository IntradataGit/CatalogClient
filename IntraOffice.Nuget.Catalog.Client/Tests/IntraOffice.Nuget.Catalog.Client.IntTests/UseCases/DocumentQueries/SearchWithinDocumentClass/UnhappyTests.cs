using IntraOffice.Nuget.Catalog.Client.Exceptions;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.DocumentQueries.SearchWithinDocumentClass
{
   [Explicit]
   public class UnhappyTests : TestBase<ICatalogClient4DocumentQueries>
   {
      [Test]
      public void Invalid_ClassId()
      {
         //arrange 
         var classId = "dummy";
         var searchText = "a";

         //assert
         Assert.ThrowsAsync<BadRequestException>(() => SUT().FindDocumentsWithinClass(classId, searchText));
      }
   }
}