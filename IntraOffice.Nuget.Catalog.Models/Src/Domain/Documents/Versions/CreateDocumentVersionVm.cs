namespace IntraOffice.Nuget.Catalog.Models.Domain.Documents.Versions
{
   /// <summary>
   /// This represents create new document version model
   /// </summary>
   public class CreateDocumentVersionVm
   {
      /// <summary>
      /// Binary content of the updated document file
      /// </summary>
      public byte[] Content { get; set; }

      /// <summary>
      /// Content type of the document file
      /// </summary>
      public string ContentType { get; set; }

      /// <summary>
      /// Should document annotations should be copied from the
      /// previous version. Defaults to false.
      /// </summary>
      public bool? CopyAnnotations { get; set; }
   }
}