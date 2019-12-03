using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Configuration;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Client.Interfaces.Helpers;
using IntraOffice.Nuget.Catalog.Client.Services.Helpers;
using IntraOffice.Nuget.Catalog.Models.Domain.Configuration;

namespace IntraOffice.Nuget.Catalog.Client.Services
{
   public class CatalogClient4Views : ICatalogClient4Views
   {
      private readonly ICatalogApiClient _catalogApiHttpService;

      #region ctor

      public CatalogClient4Views(CatalogClientSettings clientSettings) : this(new CatalogApiClientService(clientSettings))
      {
      }

      internal CatalogClient4Views(ICatalogApiClient catalogApiHttpService)
      {
         _catalogApiHttpService = catalogApiHttpService ?? throw new ArgumentNullException(nameof(catalogApiHttpService));
      }

      #endregion

      public async Task<IEnumerable<SchemaViewVm>> GetAllViews(string language)
      {
         var result = await _catalogApiHttpService.GetModel<IEnumerable<SchemaViewVm>>("/views/schema", language);

         return result;
      }

      public async Task<SchemaViewVm> GetViewById(string viewId, string language)
      {
         if (string.IsNullOrEmpty(viewId))
         {
            throw new ArgumentNullException(nameof(viewId));
         }

         var result = await _catalogApiHttpService.GetModel<SchemaViewVm>($"/views/schema/{viewId}", language);

         return result;
      }

      public async Task<SchemaViewNodeVm> GetViewNodeById(string viewId, string viewNodeId, string language)
      {
         if (string.IsNullOrEmpty(viewId))
         {
            throw new ArgumentNullException(nameof(viewId));
         }

         if (string.IsNullOrEmpty(viewNodeId))
         {
            throw new ArgumentNullException(nameof(viewNodeId));
         }

         var result = await _catalogApiHttpService.GetModel<SchemaViewNodeVm>($"/views/schema/{viewId}/{viewNodeId}", language);

         return result;
      }

      public async Task<IEnumerable<CategoryVm>> GetCategories(string viewId, string viewNodeId, string language)
      {
         if (string.IsNullOrEmpty(viewId))
         {
            throw new ArgumentNullException(nameof(viewId));
         }

         if (string.IsNullOrEmpty(viewNodeId))
         {
            throw new ArgumentNullException(nameof(viewNodeId));
         }

         var result = await _catalogApiHttpService.GetModel<IEnumerable<CategoryVm>>($"/views/schema/{viewId}/{viewNodeId}/categories", language);

         return result;
      }

      public async Task<string> FindDocuments(string viewId, string viewNodeId, string searchText, string language)
      {
         if (string.IsNullOrEmpty(viewId))
         {
            throw new ArgumentNullException(nameof(viewId));
         }

         if (string.IsNullOrEmpty(viewNodeId))
         {
            throw new ArgumentNullException(nameof(viewNodeId));
         }

         if (string.IsNullOrEmpty(searchText))
         {
            throw new ArgumentNullException(nameof(searchText));
         }

         var responseVm = await _catalogApiHttpService.Post($"/views/schema/{viewId}/{viewNodeId}/query?searchText={searchText}", language);
         var queryResultTicket = responseVm.LocationHeader.Split('/').Last();
         return queryResultTicket;
      }
   }
}