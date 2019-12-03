using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.Configuration.GetAllRetentionPeriods
{
   [Explicit]
   public class HappyTests : TestBase<ICatalogClient4Configs>
   {
      [Test]
      public async Task Happy_Case()
      {
         //act
         var retentionPeriods = await SUT().GetRetentionPeriods();

         //assert
         Assert.IsNotNull(retentionPeriods);
         CollectionAssert.IsNotEmpty(retentionPeriods);

         //print
         retentionPeriods.Print();
      }
   }
}