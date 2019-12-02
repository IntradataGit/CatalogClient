using System.Collections.Generic;

namespace IntraOffice.Nuget.Catalog.Models.Domain.Configuration
{
   /// <summary>
   /// This represents retention schedule
   /// </summary>
   public class RetentionScheduleVm
   {
      /// <summary>
      /// Unique id
      /// </summary>
      public string Code { get; set; }

      /// <summary>
      /// Description
      /// </summary>
      public string Description { get; set; }

      /// <summary>
      /// Id of default retention period
      /// </summary>
      public string DefaultPeriod { get; set; }

      /// <summary>
      /// Collection of document 'category id' / 'retention period id' pairs
      /// </summary>
      public IDictionary<string, string> Documents { get; set; }
   }
}