using System.Linq;
using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions;
using IntraOffice.Nuget.Catalog.Client.Services;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.Documents.DeleteDocumentVersion
{
   [Explicit]
   public class HappyTests : DocumentTestBase<ICatalogClient4Documents>
   {
      [Test]
      public async Task Happy_Case()
      {
         //arrange
         var version1Ticket = _documentTicket;
         var version2Ticket = this.CreateDocumentVersion(_documentTicket);
         var version3Ticket = this.CreateDocumentVersion(_documentTicket);

         //act
         ICatalogClient4Documents service = new CatalogClient4Documents(Settings);

         await service.DeleteDocumentVersion(version1Ticket);

         //assert
         var finalDocumentVersions = this.ListDocumentVersions(version2Ticket);
         finalDocumentVersions.Print();

         Assert.AreEqual(2, finalDocumentVersions.Count());
      }
   }
}