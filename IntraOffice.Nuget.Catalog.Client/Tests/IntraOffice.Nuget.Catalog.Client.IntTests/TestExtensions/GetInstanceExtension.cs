namespace IntraOffice.Nuget.Catalog.Client.IntTests.TestExtensions
{
   public static class GetInstanceExtension
   {
      public static TService GetInstance<TService>(this TestBase test)
      {
         var clientSettings = test.GetClientSettings();
         return test.Container.With(clientSettings).GetInstance<TService>();
      }
   }
}