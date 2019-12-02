namespace IntraOffice.Nuget.Catalog.Models.Domain.Configuration
{
   /// <summary>
   /// This represents view
   /// </summary>
   public class SchemaViewVm 
   {
      /// <summary>
      /// Unique id
      /// </summary>
      public string Id { get; set; }

      /// <summary>
      /// Top node of related tree menu
      /// </summary>
      public SchemaViewNodeVm Root { get; set; }
   }
}