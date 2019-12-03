using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions;
using IntraOffice.Nuget.Catalog.Client.Services;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.Configuration.GetAllClasses
{
   [Explicit]
   public class HappyTests : TestBase
   {
      [Test]
      public async Task Get_All_Classes()
      {
         //arrange 
         ICatalogClient4Configs service = new CatalogClient4Configs(Settings);

         //act
         var classes = await service.GetClasses();

         //assert
         Assert.IsNotNull(classes);
         CollectionAssert.IsNotEmpty(classes);

         //print
         classes.Print();
      }
   }
}