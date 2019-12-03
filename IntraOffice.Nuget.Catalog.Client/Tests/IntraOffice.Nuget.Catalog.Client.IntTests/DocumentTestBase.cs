using IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.IntTests
{
   /// <summary>
   ///    Base class for tests that need document
   /// </summary>
   /// <typeparam name="TSUT">Type system under test</typeparam>
   public abstract class DocumentTestBase<TSUT> : TestBase<TSUT>
   {
      protected string _documentTicket;

      [SetUp]
      public void SetUp2()
      {
         _documentTicket = this.CreateDocument();
      }

      [TearDown]
      public void TearDown2()
      {
         this.DeleteDocument(_documentTicket);
      }
   }
}