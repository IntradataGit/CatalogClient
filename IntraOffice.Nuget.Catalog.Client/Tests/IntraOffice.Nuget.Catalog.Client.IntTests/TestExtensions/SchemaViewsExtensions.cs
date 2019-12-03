using System.Collections.Generic;
using System.Linq;
using IntraOffice.Nuget.Catalog.Models.Domain.Configuration;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions
{
   public static class SchemaViewsExtensions
   {
      public static IEnumerable<string> GetViewNodeIds(this TestBase test, SchemaViewVm view)
      {
         var root = view.Root;

         var result = GetViewNodeIds(test, root).ToArray();

         return result;
      }

      private static IEnumerable<string> GetViewNodeIds(this TestBase test, SchemaViewNodeVm nodeVm)
      {
         yield return nodeVm.Id;

         foreach (var c in nodeVm.Children)
         {
            var viewNodesIds = GetViewNodeIds(test, c).ToArray();

            foreach (var viewNodeId in viewNodesIds)
            {
               yield return viewNodeId;
            }
         }
      }
   }
}