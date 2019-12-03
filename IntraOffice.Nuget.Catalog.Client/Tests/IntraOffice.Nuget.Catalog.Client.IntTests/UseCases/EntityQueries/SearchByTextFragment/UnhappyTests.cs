using IntraOffice.Nuget.Catalog.Client.Exceptions;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.EntityQueries.SearchByTextFragment
{
   [Explicit]
   public class UnhappyTests : TestBase<ICatalogClient4EntityQueries>
   {
      [Test]
      public void Bad_EntityId()
      {
         //act+assert
         Assert.ThrowsAsync<ObjectNotFoundException>(() => SUT().FindEntities("d-dummy", "a"));
      }
   }
}