using System.Collections.Generic;

namespace IntraOffice.Nuget.Catalog.Models.Domain.Configuration
{
   /// <summary>
   /// This represents view node
   /// </summary>
   public class SchemaViewNodeVm 
   {
      #region ctor

      public SchemaViewNodeVm()
      {
         Children = new SchemaViewNodeVm[0];
      }

      #endregion

      /// <summary>
      /// Node's id within parent view
      /// </summary>
      public string Id { get; set; }

      public string Display { get; set; }

      public string QueryView { get; set; }

      public string ResultsView { get; set; }

      /// <summary>
      /// Description
      /// </summary>
      public string Description { get; set; }

      /// <summary>
      /// Child nodes
      /// </summary>
      public IEnumerable<SchemaViewNodeVm> Children { get; set; }
   }
}