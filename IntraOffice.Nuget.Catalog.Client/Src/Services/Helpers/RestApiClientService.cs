using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Domain;
using IntraOffice.Nuget.Catalog.Client.Interfaces.Helpers;

namespace IntraOffice.Nuget.Catalog.Client.Services.Helpers
{
   /// <summary>
   ///    Implementation of <see cref="IRestApiClient" />
   /// </summary>
   internal class RestApiClientService : IRestApiClient
   {
      private readonly ISendRequest _sendRequestService;
      private readonly ICreateRequest _createRequestService;

      #region ctor

      public RestApiClientService() : this(new CreateRequestService(), new SendRequestService())
      {
      }

      internal RestApiClientService(ICreateRequest createRequestService, ISendRequest sendRequestService)
      {
         _createRequestService = createRequestService;
         _sendRequestService = sendRequestService;
      }

      #endregion

      public async Task<HttpResponseMessage> Get(string url, Dictionary<string, string> httpHeaders)
      {
         var httpRequestMessage = _createRequestService.Create(HttpMethod.Get, url, httpHeaders);
         var httpResponseMessage = await _sendRequestService.SendAsync(httpRequestMessage);
         return httpResponseMessage;
      }

      public async Task<HttpResponseMessage> Post<TModel>(string url, TModel model, IEnumerable<OwnFile> files, Dictionary<string, string> httpHeaders)
         where TModel : class
      {
         var httpRequestMessage = _createRequestService.Create(HttpMethod.Post, url, model, files, httpHeaders);
         var httpResponseMessage = await _sendRequestService.SendAsync(httpRequestMessage);
         return httpResponseMessage;
      }

      public async Task<HttpResponseMessage> Put<TModel>(string url, TModel model, IEnumerable<OwnFile> files, Dictionary<string, string> httpHeaders)
         where TModel : class
      {
         var httpRequestMessage = _createRequestService.Create(HttpMethod.Put, url, model, files, httpHeaders);
         var httpResponseMessage = await _sendRequestService.SendAsync(httpRequestMessage);
         return httpResponseMessage;
      }

      public async Task<HttpResponseMessage> Patch<TModel>(string url, TModel model, Dictionary<string, string> httpHeaders)
         where TModel : class
      {
         var httpRequestMessage = _createRequestService.Create(new HttpMethod("Patch"), url, model, null, httpHeaders);
         var httpResponseMessage = await _sendRequestService.SendAsync(httpRequestMessage);
         return httpResponseMessage;
      }

      public async Task<HttpResponseMessage> Delete<TModel>(string url, TModel model, Dictionary<string, string> httpHeaders) where TModel : class
      {
         var httpRequestMessage = _createRequestService.Create(HttpMethod.Delete, url, model, null, httpHeaders);
         var httpResponseMessage = await _sendRequestService.SendAsync(httpRequestMessage);
         return httpResponseMessage;
      }
   }
}