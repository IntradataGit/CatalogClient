using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Exceptions;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions;
using IntraOffice.Nuget.Catalog.Client.Services;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.Documents.DeleteDocument
{
   [Explicit]
   public class HappyTests : TestBase<ICatalogClient4Documents>
   {
      [Test]
      public async Task Happy_Case()
      {
         //arrange
         var documentTicket = this.CreateDocument();

         //act
         ICatalogClient4Documents service = new CatalogClient4Documents(Settings);

         await service.DeleteDocument(documentTicket);

         //assert
         Assert.ThrowsAsync<ObjectNotFoundException>(() => service.GetDocumentMetadata(documentTicket));
      }
   }
}