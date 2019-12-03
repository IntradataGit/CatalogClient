using IntraOffice.Nuget.Catalog.Client.Exceptions;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.DocumentQueries.ReadResultsetSpecificRow
{
   [Explicit]
   public class UnhappyTests : TestBase<ICatalogClient4DocumentQueries>
   {
      [Test]
      public void Bad_ResultsetId()
      {
         //arrange
         var resultsetId = "abcd";

         //act+assert
         Assert.ThrowsAsync<ObjectNotFoundException>(() => SUT().GetSpecificRow(resultsetId, 0));
      }

      [Test]
      public void Row_Index_Too_Large()
      {
         //arrange
         var resultsetId = this.CreateQueryResult();

         //act+assert
         Assert.ThrowsAsync<BadRequestException>(() => SUT().GetSpecificRow(resultsetId, int.MaxValue));
      }
   }
}