using IntraOffice.Nuget.Catalog.Client.Exceptions;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions;
using IntraOffice.Nuget.Catalog.Models.Domain;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.EntityQueries.UpdateResultsetSortOrder
{
   [Explicit]
   public class UnhappyTests : TestBase<ICatalogClient4EntityQueries>
   {
      [Test]
      public void Not_Existing_ResultsetId1()
      {
         //act+assert
         Assert.ThrowsAsync<ObjectNotFoundException>(() => SUT().GetSortOrder("abcd"));
      }

      [Test]
      public void Not_Existing_ResultsetId2()
      {
         //act+assert
         Assert.ThrowsAsync<ObjectNotFoundException>(() => SUT().ChangeSortOder("abcd", new SortOrderVm {OrderBy = new[] {"d-mobilePhone desc"}}));
      }

      [Test]
      public void Not_Existing_Element_Name()
      {
         //arrange
         var resultsetId = this.CreateEntityResultset();

         //act+assert
         Assert.ThrowsAsync<BadRequestException>(() => SUT().ChangeSortOder(resultsetId, new SortOrderVm {OrderBy = new[] {"d-dummy desc"}}));
      }

      [Test]
      public void Bad_Format_Element_Name()
      {
         //arrange
         var resultsetId = this.CreateEntityResultset();

         //act+assert
         Assert.ThrowsAsync<BadRequestException>(() => SUT().ChangeSortOder(resultsetId, new SortOrderVm {OrderBy = new[] {"dummy desc"}}));
      }
   }
}