using System;
using IntraOffice.Nuget.Catalog.Client.Exceptions;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.EntityQueries.ReadResultsetSpecificRow
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
         Assert.ThrowsAsync<ObjectNotFoundException>(() => SUT().GetSpecificRow(resultsetId, 0));
      }

      [Test]
      public void Index_Negative()
      {
         //arrange
         var resultsetId = this.CreateEntityResultset();

         //assert
         Assert.ThrowsAsync<ArgumentException>(() => SUT().GetSpecificRow(resultsetId, -1));
      }

      [Test]
      public void Index_Too_Large()
      {
         //arrange
         var resultsetId = this.CreateEntityResultset();

         //assert
         Assert.ThrowsAsync<ObjectNotFoundException>(() => SUT().GetSpecificRow(resultsetId, int.MaxValue));
      }
   }
}