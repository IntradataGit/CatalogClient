using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.DocumentQueries.SearchWithinDocumentCategory
{
   [Explicit]
   public class HappyTests : TestBase<ICatalogClient4DocumentQueries>
   {
      [Test]
      public async Task Happy_Case()
      {
         //arrange 
         var searchText = "a";
         var categories = this.GetAllCategories();

         foreach (var category in categories)
         {
            //act
            var resultsetLocation = await SUT().FindDocumentsWithinCategory(category.Id, searchText);

            //assert
            Assert.IsFalse(string.IsNullOrEmpty(resultsetLocation));

            //print
            resultsetLocation.Print();
         }
      }
   }
}