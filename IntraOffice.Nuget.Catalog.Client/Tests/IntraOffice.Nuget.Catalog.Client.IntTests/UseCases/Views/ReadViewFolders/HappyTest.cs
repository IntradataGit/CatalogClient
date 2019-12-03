using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions;
using IntraOffice.Nuget.Catalog.Client.Services;
using IntraOffice.Nuget.Catalog.Models.Domain.Configuration;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.Views.ReadViewFolders
{
   [Explicit]
   public class HappyTest : TestBase<ICatalogClient4Views>
   {
      [Test]
      public async Task Get_All_Folders()
      {
         var viewNodeInfos = GetViewNodeInfos();

         foreach (var viewNodeInfo in viewNodeInfos)
         {
            //act
            var result = await SUT().GetViewNodeById(viewNodeInfo.Item1.Id, viewNodeInfo.Item2);

            //assert
            Assert.IsNotNull(result);

            //print
            result.Print();
         }
      }

      [Test]
      public async Task List_Categories_Assigned_To_Folder()
      {
         var viewNodeInfos = GetViewNodeInfos();

         foreach (var viewNodeInfo in viewNodeInfos)
         {
            //act
            var viewId = viewNodeInfo.Item1.Id;

            var nodeId = viewNodeInfo.Item2;

            ICatalogClient4Views service = new CatalogClient4Views(Settings);

            var categories = await service.GetCategories(viewId, nodeId);

            //assert
            Assert.IsNotNull(categories);
            CollectionAssert.IsNotEmpty(categories);

            //print
            categories.Select(x => x.Id).Print();
         }
      }

      private IEnumerable<Tuple<SchemaViewVm, string>> GetViewNodeInfos()
      {
         var views = this.GetAllViews();

         foreach (var view in views)
         {
            var folderIds = this.GetViewNodeIds(view);

            foreach (var folderId in folderIds)
            {
               yield return new Tuple<SchemaViewVm, string>(view, folderId);
            }
         }
      }
   }
}