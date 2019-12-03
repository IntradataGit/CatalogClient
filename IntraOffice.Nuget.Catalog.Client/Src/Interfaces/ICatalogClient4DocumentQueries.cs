using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Exceptions;
using IntraOffice.Nuget.Catalog.Models.Domain;
using IntraOffice.Nuget.Catalog.Models.Domain.DocumentQueries;

namespace IntraOffice.Nuget.Catalog.Client.Interfaces
{
   /// <summary>
   ///    This interface represents client service to run document queries
   /// </summary>
   public interface ICatalogClient4DocumentQueries
   {
      /// <summary>
      ///    Find documents that belong to specified document class and their metadata contains specified text fragment
      /// </summary>
      /// <param name="documentClassId">Document class identifier</param>
      /// <param name="searchText">Text fragment to look for</param>
      /// <param name="language"></param>
      /// <returns>Query result ticket</returns>
      /// <exception cref="ArgumentNullException"></exception>
      /// <exception cref="BadRequestException"></exception>
      /// <exception cref="ObjectNotFoundException"></exception>
      Task<string> FindDocumentsWithinClass(string documentClassId, string searchText, string language = "en-GB");

      /// <summary>
      ///    Find documents that belong to specified document category and their metadata contains specified text fragment
      /// </summary>
      /// <param name="documentCategoryId">Document category identifier</param>
      /// <param name="searchText">Text fragment to look for</param>
      /// <param name="language"></param>
      /// <returns>Query result ticket</returns>
      /// <exception cref="ArgumentNullException"></exception>
      /// <exception cref="BadRequestException"></exception>
      /// <exception cref="ObjectNotFoundException"></exception>
      Task<string> FindDocumentsWithinCategory(string documentCategoryId, string searchText, string language = "en-GB");

      /// <summary>
      ///    Get query result metadata
      /// </summary>
      /// <param name="queryResultTicket">Query result ticket</param>
      /// <param name="language"></param>
      /// <returns>Query result metadata</returns>
      Task<DocumentSetMetaDataVm> GetQueryResultMetadata(string queryResultTicket, string language = "en-GB");

      /// <summary>
      ///    Get all rows in query result
      /// </summary>
      /// <param name="queryResultTicket"></param>
      /// <param name="language"></param>
      /// <returns>Collection of rows</returns>
      Task<IEnumerable<DocumentRowVm>> GetAllRows(string queryResultTicket, string language = "en-GB");

      /// <summary>
      ///    Get specific row from query result
      /// </summary>
      /// <param name="queryResultTicket">Query result ticket</param>
      /// <param name="rowIndex">Row index</param>
      /// <param name="language"></param>
      /// <returns>Row</returns>
      Task<DocumentRowVm> GetSpecificRow(string queryResultTicket, int rowIndex, string language = "en-GB");

      /// <summary>
      ///    Get specific rows from query result
      /// </summary>
      /// <param name="queryResultTicket">Query result ticket</param>
      /// <param name="numberRowsToSkip">Number rows to skip</param>
      /// <param name="numberRowsToReturn">Number rows to return</param>
      /// <param name="language"></param>
      /// <returns>Collection of rows</returns>
      Task<IEnumerable<DocumentRowVm>> GetSpecificRows(string queryResultTicket, int numberRowsToSkip, int numberRowsToReturn, string language = "en-GB");

      /// <summary>
      ///    Apply new sort to query result
      /// </summary>
      /// <param name="queryResultTicket">Query result ticket</param>
      /// <param name="newSortOrder">New sort order</param>
      /// <param name="language"></param>
      /// <returns></returns>
      Task ChangeSortOder(string queryResultTicket, SortOrderVm newSortOrder, string language = "en-GB");

      /// <summary>
      ///    Get sort order currently applied to query result
      /// </summary>
      /// <param name="queryResultTicket">Query result ticket</param>
      /// <param name="language"></param>
      /// <returns>Collection of sort expressions</returns>
      Task<IEnumerable<string>> GetSortOrder(string queryResultTicket, string language = "en-GB");

      /// <summary>
      ///    Run custom query to find documents
      /// </summary>
      /// <param name="query">Query model</param>
      /// <param name="language"></param>
      /// <returns>Query result ticket</returns>
      /// <exception cref="ArgumentNullException"></exception>
      /// <exception cref="ArgumentException"></exception>
      Task<string> FindDocuments(CatalogQueryVm query, string language = "en-GB");
   }
}