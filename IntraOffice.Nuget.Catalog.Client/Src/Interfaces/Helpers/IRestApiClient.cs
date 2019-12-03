using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Domain;

namespace IntraOffice.Nuget.Catalog.Client.Interfaces.Helpers
{
   /// <summary>
   ///    This interfaces represents help service that can talk to an arbitrary REST API
   /// </summary>
   internal interface IRestApiClient
   {
      Task<HttpResponseMessage> Get(string url, Dictionary<string, string> httpHeaders = null);

      Task<HttpResponseMessage> Post<TModel>(string url, TModel model = null, IEnumerable<OwnFile> files = null, Dictionary<string, string> httpHeaders = null)
         where TModel : class;

      Task<HttpResponseMessage> Put<TModel>(string url, TModel model = null, IEnumerable<OwnFile> files = null, Dictionary<string, string> httpHeaders = null)
         where TModel : class;

      Task<HttpResponseMessage> Patch<TModel>(string url, TModel model = null, Dictionary<string, string> httpHeaders = null)
         where TModel : class;

      Task<HttpResponseMessage> Delete<TModel>(string url, TModel model = null, Dictionary<string, string> httpHeaders = null)
         where TModel : class;
   }
}