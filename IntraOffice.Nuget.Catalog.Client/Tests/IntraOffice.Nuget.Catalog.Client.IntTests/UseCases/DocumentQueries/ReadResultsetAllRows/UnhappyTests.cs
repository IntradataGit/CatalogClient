using IntraOffice.Nuget.Catalog.Client.Exceptions;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.DocumentQueries.ReadResultsetAllRows
{
   [Explicit]
   public class UnhappyTests : TestBase<ICatalogClient4EntityQueries>
   {
      [Test]
      public void Bad_ResultsetId()
      {
         //arrange
         var resultsetId = "abcd";

         //act+assert
         Assert.ThrowsAsync<ObjectNotFoundException>(() => SUT().GetAllRows(resultsetId));
      }
   }
}