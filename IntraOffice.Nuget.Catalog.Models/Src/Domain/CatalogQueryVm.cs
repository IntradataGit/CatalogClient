using System.Collections.Generic;
using Newtonsoft.Json;

namespace IntraOffice.Nuget.Catalog.Models.Domain
{
   /// <summary>
   ///    Class that represents entity/document query
   /// </summary>
   public class CatalogQueryVm
   {
      [JsonProperty("$query")]
      public CatalogQueryContentVm Query { get; set; }
   }

   /// <summary>
   ///    Content of entity/document query
   /// </summary>
   public class CatalogQueryContentVm
   {
      [JsonProperty("$select")]
      public string[] Select { get; set; }

      [JsonProperty("$orderBy")]
      public string[] OrderBy { get; set; }

      [JsonProperty("$top")]
      public int? Top { get; set; }

      [JsonProperty("$where")]
      public object Where { get; set; }

      #region ctor

      public CatalogQueryContentVm()
      {
         Select = new string[0];
         OrderBy = new string[0];
         Where = new Dictionary<string, string>();
      }

      #endregion
   }
}