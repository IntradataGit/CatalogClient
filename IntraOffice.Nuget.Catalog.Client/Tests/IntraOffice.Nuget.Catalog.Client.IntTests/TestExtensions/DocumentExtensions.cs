using System.Collections.Generic;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Models.Domain.Documents;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions
{
   public static class DocumentExtensions
   {
      public static string CreateDocument(this TestBase test)
      {
         var model = new CreateDocumentVm
         {
            Category = "hr-0000002-ovPersoonlijk",
            RetentionScheduleCode = "DEFAULT",
            Elements = new Dictionary<string, string>
            {
               {"hr-bronsysteem", "home pc"},
               {"d-productCombinatie", "abc123"},
               {"d-medewerkerNummer", "123"},
               {"hr-ingangsDatum", "2019-11-12"},
               {"hr-documentOmschrijving", "loren ipsum"}
            },
            ContentType = "application/pdf",
            Content = test.GetEmbeddedBytes()
         };

         return test.GetInstance<ICatalogClient4Documents>().CreateDocument(model).GetAwaiter().GetResult();
      }

      public static DocumentVm GetDocument(this TestBase test, string documentToken)
      {
         return test.GetInstance<ICatalogClient4Documents>().GetDocumentMetadata(documentToken).GetAwaiter().GetResult();
      }

      public static void DeleteDocument(this TestBase test, string documentToken)
      {
         test.GetInstance<ICatalogClient4Documents>().DeleteDocument(documentToken).GetAwaiter().GetResult();
      }
   }
}