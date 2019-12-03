using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace IntraOffice.Nuget.Catalog.Client.Interfaces.Helpers
{
   /// <summary>
   /// This interface represents help service to process <see cref="HttpResponseMessage"/> with error code
   /// </summary>
   internal interface IProcessErrorResponse
   {
      Task<Exception> TryMatchLocalException(HttpResponseMessage httpResponseMessage);
   }
}