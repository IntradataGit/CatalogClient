using System.Collections.Generic;
using IntraOffice.Nuget.Catalog.Client.Exceptions;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Models.Domain;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.EntityQueries.SearchUsingCustomQuery
{
   [Explicit]
   public class UnhappyTests : TestBase<ICatalogClient4EntityQueries>
   {
      [Test]
      public void Bad_EntityId()
      {
         //arrange
         var query = new CatalogQueryVm
         {
            Query = new CatalogQueryContentVm
            {
               Select = new string[0],
               Where = new Dictionary<string, string>()
            }
         };

         //assert
         Assert.ThrowsAsync<BadRequestException>(() => SUT().FindEntities("dummy", query));
      }
   }
}