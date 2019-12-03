using System;
using System.Net;

namespace IntraOffice.Nuget.Catalog.Client.Exceptions
{
   public class UnexpectedErrorException : Exception
   {
      public UnexpectedErrorException() : base("Server returned unexpected error")
      {
      }

      public HttpStatusCode StatusCode { get; set; }

      public object AdditionalData { get; set; }
   }
}