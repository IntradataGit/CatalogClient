using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.Configuration.GetAllElements
{
   [Explicit]
   public class HappyTests : TestBase<ICatalogClient4Configs>
   {
      [Test]
      public async Task Happy_Case()
      {
         //act
         var result = await SUT().GetElements();

         //assert
         Assert.IsNotNull(result);
         CollectionAssert.IsNotEmpty(result);

         //print
         result.Print();
      }
   }
}