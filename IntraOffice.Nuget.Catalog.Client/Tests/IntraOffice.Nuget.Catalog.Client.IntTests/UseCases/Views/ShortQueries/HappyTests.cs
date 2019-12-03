using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions;
using IntraOffice.Nuget.Catalog.Client.Services;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.Views.ShortQueries
{
   [Explicit]
   public class HappyTests : TestBase<ICatalogClient4Views>
   {
      [Test]
      public async Task Happy_Case()
      {
         var views = this.GetAllViews();

         foreach (var view in views)
         {
            var viewNodeIds = this.GetViewNodeIds(view);

            foreach (var viewNodeId in viewNodeIds)
            {
               //act
               var viewId = view.Id;
               var searchText = "a";

               ICatalogClient4Views service = new CatalogClient4Views(Settings);

               var queryResultTicket = await service.FindDocuments(viewId, viewNodeId, searchText);

               //assert
               Assert.IsFalse(string.IsNullOrEmpty(queryResultTicket));

               //print
               queryResultTicket.Print();
            }
         }
      }
   }
}