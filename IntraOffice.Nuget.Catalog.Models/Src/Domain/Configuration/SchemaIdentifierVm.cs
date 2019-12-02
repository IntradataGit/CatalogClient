using System.Collections.Generic;

namespace IntraOffice.Nuget.Catalog.Models.Domain.Configuration
{
   /// <summary>
   /// This is help class that wraps a collection of element id's and description about its usage
   /// </summary>
   public class SchemaIdentifierVm
   {
      /// <summary>
      /// Element id's
      /// </summary>
      public IEnumerable<string> Elements { get; set; }

      /// <summary>
      /// Short description about usage of those elements
      /// </summary>
      public string Use { get; set; }
   }
}