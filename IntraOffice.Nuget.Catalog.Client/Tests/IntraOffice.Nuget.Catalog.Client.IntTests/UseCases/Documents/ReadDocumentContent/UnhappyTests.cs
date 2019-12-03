using IntraOffice.Nuget.Catalog.Client.Exceptions;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.Documents.ReadDocumentContent
{
   [Explicit]
   public class UnhappyTests : DocumentTestBase<ICatalogClient4Documents>
   {
      [Test]
      public void Bad_DocumentId()
      {
         //arrange
         var documentId = "dummy";

         //act+assert
         Assert.ThrowsAsync<BadRequestException>(() => SUT().GetDocumentContent(documentId));
      }
   }
}