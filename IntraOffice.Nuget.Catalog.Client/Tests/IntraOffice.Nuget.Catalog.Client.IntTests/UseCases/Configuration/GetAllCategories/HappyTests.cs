using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.Configuration.GetAllCategories
{
   [Explicit]
   public class HappyTests : TestBase<ICatalogClient4Configs>
   {
      [Test]
      public async Task Happy_Case()
      {
         //act
         var categories = await SUT().GetCategories();

         //assert
         Assert.IsNotNull(categories);
         CollectionAssert.IsNotEmpty(categories);

         //print
         categories.Print();
      }
   }
}