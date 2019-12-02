namespace IntraOffice.Nuget.Catalog.Models.Domain.EntityQueries
{
   /// <summary>
   /// This represents single row in resultset produced by entity query
   /// </summary>
   public class EntityRowVm
   {
      /// <summary>
      /// Element values
      /// </summary>
      public object[] Values { get; set; }

      #region ctor

      public EntityRowVm()
      {
         Values = new object[0];
      }

      #endregion
   }
}