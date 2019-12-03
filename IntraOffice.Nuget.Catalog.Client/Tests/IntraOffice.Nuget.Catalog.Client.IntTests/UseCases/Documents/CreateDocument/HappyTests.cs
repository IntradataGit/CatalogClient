using System.Collections.Generic;
using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions;
using IntraOffice.Nuget.Catalog.Client.Services;
using IntraOffice.Nuget.Catalog.Models.Domain.Documents;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.Documents.CreateDocument
{
   [Explicit]
   public class HappyTests : TestBase
   {
      [Test]
      public async Task Happy_Case()
      {
         //arrange
         var model = new CreateDocumentVm
         {
            Category = "hr-0000002-ovPersoonlijk",
            RetentionScheduleCode = "DEFAULT",
            Elements = new Dictionary<string, string>
            {
               {"hr-bronsysteem", "home pc"},
               {"d-productCombinatie", "abc123"},
               {"d-medewerkerNummer", "123"},
               {"hr-ingangsDatum", "2019-11-12"},
               {"hr-documentOmschrijving", "loren ipsum"}
            },
            ContentType = "application/pdf",
            Content = this.GetEmbeddedBytes()
         };

         //act
         ICatalogClient4Documents service = new CatalogClient4Documents(Settings);

         var documentToken = await service.CreateDocument(model);

         //assert
         Assert.IsFalse(string.IsNullOrEmpty(documentToken));

         //print
         documentToken.Print();

         //clean up
         this.DeleteDocument(documentToken);
      }
   }
}