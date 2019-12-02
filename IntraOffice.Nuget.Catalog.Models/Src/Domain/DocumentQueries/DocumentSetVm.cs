using System.Collections.Generic;

namespace IntraOffice.Nuget.Catalog.Models.Domain.DocumentQueries
{
   /// <summary>
   /// This represents a help class that wraps query result metadata and data rows
   /// </summary>
   public class DocumentSetVm
   {
      /// <summary>
      /// Query result metadata
      /// </summary>
      public DocumentSetMetaDataVm Metadata { get; set; }

      /// <summary>
      /// Data rows
      /// </summary>
      public IEnumerable<DocumentRowVm> Rows { get; set; }
   }
}