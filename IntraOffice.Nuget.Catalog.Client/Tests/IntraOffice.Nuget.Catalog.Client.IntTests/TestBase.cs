using System;
using IntraOffice.Nuget.Catalog.Client.Configuration;
using IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions;
using NUnit.Framework;
using StructureMap;

namespace IntraOffice.Nuget.Catalog.Client.IntTests
{
   /// <summary>
   ///    Base class for integration tests
   /// </summary>
   [Category("EndToEnd")]
   [TestFixture]
   public abstract class TestBase
   {
      public CatalogClientSettings Settings { get; private set; }

      public IContainer Container { get; set; }

      [SetUp]
      public void SetUp()
      {
         Container = new Container(cfg => cfg.Scan(a =>
         {
            a.AssembliesAndExecutablesFromApplicationBaseDirectory(x => x.FullName.StartsWith("IntraOffice"));
            a.LookForRegistries();
         }));

         Settings = this.GetClientSettings();
      }

      [TearDown]
      public void TearDown()
      {
         Container?.Dispose();
      }
   }

   /// <summary>
   ///    Base class for integration tests
   /// </summary>
   /// <typeparam name="TSUT">Type system under test</typeparam>
   public abstract class TestBase<TSUT> : TestBase
   {
      public Func<TSUT> SUT => () => Container.With(Settings).GetInstance<TSUT>();
   }
}