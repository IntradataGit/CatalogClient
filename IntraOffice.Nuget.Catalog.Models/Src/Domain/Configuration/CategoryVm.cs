namespace IntraOffice.Nuget.Catalog.Models.Domain.Configuration
{
   /// <summary>
   ///    This class represents 'document category'
   /// </summary>
   public class CategoryVm
   {
      /// <summary>
      ///    Unique identifier
      /// </summary>
      public string Id { get; set; }

      /// <summary>
      ///    User friendly name
      /// </summary>
      public string Title { get; set; }

      /// <summary>
      ///    Id of parent document class
      /// </summary>
      public string Class { get; set; }

      /// <summary>
      ///    Relative URL of parent document class
      /// </summary>
      public string ClassUrl { get; set; }

      /// <summary>
      ///    Short description how to use category
      /// </summary>
      public string Use { get; set; }
   }
}