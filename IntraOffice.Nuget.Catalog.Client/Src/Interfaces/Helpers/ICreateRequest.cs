using System.Collections.Generic;
using System.Net.Http;
using IntraOffice.Nuget.Catalog.Client.Domain;

namespace IntraOffice.Nuget.Catalog.Client.Interfaces.Helpers
{
   /// <summary>
   ///    This interface represents help service to create <see cref="HttpRequestMessage" />
   /// </summary>
   internal interface ICreateRequest
   {
      HttpRequestMessage Create(HttpMethod httpMethod, string url, Dictionary<string, string> httpHeaders = null);

      HttpRequestMessage Create<TModel>(HttpMethod httpMethod, string url, TModel model = null, IEnumerable<OwnFile> files = null, Dictionary<string, string> httpHeaders = null)
         where TModel : class;
   }
}