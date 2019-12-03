using System.Collections.Generic;
using System.Linq;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Models.Domain.DocumentQueries;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions
{
   public static class DocumentResultsetExtensions
   {
      public static IEnumerable<DocumentRowVm> GetDocumentRows(this TestBase test, string resultsetId)
      {
         return test.GetInstance<ICatalogClient4DocumentQueries>().GetAllRows(resultsetId).GetAwaiter().GetResult();
      }

      //public static string CreateQueryResult(this TestBase test)
      //{
      //   var documentClass = test.GetAllClasses().First();
      //   var documentClassId = documentClass.Id;
      //   var searchText = "";
      //   var queryResultToken = test.GetInstance<ICatalogClient4DocumentQueries>().FindDocumentsWithinClass(documentClassId, searchText).GetAwaiter().GetResult();
      //   return queryResultToken;
      //}

      public static string CreateQueryResult(this TestBase test)
      {
         var documentCategory = test.GetAllCategories().First();
         var documentCategoryId = documentCategory.Id;
         var searchText = "";
         var queryResultToken = test.GetInstance<ICatalogClient4DocumentQueries>().FindDocumentsWithinCategory(documentCategoryId, searchText).GetAwaiter().GetResult();
         return queryResultToken;
      }

      //public static string CreateQueryResult(this TestBase test)
      //{
      //   var query = new CatalogQueryVm
      //   {
      //      Query = new CatalogQueryContentVm
      //      {
      //         Select = new[] { "d-klantnummer", "d-productCombinatie", "a-documentDateCreated" },
      //         Where = new Dictionary<string, string> { { "d-productCombinatie", "BO4GEM" } },
      //         Top = 30,
      //         OrderBy = new[] { "a-documentDateCreated asc" }
      //      }
      //   };

      //   var result = test.GetInstance<ICatalogClient4DocumentQueries>().FindDocuments(query).GetAwaiter().GetResult();
      //   return result.Split('/').Last();
      //}
   }
}