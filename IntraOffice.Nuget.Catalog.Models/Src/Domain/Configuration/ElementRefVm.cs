namespace IntraOffice.Nuget.Catalog.Models.Domain.Configuration
{
   /// <summary>
   /// This is help class that wraps element id and information about element usage
   /// </summary>
   public class ElementRefVm
   {
      /// <summary>
      /// Element id
      /// </summary>
      public string Element { get; set; }

      /// <summary>
      /// This is short description about element usage
      /// </summary>
      public string Use { get; set; }
   }
}