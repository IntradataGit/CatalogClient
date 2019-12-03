using System;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Testing.UnitTests;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.UnitTests.UseCases.CatalogClient4Configs
{
   public abstract class UnhappyTests : UnitTestBase<ICatalogClient4Configs>
   {
      public class GetEntityById : UnhappyTests
      {
         [Test]
         public void Entity_Id_Null()
         {
            //arrange
            var entityId = "";

            //act+assert
            Assert.ThrowsAsync<ArgumentNullException>(() => SUT().GetEntityById(entityId));
         }
      }
   }
}