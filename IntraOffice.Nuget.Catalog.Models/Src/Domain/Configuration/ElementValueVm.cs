namespace IntraOffice.Nuget.Catalog.Models.Domain.Configuration
{
   /// <summary>
   /// This is help class that wraps element id and element value
   /// </summary>
   public class ElementValueVm
   {
      /// <summary>
      /// Element id
      /// </summary>
      public string Name { get; set; }

      /// <summary>
      /// Element value
      /// </summary>
      public object Value { get; set; }
   }
}