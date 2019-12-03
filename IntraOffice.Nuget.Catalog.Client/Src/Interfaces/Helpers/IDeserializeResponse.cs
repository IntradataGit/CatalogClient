using System.Net.Http;
using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Domain;

namespace IntraOffice.Nuget.Catalog.Client.Interfaces.Helpers
{
   /// <summary>
   ///    This interface represents help service to deserialize <see cref="HttpResponseMessage" /> into more appropriate object
   /// </summary>
   internal interface IDeserializeResponse
   {
      Task<ResponseVm> Deserialize(HttpResponseMessage httpResponseMessage);

      Task<OwnFile> DeserializeFile(HttpResponseMessage httpResponseMessage);

      Task<TObject> DeserializeObject<TObject>(HttpResponseMessage httpResponseMessage);
   }
}