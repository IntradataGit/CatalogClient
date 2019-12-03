using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions;
using IntraOffice.Nuget.Catalog.Client.Services;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.Views.GetAllViews
{
   [Explicit]
   public class HappyTests : TestBase<ICatalogClient4Views>
   {
      [Test]
      public async Task Happy_Case()
      {
         //act
         ICatalogClient4Views service = new CatalogClient4Views(Settings);

         var views = await service.GetAllViews();

         //assert
         Assert.IsNotNull(views);

         //print
         views.Print();
      }
   }
}