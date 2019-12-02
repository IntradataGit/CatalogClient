namespace IntraOffice.Nuget.Catalog.Models.Domain.Documents.Annotations
{
   /// <summary>
   ///    This represents read model for document annotations
   /// </summary>
   public class AnnotationVm
   {
      /// <summary>
      /// Annotation ticket
      /// </summary>
      public string Ticket { get; set; }

      /// <summary>
      /// User who created/updated annotation
      /// </summary>
      public ArchiveUserVm Author { get; set; }

      /// <summary>
      /// Date annotation is created
      /// </summary>
      public string DateCreated { get; set; }

      /// <summary>
      /// Date annotation is modified
      /// </summary>
      public string DateModified { get; set; }

      /// <summary>
      /// Text of the annotation
      /// </summary>
      public string Text { get; set; }

      /// <summary>
      /// Is annotation public
      /// </summary>
      public bool IsPublic { get; set; }
   }
}