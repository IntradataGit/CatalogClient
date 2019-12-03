using System.ComponentModel.DataAnnotations;

namespace IntraOffice.Nuget.Catalog.Client.Configuration
{
   public class CatalogClientSettings
   {
      /// <summary>
      ///  Url address of Catalog API (Required)
      /// </summary>
      [Required]
      public string ApiUrl { get; set; }

      /// <summary>
      ///    Jwt token needed to access Catalog API (Optional)
      /// </summary>
      public string AuthToken { get; set; }

      /// <summary>
      ///  Tenant identifier (Optional)
      /// </summary>
      public string TenantId { get; set; }
   }
}