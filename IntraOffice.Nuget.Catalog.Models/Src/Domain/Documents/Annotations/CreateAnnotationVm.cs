namespace IntraOffice.Nuget.Catalog.Models.Domain.Documents.Annotations
{
   /// <summary>
   /// This represents create model for document annotations
   /// </summary>
   public class CreateAnnotationVm
   {
      /// <summary>
      /// Text of the annotation
      /// </summary>
      public string Text { get; set; }

      /// <summary>
      /// Is the annotation public
      /// </summary>
      public bool IsPublic { get; set; }
   }
}