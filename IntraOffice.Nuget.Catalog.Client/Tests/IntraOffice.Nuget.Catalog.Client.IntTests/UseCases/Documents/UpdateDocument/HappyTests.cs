using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions;
using IntraOffice.Nuget.Catalog.Client.Services;
using IntraOffice.Nuget.Catalog.Models.Domain.Documents;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.Documents.UpdateDocument
{
   [Explicit]
   public class HappyTests : DocumentTestBase<ICatalogClient4Documents>
   {
      [Test]
      public async Task Happy_Case()
      {
         //arrange
         var model = new UpdateDocumentVm
         {
            Elements = new Dictionary<string, string>
            {
               {"hr-medewerkerCode", "dummy"}
            }
         };

         //act
         ICatalogClient4Documents service = new CatalogClient4Documents(Settings);

         await service.UpdateDocumentMetadata(_documentTicket, model);

         //assert
         var documentVm2 = this.GetDocument(_documentTicket);
         documentVm2.Print();

         Assert.AreEqual("dummy", GetDescription(documentVm2));
      }

      private static string GetDescription(DocumentVm documentVm)
      {
         return documentVm.Elements.ToDictionary(x => x.Name, z => z.Value)["hr-medewerkerCode"] as string;
      }
   }
}