using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Configuration;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Client.Interfaces.Helpers;
using IntraOffice.Nuget.Catalog.Client.Services.Helpers;
using IntraOffice.Nuget.Catalog.Client.Services.ModelValidators;
using IntraOffice.Nuget.Catalog.Models.Domain;
using IntraOffice.Nuget.Catalog.Models.Domain.EntityQueries;

namespace IntraOffice.Nuget.Catalog.Client.Services
{
   /// <summary>
   ///    Implementation of <see cref="ICatalogClient4EntityQueries" />
   /// </summary>
   public class CatalogClient4EntityQueries : ICatalogClient4EntityQueries
   {
      private readonly IValidateModel<CatalogQueryVm> _queryValidator;
      private readonly IValidateModel<SortOrderVm> _sortOrderValidator;
      private readonly ICatalogApiClient _catalogApiHttpService;

      #region ctor

      public CatalogClient4EntityQueries(CatalogClientSettings clientSettings) :
         this(new CatalogApiClientService(clientSettings), new ModelValidator4CatalogQueryVm(), new ModelValidator4SortOrderVm())
      {
      }

      internal CatalogClient4EntityQueries(
         ICatalogApiClient catalogApiHttpService,
         IValidateModel<CatalogQueryVm> queryValidator,
         IValidateModel<SortOrderVm> sortOrderValidator
      )
      {
         _catalogApiHttpService = catalogApiHttpService;
         _queryValidator = queryValidator;
         _sortOrderValidator = sortOrderValidator;
      }

      #endregion

      public async Task<string> FindEntities(string entityId, string searchText, string language)
      {
         if (string.IsNullOrEmpty(entityId))
         {
            throw new ArgumentNullException(nameof(entityId));
         }

         var responseVm = await _catalogApiHttpService.Post($"/schema/entities/{entityId}/query?searchText={searchText}", language);
         var queryResultTicket = responseVm.LocationHeader.Split('/').Last();
         return queryResultTicket;
      }

      public async Task<EntitySetMetaDataVm> GetQueryResultMetadata(string queryResultTicket, string language)
      {
         if (string.IsNullOrEmpty(queryResultTicket))
         {
            throw new ArgumentNullException(nameof(queryResultTicket));
         }

         var queryResultMetadata = await _catalogApiHttpService.GetModel<EntitySetMetaDataVm>($"/entity/resultset/{queryResultTicket}", language);
         return queryResultMetadata;
      }


      public async Task<string> FindEntities(string entityId, CatalogQueryVm query, string language)
      {
         if (query == null)
         {
            throw new ArgumentNullException(nameof(query));
         }

         if (string.IsNullOrEmpty(entityId))
         {
            throw new ArgumentNullException(nameof(entityId));
         }

         _queryValidator.Validate(query);

         var responseVm = await _catalogApiHttpService.Post($"/entity/query?entityName={entityId}", query, language);
         var queryResultTicket = responseVm.LocationHeader.Split('/').Last();
         return queryResultTicket;
      }

      public async Task<IEnumerable<EntityRowVm>> GetAllRows(string queryResultTicket, string language)
      {
         if (string.IsNullOrEmpty(queryResultTicket))
         {
            throw new ArgumentNullException(nameof(queryResultTicket));
         }

         var rows = await _catalogApiHttpService.GetModel<IEnumerable<EntityRowVm>>($"/entity/resultset/{queryResultTicket}/rows", language);
         return rows;
      }

      public async Task<EntityRowVm> GetSpecificRow(string queryResultTicket, int rowIndex, string language)
      {
         if (string.IsNullOrEmpty(queryResultTicket))
         {
            throw new ArgumentNullException(nameof(queryResultTicket));
         }

         if (rowIndex < 0)
         {
            throw new ArgumentException("Row index cannot be negative", nameof(rowIndex));
         }

         var row = await _catalogApiHttpService.GetModel<EntityRowVm>($"/entity/resultset/{queryResultTicket}/rows/{rowIndex}", language);
         return row;
      }

      public async Task<IEnumerable<EntityRowVm>> GetSpecificRows(string queryResultTicket, int numberRowsToSkip, int numberRowsToTake, string language)
      {
         if (string.IsNullOrEmpty(queryResultTicket))
         {
            throw new ArgumentNullException(nameof(queryResultTicket));
         }

         if (numberRowsToSkip < 0)
         {
            throw new ArgumentException("Number cannot be negative", nameof(numberRowsToSkip));
         }

         if (numberRowsToTake <= 0)
         {
            throw new ArgumentException("Number should be positive", nameof(numberRowsToTake));
         }

         var rows = await _catalogApiHttpService.GetModel<IEnumerable<EntityRowVm>>($"/entity/resultset/{queryResultTicket}/rows?skip={numberRowsToSkip}&top={numberRowsToTake}", language);
         return rows;
      }

      public async Task<IEnumerable<string>> GetSortOrder(string queryResultTicket, string language)
      {
         if (string.IsNullOrEmpty(queryResultTicket))
         {
            throw new ArgumentNullException(nameof(queryResultTicket));
         }

         var sortOrder = await _catalogApiHttpService.GetModel<string[]>($"/entity/resultset/{queryResultTicket}/sortorder", language);
         return sortOrder;
      }

      public async Task ChangeSortOder(string queryResultTicket, SortOrderVm newSortOrder, string language)
      {
         if (string.IsNullOrEmpty(queryResultTicket))
         {
            throw new ArgumentNullException(nameof(queryResultTicket));
         }

         if (newSortOrder == null)
         {
            throw new ArgumentNullException(nameof(newSortOrder));
         }

         _sortOrderValidator.Validate(newSortOrder);

         await _catalogApiHttpService.Post($"/entity/resultset/{queryResultTicket}/sortorder", newSortOrder, language);
      }
   }
}