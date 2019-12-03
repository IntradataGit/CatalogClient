using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Exceptions;
using IntraOffice.Nuget.Catalog.Models.Domain.Configuration;

namespace IntraOffice.Nuget.Catalog.Client.Interfaces
{
   /// <summary>
   ///    This interface represents client service to read Catalog's configuration
   /// </summary>
   public interface ICatalogClient4Configs
   {
      /// <summary>
      ///    Get all available elements
      /// </summary>
      /// <param name="language"></param>
      /// <returns>Collection of elements</returns>
      Task<IEnumerable<ElementVm>> GetElements(string language = "en-GB");

      /// <summary>
      ///    Get all available document classes
      /// </summary>
      /// <param name="language"></param>
      /// <returns>Collection of document classes</returns>
      Task<IEnumerable<ClassVm>> GetClasses(string language = "en-GB");

      /// <summary>
      ///    Get all available document categories
      /// </summary>
      /// <param name="language"></param>
      /// <returns>Collection of document categories</returns>
      Task<IEnumerable<CategoryVm>> GetCategories(string language = "en-GB");

      /// <summary>
      ///    Get all available document retention periods
      /// </summary>
      /// <param name="language"></param>
      /// <returns>Collection of retention periods</returns>
      Task<IEnumerable<RetentionPeriodVm>> GetRetentionPeriods(string language = "en-GB");

      /// <summary>
      ///    List available retention schedules
      /// </summary>
      /// <param name="language"></param>
      /// <returns>Collection of retention schedules</returns>
      Task<IEnumerable<RetentionScheduleVm>> GetRetentionSchedules(string language = "en-GB");

      /// <summary>
      ///    Get all supported events
      /// </summary>
      /// <param name="language"></param>
      /// <returns>Collection of document</returns>
      Task<IEnumerable<EventVm>> GetEvents(string language = "en-GB");

      /// <summary>
      ///    Get entity by name
      /// </summary>
      /// <param name="entityId">Entity's identifer</param>
      /// <param name="language"></param>
      /// <returns>Entity</returns>
      /// <exception cref="ArgumentNullException"></exception>
      /// <exception cref="ObjectNotFoundException"></exception>
      Task<EntityVm> GetEntityById(string entityId, string language = "en-GB");

      /// <summary>
      ///    Get available entities
      /// </summary>
      /// <param name="language"></param>
      /// <returns>Collection of entities</returns>
      Task<IEnumerable<EntityVm>> GetEntities(string language = "en-GB");
   }
}