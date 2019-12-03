using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.Configuration.GetAllEvents
{
   [Explicit]
   public class HappyTests : TestBase<ICatalogClient4Configs>
   {
      [Test]
      public async Task Happy_Case()
      {
         //act
         var events = await SUT().GetEvents();

         //assert
         Assert.IsNotNull(events);
         CollectionAssert.IsNotEmpty(events);

         //print
         events.Print();
      }
   }
}