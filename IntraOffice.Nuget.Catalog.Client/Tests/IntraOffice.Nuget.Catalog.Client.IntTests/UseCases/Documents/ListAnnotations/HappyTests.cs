using System.Linq;
using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions;
using IntraOffice.Nuget.Catalog.Client.Services;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.Documents.ListAnnotations
{
   [Explicit]
   public class HappyTests : DocumentTestBase<ICatalogClient4Documents>
   {
      [Test]
      public async Task List_Annotations()
      {
         //arrange
         this.CreateDocumentAnnotation(_documentTicket, "This is annotation 1", true);
         this.CreateDocumentAnnotation(_documentTicket, "This is annotation 2", true);

         //act
         ICatalogClient4Documents service = new CatalogClient4Documents(Settings);

         var documentAnnotations = await service.GetDocumentAnnotations(_documentTicket);

         //assert
         Assert.AreEqual(2, documentAnnotations.Count());

         //print
         documentAnnotations.Print();
      }

      [Test]
      public async Task List_Annotations_Specific_Version()
      {
         //arrange
         var documentVersionTicket = this.CreateDocumentVersion(_documentTicket);
         this.CreateDocumentAnnotation(documentVersionTicket, "Annotation 1", true);
         this.CreateDocumentAnnotation(documentVersionTicket, "Annotation 2", true);

         //act
         var response = await SUT().GetDocumentAnnotations(documentVersionTicket);

         //assert
         Assert.AreEqual(2, response.Count());

         //print
         response.Print();
      }
   }
}