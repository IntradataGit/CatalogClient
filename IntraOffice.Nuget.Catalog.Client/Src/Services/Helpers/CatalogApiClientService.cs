using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Configuration;
using IntraOffice.Nuget.Catalog.Client.Domain;
using IntraOffice.Nuget.Catalog.Client.Interfaces.Helpers;

namespace IntraOffice.Nuget.Catalog.Client.Services.Helpers
{
   /// <summary>
   ///    Implementation of <see cref="ICatalogApiClient" />
   /// </summary>
   internal class CatalogApiClientService : ICatalogApiClient
   {
      private readonly IRestApiClient _innerService;
      private readonly CatalogClientSettings _clientSettings;
      private readonly IDeserializeResponse _deserializeResponseService;

      #region ctor

      public CatalogApiClientService(CatalogClientSettings clientSettings) : this(clientSettings, new RestApiClientService(), new DeserializeResponseService())
      {
      }

      internal CatalogApiClientService(CatalogClientSettings clientSettings, IRestApiClient innerService, IDeserializeResponse deserializeResponseService)
      {
         _deserializeResponseService = deserializeResponseService ?? throw new ArgumentNullException(nameof(deserializeResponseService));
         _clientSettings = clientSettings ?? throw new ArgumentNullException(nameof(clientSettings));
         _innerService = innerService ?? throw new ArgumentNullException(nameof(innerService));
      }

      #endregion

      public async Task<TObject> GetModel<TObject>(string relativeUrl, string language)
      {
         var fullUrl = BuildUrl(relativeUrl);
         var httpHeaders = BuildHttpHeaders(language);
         var httpResponseMessage = await _innerService.Get(fullUrl, httpHeaders);
         return await _deserializeResponseService.DeserializeObject<TObject>(httpResponseMessage);
      }

      public async Task<OwnFile> GetFile(string relativeUrl, string language)
      {
         var fullUrl = BuildUrl(relativeUrl);
         var httpHeaders = BuildHttpHeaders(language);
         var httpResponseMessage = await _innerService.Get(fullUrl, httpHeaders);
         var result = await _deserializeResponseService.DeserializeFile(httpResponseMessage);
         return result;
      }

      public async Task<ResponseVm> Post(string relativeUrl, string language)
      {
         var fullUrl = BuildUrl(relativeUrl);
         var httpHeaders = BuildHttpHeaders(language);
         var httpResponseMessage = await _innerService.Post<object>(fullUrl, httpHeaders: httpHeaders);
         var responseVm = await _deserializeResponseService.Deserialize(httpResponseMessage);
         return responseVm;
      }

      public async Task<ResponseVm> Post<TModel>(string relativeUrl, TModel model, string language) where TModel : class
      {
         var fullUrl = BuildUrl(relativeUrl);
         var httpHeaders = BuildHttpHeaders(language);
         var httpResponseMessage = await _innerService.Post(fullUrl, model, null, httpHeaders);
         var responseVm = await _deserializeResponseService.Deserialize(httpResponseMessage);
         return responseVm;
      }

      public async Task<ResponseVm> Post<TModel>(string relativeUrl, TModel model, IEnumerable<OwnFile> files, string language) where TModel : class
      {
         var fullUrl = BuildUrl(relativeUrl);
         var httpHeaders = BuildHttpHeaders(language);
         var httpResponseMessage = await _innerService.Post(fullUrl, model, files, httpHeaders);
         var responseVm = await _deserializeResponseService.Deserialize(httpResponseMessage);
         return responseVm;
      }

      public async Task Put<TModel>(string relativeUrl, TModel model, string language) where TModel : class
      {
         var fullUrl = BuildUrl(relativeUrl);
         var httpHeaders = BuildHttpHeaders(language);
         await _innerService.Put(fullUrl, model, null, httpHeaders);
      }

      public async Task<ResponseVm> Put<TModel>(string relativeUrl, TModel model, IEnumerable<OwnFile> files, string language) where TModel : class
      {
         var fullUrl = BuildUrl(relativeUrl);
         var httpHeaders = BuildHttpHeaders(language);
         var httpResponseMessage = await _innerService.Put(fullUrl, model, files, httpHeaders);
         var responseVm2 = await _deserializeResponseService.Deserialize(httpResponseMessage);
         return responseVm2;
      }

      public Task Patch<TModel>(string relativeUrl, TModel model, string language) where TModel : class
      {
         var fullUrl = BuildUrl(relativeUrl);
         var httpHeaders = BuildHttpHeaders(language);
         return _innerService.Patch(fullUrl, model, httpHeaders);
      }

      public Task Delete(string relativeUrl, string language)
      {
         var fullUrl = BuildUrl(relativeUrl);
         var httpHeaders = BuildHttpHeaders(language);
         return _innerService.Delete<object>(fullUrl, null, httpHeaders);
      }

      #region Help methods

      private string BuildUrl(string relativeUrl)
      {
         return $"{_clientSettings.ApiUrl}{relativeUrl}";
      }

      private Dictionary<string, string> BuildHttpHeaders(string language)
      {
         var headers = new Dictionary<string, string>
         {
            {"Accept-Language", language}
         };

         if (!string.IsNullOrEmpty(_clientSettings.AuthToken))
         {
            headers.Add("Authorization", $"Bearer {_clientSettings.AuthToken}");
         }

         if (!string.IsNullOrEmpty(_clientSettings.TenantId))
         {
            headers.Add("X-Tenant", _clientSettings.TenantId);
         }

         return headers;
      }

      #endregion
   }
}