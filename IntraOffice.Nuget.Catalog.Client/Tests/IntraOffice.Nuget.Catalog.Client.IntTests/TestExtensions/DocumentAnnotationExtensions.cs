using System.Collections.Generic;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Models.Domain.Documents.Annotations;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions
{
   public static class DocumentAnnotationExtensions
   {
      public static void CreateDocumentAnnotation(this TestBase test, string documentTicket, string annotationText, bool isPublic)
      {
         var model = new CreateAnnotationVm {Text = annotationText, IsPublic = isPublic};
         test.GetInstance<ICatalogClient4Documents>().AddDocumentAnnotation(documentTicket, model).GetAwaiter().GetResult();
      }

      public static IEnumerable<AnnotationVm> ListDocumentAnnotations(this TestBase test, string documentTicket)
      {
         return test.GetInstance<ICatalogClient4Documents>().GetDocumentAnnotations(documentTicket).GetAwaiter().GetResult();
      }
   }
}