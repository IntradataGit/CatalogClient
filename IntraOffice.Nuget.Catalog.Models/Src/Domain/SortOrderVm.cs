namespace IntraOffice.Nuget.Catalog.Models.Domain
{
   /// <summary>
   /// This model represents sorting expressions that should be applied to the query result
   /// </summary>
   public class SortOrderVm
   {
      /// <summary>
      /// Collection of sort expressions in form of "element name ASC/DESC" pairs
      /// </summary>
      public string[] OrderBy { get; set; }
   }
}