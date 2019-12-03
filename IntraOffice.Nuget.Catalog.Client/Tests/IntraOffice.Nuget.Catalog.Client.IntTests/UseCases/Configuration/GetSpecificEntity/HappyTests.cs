using System.Linq;
using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions;
using IntraOffice.Nuget.Catalog.Client.Services;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.Configuration.GetSpecificEntity
{
   [Explicit]
   public class HappyTests : TestBase<ICatalogClient4Configs>
   {
      [Test]
      public async Task Happy_Case()
      {
         //arrange 
         var entityIds = this.GetAllEntities().Select(entity => entity.Id);

         foreach (var entityId in entityIds)
         {
            //act
            ICatalogClient4Configs service = new CatalogClient4Configs(Settings);

            var entity = await service.GetEntityById(entityId);

            //assert
            Assert.IsNotNull(entity);

            //print
            entity.Print();
         }
      }
   }
}