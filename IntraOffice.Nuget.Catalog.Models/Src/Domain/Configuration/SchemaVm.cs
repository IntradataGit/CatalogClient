using System.ComponentModel.DataAnnotations;

namespace IntraOffice.Nuget.Catalog.Models.Domain.Configuration
{
   /// <summary>
   /// This class represent catalog schema
   /// </summary>
   public class SchemaVm
   {
      /// <summary>
      /// Unique id
      /// </summary>
      [Required]
      public string Id { get; set; }

      /// <summary>
      /// Display name
      /// </summary>
      [Required]
      public string Title { get; set; }

      [Required]
      public string CategoriesUrl { get; } = "/schema/categories";

      [Required]
      public string ClassesUrl { get; } = "/schema/classes";

      [Required]
      public string EntitiesUrl { get; } = "/schema/entities";

      [Required]
      public string ElementsUrl { get; } = "/schema/elements";

      [Required]
      public string EventsUrl { get; } = "/schema/events";
   }
}