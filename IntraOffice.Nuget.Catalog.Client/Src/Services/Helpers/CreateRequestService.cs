using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using IntraOffice.Nuget.Catalog.Client.Domain;
using IntraOffice.Nuget.Catalog.Client.Interfaces.Helpers;

namespace IntraOffice.Nuget.Catalog.Client.Services.Helpers
{
   /// <summary>
   ///    Implementation of <see cref="ICreateRequest" />
   /// </summary>
   internal class CreateRequestService : ICreateRequest
   {
      private readonly ISerializeObject _serializeObjectService;

      #region ctor

      public CreateRequestService() : this(new SerializeObjectService())
      {
      }

      internal CreateRequestService(ISerializeObject serializeObjectService)
      {
         _serializeObjectService = serializeObjectService;
      }

      #endregion

      public HttpRequestMessage Create(HttpMethod httpMethod, string url, Dictionary<string, string> httpHeaders)
      {
         var httpRequestMessage = new HttpRequestMessage(httpMethod, url);

         if (httpHeaders != null)
         {
            foreach (var httpHeader in httpHeaders)
            {
               httpRequestMessage.Headers.Add(httpHeader.Key, httpHeader.Value);
            }
         }

         return httpRequestMessage;
      }

      public HttpRequestMessage Create<TModel>(HttpMethod httpMethod, string url, TModel model = null, IEnumerable<OwnFile> files = null, Dictionary<string, string> httpHeaders = null)
         where TModel : class
      {
         var jsonText = _serializeObjectService.SerializeObject(model);
         var httpRequestMessage = Create(httpMethod, url, httpHeaders);
         httpRequestMessage.Content = files == null ? CreateHttpContent(jsonText) : CreateHttpContent(jsonText, files);
         return httpRequestMessage;
      }

      private static HttpContent CreateHttpContent(string jsonText)
      {
         var httpContent = ToHttpContent(jsonText);
         return httpContent;
      }

      private static HttpContent CreateHttpContent(string jsonText, IEnumerable<OwnFile> files)
      {
         var httpContent = new MultipartFormDataContent();

         var stringContent = ToHttpContent(jsonText);

         if (stringContent != null)
         {
            httpContent.Add(stringContent);
         }

         if (files != null)
         {
            foreach (var ownFile in files)
            {
               var byteContent = ToHttpContent(ownFile);
               httpContent.Add(byteContent);
            }
         }

         return httpContent;
      }

      private static StringContent ToHttpContent(string jsonText)
      {
         if (string.IsNullOrEmpty(jsonText))
         {
            return null;
         }

         var httpContent = new StringContent(jsonText, Encoding.UTF8, "application/json");
         return httpContent;
      }

      private static ByteArrayContent ToHttpContent(OwnFile ownFile)
      {
         var httpContent = new ByteArrayContent(ownFile.Content);
         httpContent.Headers.ContentType = new MediaTypeHeaderValue(ownFile.ContentType);
         return httpContent;
      }
   }
}