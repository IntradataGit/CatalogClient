using System.Linq;
using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions;
using IntraOffice.Nuget.Catalog.Client.Services;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.Documents.ListDocumentVersions
{
   [Explicit]
   public class HappyTests : DocumentTestBase<ICatalogClient4Documents>
   {
      [Test]
      public async Task Happy_Case()
      {
         //arrange
         var versionTicket = this.CreateDocumentVersion(_documentTicket);

         //act
         ICatalogClient4Documents service = new CatalogClient4Documents(Settings);

         var documentVersions = await service.GetDocumentVersions(versionTicket);

         //assert
         Assert.AreEqual(2, documentVersions.Count());

         //print
         documentVersions.Print();
      }
   }
}