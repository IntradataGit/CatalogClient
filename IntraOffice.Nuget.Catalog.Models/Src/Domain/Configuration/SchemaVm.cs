namespace IntraOffice.Nuget.Catalog.Models.Domain.Configuration
{
   /// <summary>
   ///    This class represent catalog schema
   /// </summary>
   public class SchemaVm
   {
      /// <summary>
      ///    Unique id
      /// </summary>
      public string Id { get; set; }

      /// <summary>
      ///    Display name
      /// </summary>
      public string Title { get; set; }

      public string CategoriesUrl { get; } = "/schema/categories";

      public string ClassesUrl { get; } = "/schema/classes";

      public string EntitiesUrl { get; } = "/schema/entities";

      public string ElementsUrl { get; } = "/schema/elements";

      public string EventsUrl { get; } = "/schema/events";
   }
}