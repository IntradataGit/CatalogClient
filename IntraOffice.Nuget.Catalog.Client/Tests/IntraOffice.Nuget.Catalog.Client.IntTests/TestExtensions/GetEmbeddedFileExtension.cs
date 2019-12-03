using System.IO;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions
{
   public static class GetEmbeddedFileExtension
   {
      public static byte[] GetEmbeddedBytes(this TestBase test)
      {
         using (var memoryStream = new MemoryStream())
         {
            var embeddedStream = test.GetType().Assembly.GetManifestResourceStream("IntraOffice.Nuget.Catalog.Client.IntTests.Data.Welcome.pdf");
            embeddedStream.CopyTo(memoryStream);
            return memoryStream.ToArray();
         }
      }
   }
}