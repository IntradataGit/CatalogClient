using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.Views.GetSpecificView
{
   [Explicit]
   public class HappyTests : TestBase<ICatalogClient4Views>
   {
      [Test]
      public async Task Happy_Case()
      {
         //arrange
         var views = this.GetAllViews();

         foreach (var view in views)
         {
            //act
            var result = await SUT().GetViewById(view.Id);

            //assert
            Assert.IsNotNull(result);

            //print
            result.Print();
         }
      }
   }
}