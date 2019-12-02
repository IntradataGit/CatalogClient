namespace IntraOffice.Nuget.Catalog.Models.Domain.Documents
{
   /// <summary>
   /// This is help class that represents document event
   /// </summary>
   public class DocumentEventVm
   {
      /// <summary>
      /// Unique id
      /// </summary>
      public long Id { get; set; }

      /// <summary>
      /// Document ticket 
      /// </summary>
      public string DocumentTicket { get; set; }

      /// <summary>
      /// Event id
      /// </summary>
      public string EventName { get; set; }

      /// <summary>
      /// Date when event fired
      /// </summary>
      public string Timestamp { get; set; }

      /// <summary>
      /// Which document version has triggered event
      /// </summary>
      public int DocumentVersion { get; set; }

      /// <summary>
      /// Name of user or process who started event
      /// </summary>
      public string Actor { get; set; }

      /// <summary>
      /// Optional user comment (only for actions triggered by end user directly)
      /// </summary>
      public string Text { get; set; }
   }
}