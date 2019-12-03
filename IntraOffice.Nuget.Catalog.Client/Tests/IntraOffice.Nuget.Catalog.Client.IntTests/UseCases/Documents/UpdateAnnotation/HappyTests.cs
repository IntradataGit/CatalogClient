using System.Linq;
using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions;
using IntraOffice.Nuget.Catalog.Client.Services;
using IntraOffice.Nuget.Catalog.Models.Domain.Documents.Annotations;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.Documents.UpdateAnnotation
{
   [Explicit]
   public class HappyTests : DocumentTestBase<ICatalogClient4Documents>
   {
      [Test]
      public async Task Happy_Case()
      {
         //arrange
         this.CreateDocumentAnnotation(_documentTicket, "abc", true);
         var documentAnnotations = this.ListDocumentAnnotations(_documentTicket);

         var annotationTicket = documentAnnotations.First().Ticket;
         var model = new UpdateAnnotationVm {IsPublic = false, Text = "newAbc2"};

         //act
         ICatalogClient4Documents service = new CatalogClient4Documents(Settings);

         await service.UpdateDocumentAnnotation(_documentTicket, annotationTicket, model);

         //arrange
         var listDocumentAnnotations = this.ListDocumentAnnotations(_documentTicket);
         listDocumentAnnotations.Print();

         Assert.AreEqual("newAbc2", listDocumentAnnotations.First().Text);
      }
   }
}