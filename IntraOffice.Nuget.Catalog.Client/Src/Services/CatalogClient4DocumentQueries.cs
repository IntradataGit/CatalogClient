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
using IntraOffice.Nuget.Catalog.Models.Domain.DocumentQueries;

namespace IntraOffice.Nuget.Catalog.Client.Services
{
   /// <summary>
   ///    Implementation of <see cref="ICatalogClient4DocumentQueries" />
   /// </summary>
   public class CatalogClient4DocumentQueries : ICatalogClient4DocumentQueries
   {
      private readonly IValidateModel<CatalogQueryVm> _queryValidator;
      private readonly IValidateModel<SortOrderVm> _sortOrderValidator;
      private readonly ICatalogApiClient _catalogApiHttpService;

      #region ctor

      public CatalogClient4DocumentQueries(CatalogClientSettings clientSettings) : this(
         new CatalogApiClientService(clientSettings),
         new ModelValidator4CatalogQueryVm(),
         new ModelValidator4SortOrderVm()
      )
      {
      }

      internal CatalogClient4DocumentQueries(
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

      public async Task<string> FindDocumentsWithinClass(string documentClassId, string searchText, string language)
      {
         if (string.IsNullOrEmpty(documentClassId))
         {
            throw new ArgumentNullException(nameof(documentClassId));
         }

         var responseVm = await _catalogApiHttpService.Post($"/schema/classes/{documentClassId}/query?searchText={searchText}", language);
         var queryResultTicket = responseVm.LocationHeader.Split('/').Last();
         return queryResultTicket;
      }

      public async Task<string> FindDocumentsWithinCategory(string documentCategoryId, string searchText, string language)
      {
         if (string.IsNullOrEmpty(documentCategoryId))
         {
            throw new ArgumentNullException(nameof(documentCategoryId));
         }

         var responseVm = await _catalogApiHttpService.Post($"/schema/categories/{documentCategoryId}/query?searchText={searchText}", language);
         var queryResultTicket = responseVm.LocationHeader.Split('/').Last();
         return queryResultTicket;
      }

      public async Task<DocumentSetMetaDataVm> GetQueryResultMetadata(string queryResultTicket, string language)
      {
         if (string.IsNullOrEmpty(queryResultTicket))
         {
            throw new ArgumentNullException(nameof(queryResultTicket));
         }

         var queryResultMetadata = await _catalogApiHttpService.GetModel<DocumentSetMetaDataVm>($"/document/resultset/{queryResultTicket}", language);
         return queryResultMetadata;
      }

      public async Task<IEnumerable<DocumentRowVm>> GetAllRows(string queryResultTicket, string language)
      {
         if (string.IsNullOrEmpty(queryResultTicket))
         {
            throw new ArgumentNullException(nameof(queryResultTicket));
         }

         var rows = await _catalogApiHttpService.GetModel<IEnumerable<DocumentRowVm>>($"/document/resultset/{queryResultTicket}/rows", language);
         return rows;
      }

      public async Task<DocumentRowVm> GetSpecificRow(string queryResultTicket, int rowIndex, string language)
      {
         if (string.IsNullOrEmpty(queryResultTicket))
         {
            throw new ArgumentNullException(nameof(queryResultTicket));
         }

         if (rowIndex < 0)
         {
            throw new ArgumentException("RowNumber cannot be negative", nameof(rowIndex));
         }

         var row = await _catalogApiHttpService.GetModel<DocumentRowVm>($"/document/resultset/{queryResultTicket}/rows/{rowIndex}", language);
         return row;
      }

      public async Task<IEnumerable<DocumentRowVm>> GetSpecificRows(string queryResultTicket, int numberRowsToSkip, int numberRowsToReturn, string language)
      {
         if (string.IsNullOrEmpty(queryResultTicket))
         {
            throw new ArgumentNullException(nameof(queryResultTicket));
         }

         if (numberRowsToSkip < 0)
         {
            throw new ArgumentException("RowNumber cannot be negative", nameof(numberRowsToSkip));
         }

         if (numberRowsToReturn <= 0)
         {
            throw new ArgumentException("RowNumber cannot be negative", nameof(numberRowsToReturn));
         }

         var rows = await _catalogApiHttpService.GetModel<IEnumerable<DocumentRowVm>>($"/document/resultset/{queryResultTicket}/rows?skip={numberRowsToSkip}&top={numberRowsToReturn}", language);
         return rows;
      }

      public async Task ChangeSortOder(string queryResultTicket, SortOrderVm newSortOrder, string language)
      {
         if (newSortOrder == null)
         {
            throw new ArgumentNullException(nameof(newSortOrder));
         }

         if (string.IsNullOrEmpty(queryResultTicket))
         {
            throw new ArgumentNullException(nameof(queryResultTicket));
         }

         _sortOrderValidator.Validate(newSortOrder);

         await _catalogApiHttpService.Post($"/document/resultset/{queryResultTicket}/sortorder", newSortOrder, language);
      }

      public async Task<IEnumerable<string>> GetSortOrder(string queryResultTicket, string language)
      {
         if (string.IsNullOrEmpty(queryResultTicket))
         {
            throw new ArgumentNullException(nameof(queryResultTicket));
         }

         var sortOrder = await _catalogApiHttpService.GetModel<string[]>($"/document/resultset/{queryResultTicket}/sortorder", language);
         return sortOrder;
      }

      public async Task<string> FindDocuments(CatalogQueryVm query, string language)
      {
         if (query == null)
         {
            throw new ArgumentNullException(nameof(query));
         }

         _queryValidator.Validate(query);

         var responseVm = await _catalogApiHttpService.Post("/document/query", query, language);
         var queryResultTicket = responseVm.LocationHeader.Split('/').Last();
         return queryResultTicket;
      }
   }
}