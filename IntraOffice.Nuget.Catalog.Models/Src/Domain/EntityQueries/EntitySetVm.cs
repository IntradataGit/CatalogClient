using System.Collections.Generic;

namespace IntraOffice.Nuget.Catalog.Models.Domain.EntityQueries
{
   /// <summary>
   /// This represents a help class that wraps query result metadata and data rows
   /// </summary>
   public class EntitySetVm
   {
      /// <summary>
      /// Query result metadata
      /// </summary>
      public EntitySetMetaDataVm Metadata { get; set; }

      /// <summary>
      /// Data rows
      /// </summary>
      public IEnumerable<EntityRowVm> Rows { get; set; }
   }
}