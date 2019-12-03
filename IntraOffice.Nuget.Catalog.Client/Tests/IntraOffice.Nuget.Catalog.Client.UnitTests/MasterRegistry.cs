using IntraOffice.Nuget.Catalog.Client.Configuration;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Client.Interfaces.Helpers;
using IntraOffice.Nuget.Catalog.Client.Services;
using IntraOffice.Nuget.Catalog.Client.Services.Helpers;
using StructureMap;

namespace IntraOffice.Nuget.Catalog.Client.UnitTests
{
   public class MasterRegistry : Registry
   {
      public MasterRegistry()
      {
         For<ISerializeObject>().Use<SerializeObjectService>();
         For<IDeserializeResponse>().Use<DeserializeResponseService>();
         For<ICatalogClient4Configs>().Use(() => new CatalogClient4Configs(BuildSettings()));
         For<ICatalogClient4Views>().Use(() => new CatalogClient4Views(BuildSettings()));
         For<ICatalogClient4Documents>().Use(() => new CatalogClient4Documents(BuildSettings()));
         For<ICatalogClient4EntityQueries>().Use(() => new CatalogClient4EntityQueries(BuildSettings()));
         For<ICatalogClient4DocumentQueries>().Use(() => new CatalogClient4DocumentQueries(BuildSettings()));
      }

      private static CatalogClientSettings BuildSettings()
      {
         return new CatalogClientSettings();
      }
   }
}