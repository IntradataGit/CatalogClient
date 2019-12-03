using System.Net.Http;
using System.Threading.Tasks;

namespace IntraOffice.Nuget.Catalog.Client.Interfaces.Helpers
{
   /// <summary>
   ///    This interface represents help service to send <see cref="HttpRequestMessage" />
   /// </summary>
   internal interface ISendRequest
   {
      Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage);
   }
}