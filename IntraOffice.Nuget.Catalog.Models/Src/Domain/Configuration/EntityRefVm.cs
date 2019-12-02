namespace IntraOffice.Nuget.Catalog.Models.Domain.Configuration
{
   /// <summary>
   /// This is help class that wraps entity id and usage information
   /// </summary>
   public class EntityRefVm
   {
      /// <summary>
      /// Entity id
      /// </summary>
      public string Entity { get; set; }

      /// <summary>
      /// This is short description about entity usage
      /// </summary>
      public string Use { get; set; }
   }
}