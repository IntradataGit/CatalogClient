using IntraOffice.Nuget.Catalog.Client.Exceptions;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.EntityQueries.ReadResultsetSpecificRows
{
   [Explicit]
   public class UnhappyTests : TestBase<ICatalogClient4EntityQueries>
   {
      [Test]
      public void Bad_ResultsetId()
      {
         //arrange
         var resultsetId = "dummy";

         //act+assert
         Assert.ThrowsAsync<ObjectNotFoundException>(() => SUT().GetSpecificRows(resultsetId, 1, 2));
      }

      [Test]
      public void Number_Rows_Too_Skip_Too_Large()
      {
         //arrange
         var resultsetId = this.CreateEntityResultset();

         //act+assert
         Assert.ThrowsAsync<BadRequestException>(() => SUT().GetSpecificRows(resultsetId, int.MaxValue, 2));
      }
   }
}