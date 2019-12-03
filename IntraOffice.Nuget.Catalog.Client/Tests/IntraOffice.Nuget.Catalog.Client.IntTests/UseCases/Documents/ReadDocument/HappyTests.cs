using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions;
using IntraOffice.Nuget.Catalog.Client.Services;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.Documents.ReadDocument
{
   [Explicit]
   public class HappyTests : DocumentTestBase<ICatalogClient4Documents>
   {
      [Test]
      public async Task Happy_Case()
      {
         //act
         ICatalogClient4Documents service = new CatalogClient4Documents(Settings);

         var documentMetadata = await service.GetDocumentMetadata(_documentTicket);

         //assert
         Assert.IsNotNull(documentMetadata);

         //print
         documentMetadata.Print();
      }
   }
}