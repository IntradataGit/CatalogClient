using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions;
using IntraOffice.Nuget.Catalog.Client.Services;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.Configuration.GetAllEntities
{
   [Explicit]
   public class HappyTests : TestBase<ICatalogClient4Configs>
   {
      [Test]
      public async Task Happy_Case()
      {
         //act
         ICatalogClient4Configs service = new CatalogClient4Configs(Settings);

         var entities = await service.GetEntities();

         //assert
         Assert.IsNotNull(entities);
         CollectionAssert.IsNotEmpty(entities);

         //print
         entities.Print();
      }
   }
}