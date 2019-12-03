using IntraOffice.Nuget.Catalog.Client.Exceptions;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.EntityQueries.ReadResultsetAllRows
{
   [Explicit]
   public class UnhappyTests : TestBase<ICatalogClient4EntityQueries>
   {
      [Test]
      public void Bad_ResultSetId()
      {
         //assert
         Assert.ThrowsAsync<ObjectNotFoundException>(() => SUT().GetAllRows("abcd"));
      }
   }
}