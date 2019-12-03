using IntraOffice.Nuget.Catalog.Client.Exceptions;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.Configuration.GetSpecificEntity
{
   [Explicit]
   public class UnhappyTests : TestBase<ICatalogClient4Configs>
   {
      [Test]
      public void Bad_EntityId()
      {
         //arrange 
         var entityId = "dummy";

         //act+assert
         Assert.ThrowsAsync<ObjectNotFoundException>(() => SUT().GetEntityById(entityId));
      }
   }
}