using IntraOffice.Nuget.Catalog.Client.Exceptions;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.DocumentQueries.ReadResultsetMetadata
{
   [Explicit]
   public class UnhappyTests : TestBase<ICatalogClient4DocumentQueries>
   {
      [Test]
      public void Bad_ResultsetId()
      {
         //assert
         Assert.ThrowsAsync<ObjectNotFoundException>(() => SUT().GetQueryResultMetadata("abcd"));
      }
   }
}