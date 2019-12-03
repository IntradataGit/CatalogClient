using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.Documents.ReadDocumentVersion
{
   [Explicit]
   public class HappyTests : DocumentTestBase<ICatalogClient4Documents>
   {
      [Test]
      public async Task Happy_Case()
      {
         //arrange
         var versionToken = this.CreateDocumentVersion(_documentTicket);

         //act
         var documentMetadata = await SUT().GetDocumentMetadata(versionToken);

         //assert
         Assert.IsNotNull(documentMetadata);

         //print
         documentMetadata.Print();
      }
   }
}