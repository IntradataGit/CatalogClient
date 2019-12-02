namespace IntraOffice.Nuget.Catalog.Models.Domain.Documents.Annotations
{
   /// <summary>
   /// This represents update model for document annotations
   /// </summary>
   public class UpdateAnnotationVm
   {
      /// <summary>
      /// New text of the annotation
      /// </summary>
      public string Text { get; set; }

      /// <summary>
      /// Is the annotation public
      /// </summary>
      public bool IsPublic { get; set; }
   }
}