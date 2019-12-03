using System.ComponentModel.DataAnnotations;

namespace IntraOffice.Nuget.Catalog.Models.Domain.Configuration
{
   /// <summary>
   /// This class represents 'document category'
   /// </summary>
   public class CategoryVm 
   {
      /// <summary>
      /// Unique identifier
      /// </summary>
      [Required]
      public string Id { get; set; }

      /// <summary>
      /// User friendly name 
      /// </summary>
      [Required]
      public string Title { get; set; }

      /// <summary>
      /// Id of parent document class
      /// </summary>
      [Required]
      public string Class { get; set; }

      /// <summary>
      /// Relative URL of parent document class
      /// </summary>
      [Required]
      public string ClassUrl { get; set; }

      public string Use { get; set; }
   }
}