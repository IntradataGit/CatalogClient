using System;
using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions;
using IntraOffice.Nuget.Catalog.Client.Services;
using IntraOffice.Nuget.Catalog.Models.Domain.Documents.Versions;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.Documents.CreateDocumentVersion
{
   [Explicit]
   public class HappyTests : DocumentTestBase<ICatalogClient4Documents>
   {
      [Test]
      public async Task Happy_Case()
      {
         //arrange
         var model = new CreateDocumentVersionVm
         {
            ContentType = "application/pdf",
            Content = this.GetEmbeddedBytes(),
            CopyAnnotations = true
         };

         //act
         ICatalogClient4Documents service = new CatalogClient4Documents(Settings);

         var documentVersionToken = await service.CreateDocumentVersion(_documentTicket, model);

         //assert
         Assert.IsNotNull(documentVersionToken);

         //print
         Console.WriteLine(documentVersionToken);

         var documentVersions = this.ListDocumentVersions(_documentTicket);

         //print 
         documentVersions.Print();
      }
   }
}