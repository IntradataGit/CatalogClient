namespace IntraOffice.Nuget.Catalog.Models.Domain.Documents.Versions
{
   /// <summary>
   ///    This represents read model for document version
   /// </summary>
   public class DocumentVersionVm
   {
      /// <summary>
      ///    Version ticket
      /// </summary>
      public string Ticket { get; set; }

      /// <summary>
      ///    Version number
      /// </summary>
      public int Version { get; set; }

      /// <summary>
      ///    Document content type
      /// </summary>
      public string ContentType { get; set; }

      /// <summary>
      ///    Date document has been created
      /// </summary>
      public string DateCreated { get; set; }

      /// <summary>
      ///    Date version has been last modified
      /// </summary>
      public string DateLastModified { get; set; }

      /// <summary>
      ///    Name of user/process who created the version
      /// </summary>
      public string Creator { get; set; }

      /// <summary>
      ///    Is version annotated
      /// </summary>
      public bool IsAnnotated { get; set; }
   }
}