using System.Collections.Generic;

namespace IntraOffice.Nuget.Catalog.Models.Domain.DocumentQueries
{
   /// <summary>
   /// This represents metadata of resultset produced document query
   /// </summary>
   public class DocumentSetMetaDataVm
   {
      /// <summary>
      /// Element id's in the query result
      /// </summary>
      public IEnumerable<string> Columns { get; set; }

      /// <summary>
      /// Applied sort expressions
      /// </summary>
      public string[] SortOrder { get; set; }

      /// <summary>
      /// Total number rows in query result
      /// </summary>
      public int TotalNumberRows { get; set; }
   }
}