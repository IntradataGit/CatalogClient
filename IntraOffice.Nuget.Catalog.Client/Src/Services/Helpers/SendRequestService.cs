using System.Net.Http;
using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Interfaces.Helpers;

namespace IntraOffice.Nuget.Catalog.Client.Services.Helpers
{
   /// <summary>
   ///    Implementation of <see cref="ISendRequest" />
   /// </summary>
   internal class SendRequestService : ISendRequest
   {
      private readonly IProcessErrorResponse _localExceptionService;

      #region ctor

      public SendRequestService() : this(new ProcessResponseService())
      {
      }

      internal SendRequestService(IProcessErrorResponse localExceptionService)
      {
         _localExceptionService = localExceptionService;
      }

      #endregion

      public async Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage)
      {
         using (var client = new HttpClient())
         {
            var httpResponseMessage = await client.SendAsync(httpRequestMessage);

            if (!httpResponseMessage.IsSuccessStatusCode)
            {
               var exception = await _localExceptionService.TryMatchLocalException(httpResponseMessage);

               if (exception != null)
               {
                  throw exception;
               }
            }

            return httpResponseMessage;
         }
      }
   }
}