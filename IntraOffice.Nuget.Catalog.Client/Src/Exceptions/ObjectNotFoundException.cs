using System;

namespace IntraOffice.Nuget.Catalog.Client.Exceptions
{
   public class ObjectNotFoundException : Exception
   {
      public ObjectNotFoundException() : base("Object you have requested cannot be found")
      {
      }

      public object AdditionalData { get; set; }

      public string ObjectType { get; set; }

      public string ObjectUrl { get; set; }

      public string Language { get; set; }
   }
}