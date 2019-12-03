using System.Linq;
using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions;
using IntraOffice.Nuget.Catalog.Client.Services;
using IntraOffice.Nuget.Catalog.Models.Domain.Documents.Annotations;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.Documents.AddAnnotation
{
   [Explicit]
   public class HappyTests : DocumentTestBase<ICatalogClient4Documents>
   {
      [Test]
      public async Task Happy_Case()
      {
         //arrange
         var model = new CreateAnnotationVm {IsPublic = true, Text = "abc"};

         //act
         ICatalogClient4Documents service = new CatalogClient4Documents(Settings);

         await service.AddDocumentAnnotation(_documentTicket, model);

         //assert
         Assert.AreEqual(1, this.ListDocumentAnnotations(_documentTicket).Count());
      }
   }
}