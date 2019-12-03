using IntraOffice.Nuget.Catalog.Client.Interfaces.Helpers;
using Newtonsoft.Json;

namespace IntraOffice.Nuget.Catalog.Client.Services.Helpers
{
   /// <summary>
   ///    Implementation of <see cref="ISerializeObject" />
   /// </summary>
   internal class SerializeObjectService : ISerializeObject
   {
      public TObject DeserializeObject<TObject>(string text)
      {
         return JsonConvert.DeserializeObject<TObject>(text, new ElementConverter());
      }

      public string SerializeObject<TObject>(TObject obj)
      {
         if (obj == null)
         {
            return null;
         }

         return JsonConvert.SerializeObject(obj, new JsonSerializerSettings {NullValueHandling = NullValueHandling.Ignore});
      }
   }
}