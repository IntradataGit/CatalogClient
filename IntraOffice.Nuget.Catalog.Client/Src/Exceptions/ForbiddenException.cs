using System;

namespace IntraOffice.Nuget.Catalog.Client.Exceptions
{
   public class ForbiddenException : Exception
   {
      public ForbiddenException() : base("Operation not allowed")
      {
      }

      public object AdditionalData { get; set; }
   }
}