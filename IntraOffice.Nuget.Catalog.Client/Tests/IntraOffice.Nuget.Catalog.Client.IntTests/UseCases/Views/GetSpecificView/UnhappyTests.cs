using IntraOffice.Nuget.Catalog.Client.Exceptions;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests.UseCases.Views.GetSpecificView
{
   [Explicit]
   public class UnhappyTests : TestBase<ICatalogClient4Views>
   {
      [Test]
      public void Bad_ViewId()
      {
         //arrange
         var viewId = "dummy";

         //assert
         Assert.ThrowsAsync<ObjectNotFoundException>(() => SUT().GetViewById(viewId));
      }
   }
}