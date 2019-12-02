namespace IntraOffice.Nuget.Catalog.Models.Domain.DocumentQueries
{
   /// <summary>
   /// This represents single row in resultset produced by document query
   /// </summary>
   public class DocumentRowVm
   {
      /// <summary>
      /// Ticket of document that row represents
      /// </summary>
      public string Ticket { get; set; }

      /// <summary>
      /// Document class id of that document
      /// </summary>
      public string ClassName { get; set; }

      /// <summary>
      /// Document category id of that document
      /// </summary>
      public string DocumentName { get; set; }

      /// <summary>
      /// Document content type
      /// </summary>
      public string ContentType { get; set; }

      /// <summary>
      /// Element values
      /// </summary>
      public object[] Values { get; set; }

      #region ctor

      public DocumentRowVm()
      {
         Values = new object[0];
      }

      #endregion
   }
}