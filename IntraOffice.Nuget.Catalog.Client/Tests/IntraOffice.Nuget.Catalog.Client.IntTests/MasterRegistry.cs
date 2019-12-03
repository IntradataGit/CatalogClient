using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Client.Services;
using StructureMap;

namespace IntraOffice.Nuget.Catalog.Client.IntTests
{
   public class MasterRegistry : Registry
   {
      public MasterRegistry()
      {
         For<ICatalogClient4Documents>().Use<CatalogClient4Documents>();
         For<ICatalogClient4DocumentQueries>().Use<CatalogClient4DocumentQueries>();
         For<ICatalogClient4EntityQueries>().Use<CatalogClient4EntityQueries>();
         For<ICatalogClient4Configs>().Use<CatalogClient4Configs>();
         For<ICatalogClient4Views>().Use<CatalogClient4Views>();
      }
   }
}