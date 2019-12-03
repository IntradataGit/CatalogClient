using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Domain;
using IntraOffice.Nuget.Catalog.Client.Interfaces.Helpers;

namespace IntraOffice.Nuget.Catalog.Client.Services.Helpers
{
   /// <summary>
   ///    Implementation of <see cref="IDeserializeResponse" />
   /// </summary>
   internal class DeserializeResponseService : IDeserializeResponse
   {
      private readonly ISerializeObject _serializeObjectService;

      #region ctor

      public DeserializeResponseService() : this(new SerializeObjectService())
      {
      }

      internal DeserializeResponseService(ISerializeObject serializeObjectService)
      {
         _serializeObjectService = serializeObjectService;
      }

      #endregion

      public async Task<ResponseVm> Deserialize(HttpResponseMessage httpResponseMessage)
      {
         var responseVm = new ResponseVm
         {
            LocationHeader = TryGetHeaderValue(httpResponseMessage, "Location"),
            ResponseBody = await httpResponseMessage.Content.ReadAsStringAsync()
         };

         return responseVm;
      }

      public async Task<OwnFile> DeserializeFile(HttpResponseMessage httpResponseMessage)
      {
         var bytes = await httpResponseMessage.Content.ReadAsByteArrayAsync();
         return new OwnFile {Content = bytes};
      }

      public async Task<TObject> DeserializeObject<TObject>(HttpResponseMessage httpResponseMessage)
      {
         var responseContent = await httpResponseMessage.Content.ReadAsStringAsync();
         return _serializeObjectService.DeserializeObject<TObject>(responseContent);
      }

      public static string TryGetHeaderValue(HttpResponseMessage httpResponseMessage, string headerName)
      {
         var httpResponseHeaders = httpResponseMessage.Headers;

         if (!httpResponseHeaders.Contains(headerName))
         {
            return string.Empty;
         }

         var values = httpResponseHeaders.GetValues(headerName);
         return values.FirstOrDefault() ?? string.Empty;
      }
   }
}