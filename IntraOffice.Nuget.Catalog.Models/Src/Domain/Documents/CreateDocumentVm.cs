using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace IntraOffice.Nuget.Catalog.Models.Domain.Documents
{
   /// <summary>
   /// This is model used to add new document to Catalog
   /// </summary>
   public class CreateDocumentVm
   {
      #region ctor

      public CreateDocumentVm()
      {
         Elements = new Dictionary<string, string>();
         Content = new byte[0];
      }

      #endregion

      /// <summary>
      /// Document category id
      /// </summary>
      [Required]
      public string Category { get; set; }

      /// <summary>
      /// Binary content of document file
      /// </summary>
      [JsonIgnore]
      public byte[] Content { get; set; }

      /// <summary>
      /// Document file content type (MIME)
      /// </summary>
      [Required]
      public string ContentType { get; set; }

      /// <summary>
      /// Retention schedule id
      /// </summary>
      public string RetentionScheduleCode { get; set; }

      /// <summary>
      /// Collection of element id / serialized element value
      /// </summary>
      public Dictionary<string, string> Elements { get; set; }
   }
}