using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Exceptions;
using IntraOffice.Nuget.Catalog.Models.Domain;
using IntraOffice.Nuget.Catalog.Models.Domain.EntityQueries;

namespace IntraOffice.Nuget.Catalog.Client.Interfaces
{
   /// <summary>
   ///    This interface represents client service to run queries based on entities
   /// </summary>
   public interface ICatalogClient4EntityQueries
   {
      /// <summary>
      ///     Find documents whose metadata contains specified text fragment. By metadata here we assume subset of elements defined by selected entity
      /// </summary>
      /// <param name="entityId">Entity's identifier</param>
      /// <param name="searchText">Text fragment</param>
      /// <param name="language"></param>
      /// <returns>Query result ticket</returns>
      /// <exception cref="ArgumentNullException"></exception>
      /// <exception cref="BadRequestException"></exception>
      /// <exception cref="ObjectNotFoundException"></exception>
      Task<string> FindEntities(string entityId, string searchText, string language = "en-GB");

      /// <summary>
      ///    Get metadata of the generated query result
      /// </summary>
      /// <param name="queryResultTicket">Query result ticket</param>
      /// <param name="language"></param>
      /// <returns>Query result metadata</returns>
      /// <exception cref="ArgumentNullException"></exception>
      /// <exception cref="ObjectNotFoundException"></exception>
      Task<EntitySetMetaDataVm> GetQueryResultMetadata(string queryResultTicket, string language = "en-GB");

      /// <summary>
      ///    Get all rows from query result
      /// </summary>
      /// <param name="queryResultTicket">Query result ticket</param>
      /// <param name="language"></param>
      /// <returns>Collection of rows</returns>
      /// <exception cref="ArgumentNullException"></exception>
      /// <exception cref="ObjectNotFoundException"></exception>
      Task<IEnumerable<EntityRowVm>> GetAllRows(string queryResultTicket, string language = "en-GB");

      /// <summary>
      ///    Get specific row from query result
      /// </summary>
      /// <param name="queryResultTicket">Query result ticket</param>
      /// <param name="rowIndex"></param>
      /// <param name="language"></param>
      /// <returns>Row</returns>
      /// <exception cref="ArgumentNullException"></exception>
      /// <exception cref="ArgumentException"></exception>
      /// <exception cref="ObjectNotFoundException"></exception>
      Task<EntityRowVm> GetSpecificRow(string queryResultTicket, int rowIndex, string language = "en-GB");

      /// <summary>
      ///    Get subset of rows from query result
      /// </summary>
      /// <param name="queryResultTicket">Query result ticket</param>
      /// <param name="numberRowsToSkip">Number of rows to skip</param>
      /// <param name="numberRowsToTake">Number of rows to take</param>
      /// <param name="language"></param>
      /// <returns>Collection of rows</returns>
      /// <exception cref="ArgumentNullException"></exception>
      /// <exception cref="ArgumentException"></exception>
      /// <exception cref="ObjectNotFoundException"></exception>
      Task<IEnumerable<EntityRowVm>> GetSpecificRows(string queryResultTicket, int numberRowsToSkip, int numberRowsToTake, string language = "en-GB");

      /// <summary>
      ///    Change sort order of query result
      /// </summary>
      /// <param name="queryResultTicket">Query result ticket</param>
      /// <param name="newSortOrder">New sort order model</param>
      /// <param name="language"></param>
      /// <returns></returns>
      /// <exception cref="ArgumentNullException"></exception>
      /// <exception cref="ArgumentException"></exception>
      /// <exception cref="BadRequestException"></exception>
      /// <exception cref="ObjectNotFoundException"></exception>
      Task ChangeSortOder(string queryResultTicket, SortOrderVm newSortOrder, string language = "en-GB");

      /// <summary>
      ///    Get collection of current sort orders applied to resultset (e.g, 'col1 asc, col2 desc' etc)
      /// </summary>
      /// <param name="queryResultTicket">Query result ticket</param>
      /// <param name="language"></param>
      /// <returns>Collection of sort expressions</returns>
      /// <exception cref="ArgumentNullException"></exception>
      /// <exception cref="ObjectNotFoundException"></exception>
      Task<IEnumerable<string>> GetSortOrder(string queryResultTicket, string language = "en-GB");

      /// <summary>
      ///    Perform query within specified entity
      /// </summary>
      /// <param name="entityId"></param>
      /// <param name="query"></param>
      /// <param name="language"></param>
      /// <returns>Relative url of generated resultset</returns>
      /// <exception cref="ArgumentNullException"></exception>
      /// <exception cref="ObjectNotFoundException"></exception>
      /// <exception cref="BadRequestException"></exception>
      /// <exception cref="ArgumentException"></exception>
      Task<string> FindEntities(string entityId, CatalogQueryVm query, string language = "en-GB");
   }
}