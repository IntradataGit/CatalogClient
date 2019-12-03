using System.Collections.Generic;
using IntraOffice.Nuget.Catalog.Client.Exceptions;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Models.Domain;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.DocumentQueries.SearchUsingCustomQuery
{
   [Explicit]
   public class UnhappyTests : TestBase<ICatalogClient4DocumentQueries>
   {
      [Test]
      public void Bad_ElementName()
      {
         //arrange
         var query = new CatalogQueryVm
         {
            Query = new CatalogQueryContentVm
            {
               Select = new string[0],
               Where = new Dictionary<string, string> {{"d-email", "mikhail.tchesnokov@intradata.nl"}}
            }
         };

         //act+assert
         Assert.ThrowsAsync<BadRequestException>(() => SUT().FindDocuments(query));
      }
   }
}