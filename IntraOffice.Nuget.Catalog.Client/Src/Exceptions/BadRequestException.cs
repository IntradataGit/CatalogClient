using System;
using System.Net;

namespace IntraOffice.Nuget.Catalog.Client.Exceptions
{
   public class BadRequestException : Exception
   {
      public BadRequestException() : base("Invalid request")
      {
      }

      public HttpStatusCode StatusCode { get; set; }

      public object AdditionalData { get; set; }
   }
}