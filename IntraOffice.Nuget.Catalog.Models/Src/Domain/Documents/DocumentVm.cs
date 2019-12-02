using System.Collections.Generic;
using IntraOffice.Nuget.Catalog.Models.Domain.Configuration;

namespace IntraOffice.Nuget.Catalog.Models.Domain.Documents
{
   /// <summary>
   /// This represents document metadata read model
   /// </summary>
   public class DocumentVm
   {
      #region ctor

      public DocumentVm()
      {
         Elements = new ElementValueVm[0];
      }

      #endregion

      /// <summary>
      /// Document category id
      /// </summary>
      public string Category { get; set; }

      /// <summary>
      /// Collection of elements and their values
      /// </summary>
      public IEnumerable<ElementValueVm> Elements { get; set; }

      /// <summary>
      /// Document content type
      /// </summary>
      public string ContentType { get; set; }

      /// <summary>
      /// Document ticket
      /// </summary>
      public string Ticket { get; set; }

      /// <summary>
      /// Document version
      /// </summary>
      public int Version { get; set; }

      /// <summary>
      /// Date document is created
      /// </summary>
      public string DateCreated { get; set; }

      /// <summary>
      /// Date document is modified
      /// </summary>
      public string DateLastModified { get; set; }

      /// <summary>
      /// Date document is deleted
      /// </summary>
      public string DateDeleted { get; set; }

      /// <summary>
      /// Date document is destroyed
      /// </summary>
      public string DateDestroyed { get; set; }

      /// <summary>
      /// Does this document have annotations
      /// </summary>
      public bool IsAnnotated { get; set; }

      /// <summary>
      /// Is this document deleted?
      /// </summary>
      public bool IsDeleted { get; set; }

      /// <summary>
      /// Is this document destroyed?
      /// </summary>
      public bool IsDestroyed { get; set; }

      /// <summary>
      /// Is this document in recycle bin?
      /// </summary>
      public bool InRecycleBin { get; set; }

      /// <summary>
      /// Retention schedule id
      /// </summary>
      public string RetentionScheduleCode { get; set; }
   }
}