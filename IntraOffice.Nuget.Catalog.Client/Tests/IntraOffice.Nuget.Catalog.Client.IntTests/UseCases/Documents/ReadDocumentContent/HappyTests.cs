using System;
using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Client.Services;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.Documents.ReadDocumentContent
{
   [Explicit]
   public class HappyTests : DocumentTestBase<ICatalogClient4Documents>
   {
      [Test]
      public async Task Happy_Case()
      {
         //act
         ICatalogClient4Documents service = new CatalogClient4Documents(Settings);

         var bytes = await service.GetDocumentContent(_documentTicket);

         //assert
         CollectionAssert.IsNotEmpty(bytes);

         //print 
         Console.WriteLine(bytes.Length);
      }
   }
}