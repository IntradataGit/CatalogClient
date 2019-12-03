using System;
using IntraOffice.Nuget.Catalog.Models.Domain.Configuration;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace IntraOffice.Nuget.Catalog.Client.Services.Helpers
{
   /// <summary>
   ///    Custom converter for element view models
   /// </summary>
   internal class ElementConverter : JsonConverter
   {
      public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
      {
         throw new NotImplementedException();
      }

      public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
      {
         var token = JToken.ReadFrom(reader);

         var elType = token["type"]?.ToString();

         if (elType == "date-time")
         {
            return token.ToObject<DateTimeElementVm>();
         }

         if (elType == "number")
         {
            return token.ToObject<NumericElementVm>();
         }

         if (elType == "string")
         {
            return token.ToObject<StringElementVm>();
         }

         return token.ToObject<ElementVm>();
      }

      public override bool CanRead => true;

      public override bool CanConvert(Type objectType)
      {
         return objectType == typeof(ElementVm);
      }
   }
}