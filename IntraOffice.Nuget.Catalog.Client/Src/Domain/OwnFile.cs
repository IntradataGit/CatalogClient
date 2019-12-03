using Newtonsoft.Json;

namespace IntraOffice.Nuget.Catalog.Client.Domain
{
   /// <summary>
   /// Help class that represents file
   /// </summary>
   internal class OwnFile
   {
      /// <summary>
      /// File's binary content
      /// </summary>
      [JsonIgnore]
      public byte[] Content { get; set; }

      /// <summary>
      /// File's mime content type 
      /// </summary>
      public string ContentType { get; set; }
   }
}