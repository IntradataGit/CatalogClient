using System.Collections.Generic;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Models.Domain.Documents.Versions;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions
{
   public static class DocumentVersionExtensions
   {
      public static string CreateDocumentVersion(this TestBase test, string documentTicket)
      {
         var model = new CreateDocumentVersionVm
         {
            CopyAnnotations = true,
            ContentType = "application/pdf",
            Content = new byte[] {1, 2, 3, 4, 5}
         };

         var documentVersion = test.GetInstance<ICatalogClient4Documents>().CreateDocumentVersion(documentTicket, model).GetAwaiter().GetResult();

         return documentVersion;
      }

      public static IEnumerable<DocumentVersionVm> ListDocumentVersions(this TestBase test, string documentTicket)
      {
         return test.GetInstance<ICatalogClient4Documents>().GetDocumentVersions(documentTicket).GetAwaiter().GetResult();
      }
   }
}