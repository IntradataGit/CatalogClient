using System.Linq;
using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions;
using IntraOffice.Nuget.Catalog.Client.Services;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.Documents.DeleteAnnotation
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

         //act
         ICatalogClient4Documents service = new CatalogClient4Documents(Settings);

         await service.DeleteDocumentAnnotation(_documentTicket, annotationTicket);

         //assert
         Assert.AreEqual(0, this.ListDocumentAnnotations(_documentTicket).Count());
      }
   }
}