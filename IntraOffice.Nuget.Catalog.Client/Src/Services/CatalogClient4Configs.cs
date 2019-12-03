using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Configuration;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Client.Interfaces.Helpers;
using IntraOffice.Nuget.Catalog.Client.Services.Helpers;
using IntraOffice.Nuget.Catalog.Models.Domain.Configuration;

namespace IntraOffice.Nuget.Catalog.Client.Services
{
   /// <summary>
   ///    Implementation of <see cref="ICatalogClient4Configs" />
   /// </summary>
   public class CatalogClient4Configs : ICatalogClient4Configs
   {
      private readonly ICatalogApiClient _apiClient;

      #region ctor

      public CatalogClient4Configs(CatalogClientSettings clientSettings) : this(new CatalogApiClientService(clientSettings))
      {
      }

      internal CatalogClient4Configs(ICatalogApiClient apiClient)
      {
         _apiClient = apiClient ?? throw new ArgumentNullException(nameof(apiClient));
      }

      #endregion

      public Task<IEnumerable<ClassVm>> GetClasses(string language)
      {
         return _apiClient.GetModel<IEnumerable<ClassVm>>("/schema/classes", language);
      }

      public Task<IEnumerable<CategoryVm>> GetCategories(string language)
      {
         return _apiClient.GetModel<IEnumerable<CategoryVm>>("/schema/categories", language);
      }

      public Task<IEnumerable<EntityVm>> GetEntities(string language)
      {
         return _apiClient.GetModel<IEnumerable<EntityVm>>("/schema/entities", language);
      }

      public Task<EntityVm> GetEntityById(string entityId, string language)
      {
         if (string.IsNullOrEmpty(entityId))
         {
            throw new ArgumentNullException(nameof(entityId));
         }

         return _apiClient.GetModel<EntityVm>($"/schema/entities/{entityId}", language);
      }

      public Task<IEnumerable<ElementVm>> GetElements(string language)
      {
         return _apiClient.GetModel<IEnumerable<ElementVm>>("/schema/elements", language);
      }

      public Task<IEnumerable<RetentionPeriodVm>> GetRetentionPeriods(string language)
      {
         return _apiClient.GetModel<IEnumerable<RetentionPeriodVm>>("/schema/retentionPeriods", language);
      }

      public Task<IEnumerable<RetentionScheduleVm>> GetRetentionSchedules(string language)
      {
         return _apiClient.GetModel<IEnumerable<RetentionScheduleVm>>("/schema/retentionSchedules", language);
      }

      public Task<IEnumerable<EventVm>> GetEvents(string language)
      {
         return _apiClient.GetModel<IEnumerable<EventVm>>("/schema/events", language);
      }
   }
}