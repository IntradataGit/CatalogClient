using System;
using Newtonsoft.Json;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions
{
   public static class PrintExtension
   {
      public static void Print(this object obj)
      {
         Console.WriteLine(JsonConvert.SerializeObject(obj, Formatting.Indented));
      }
   }
}