using IntraOffice.Nuget.Catalog.Client.Exceptions;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.DocumentQueries.ReadResultsetSpecificRows
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
         Assert.ThrowsAsync<ObjectNotFoundException>(() => SUT().GetSpecificRows(resultsetId, 1, 1));
      }

      [Test]
      public void Number_Rows_Too_Skip_Too_Large()
      {
         //arrange
         var resultsetId = this.CreateQueryResult();

         //act+assert
         Assert.ThrowsAsync<BadRequestException>(() => SUT().GetSpecificRows(resultsetId, int.MaxValue, 1));
      }
   }
}