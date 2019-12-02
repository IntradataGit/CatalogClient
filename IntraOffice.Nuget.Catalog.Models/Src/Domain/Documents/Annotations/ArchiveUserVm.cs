namespace IntraOffice.Nuget.Catalog.Models.Domain.Documents.Annotations
{
   /// <summary>
   /// This is help class that represents a person who created an annotation
   /// </summary>
   public class ArchiveUserVm
   {
      /// <summary>
      /// Username
      /// </summary>
      public string Identity { get; set; }
      
      /// <summary>
      /// User's first name
      /// </summary>
      public string FirstName { get; set; }
      
      /// <summary>
      /// User's middle name
      /// </summary>
      public string MiddleName { get; set; }

      /// <summary>
      /// User's last name
      /// </summary>
      public string LastName { get; set; }

      /// <summary>
      /// User's display name
      /// </summary>
      public string FullName { get; set; }
   }
}