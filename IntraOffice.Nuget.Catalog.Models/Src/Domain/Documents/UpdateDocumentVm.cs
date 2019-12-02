using System.Collections.Generic;

namespace IntraOffice.Nuget.Catalog.Models.Domain.Documents
{
   /// <summary>
   /// This class represents update model for document metadata
   /// </summary>
   public class UpdateDocumentVm
   {
      #region ctor

      public UpdateDocumentVm()
      {
         Elements = new Dictionary<string, string>();
      }

      #endregion

      /// <summary>
      /// New retention schedule id (Optional)
      /// </summary>
      public string RetentionScheduleCode { get; set; }

      /// <summary>
      /// Collection of element id / serialized element value pairs for
      /// those elements that need to be inserted/updated.
      /// </summary>
      public Dictionary<string, string> Elements { get; set; }
   }
}