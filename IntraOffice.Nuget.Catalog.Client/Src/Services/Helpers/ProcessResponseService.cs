using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Exceptions;
using IntraOffice.Nuget.Catalog.Client.Interfaces.Helpers;
using Newtonsoft.Json;

namespace IntraOffice.Nuget.Catalog.Client.Services.Helpers
{
   /// <summary>
   ///    Implementation of <see cref="IProcessErrorResponse" />
   /// </summary>
   internal class ProcessResponseService : IProcessErrorResponse
   {
      public async Task<Exception> TryMatchLocalException(HttpResponseMessage httpResponseMessage)
      {
         var statusCode = httpResponseMessage.StatusCode;
         var responseBody = await httpResponseMessage.Content.ReadAsStringAsync();

         if (statusCode == HttpStatusCode.Forbidden)
         {
            return new ForbiddenException
            {
               AdditionalData = ToJson(responseBody)
            };
         }

         if (statusCode == HttpStatusCode.NotFound)
         {
            return new ObjectNotFoundException
            {
               AdditionalData = ToJson(responseBody)
            };
         }

         if (statusCode == HttpStatusCode.BadRequest)
         {
            return new BadRequestException
            {
               StatusCode = statusCode,
               AdditionalData = ToJson(responseBody)
            };
         }

         if (statusCode == HttpStatusCode.InternalServerError)
         {
            var rb = await httpResponseMessage.Content.ReadAsStringAsync();

            if (rb.Contains("TenantHasNotBeenConfigured"))
            {
               return new BadRequestException
               {
                  StatusCode = statusCode,
                  AdditionalData = ToJson(responseBody)
               };
            }
         }

         if (!httpResponseMessage.IsSuccessStatusCode)
         {
            return new UnexpectedErrorException
            {
               StatusCode = statusCode,
               AdditionalData = ToJson(responseBody)
            };
         }

         return null;
      }

      private static object ToJson(string responseBody)
      {
         if (string.IsNullOrEmpty(responseBody))
         {
            return null;
         }

         object result;

         try
         {
            result = JsonConvert.DeserializeObject(responseBody);
         }
         catch
         {
            result = responseBody;
         }

         return result;
      }
   }
}