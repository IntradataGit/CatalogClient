namespace IntraOffice.Nuget.Catalog.Models.Domain.Configuration
{
   /// <summary>
   ///    This class represents an event in Catalog
   /// </summary>
   public class EventVm
   {
      /// <summary>
      ///    Unique id
      /// </summary>
      public string Id { get; set; }

      /// <summary>
      ///    User friendly display name
      /// </summary>
      public string Title { get; set; }
   }
}