using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Exceptions;
using IntraOffice.Nuget.Catalog.Models.Domain;
using IntraOffice.Nuget.Catalog.Models.Domain.Configuration;

namespace IntraOffice.Nuget.Catalog.Client.Interfaces
{
   /// <summary>
   ///    This interface represents a client service to work with catalog views
   /// </summary>
   public interface ICatalogClient4Views
   {
      /// <summary>
      ///    Get all available views
      /// </summary>
      /// <param name="language"></param>
      /// <returns>Collection of views</returns>
      Task<IEnumerable<SchemaViewVm>> GetAllViews(string language = "en-GB");

      /// <summary>
      ///    Get view by id
      /// </summary>
      /// <param name="viewId">View's unique identifier</param>
      /// <param name="language"></param>
      /// <returns>View</returns>
      /// <exception cref="ArgumentNullException"></exception>
      /// <exception cref="ObjectNotFoundException"></exception>
      Task<SchemaViewVm> GetViewById(string viewId, string language = "en-GB");

      /// <summary>
      ///    Get view node by id
      /// </summary>
      /// <param name="viewId">View's identifier</param>
      /// <param name="viewNodeId">View node's identifier</param>
      /// <param name="language"></param>
      /// <returns>View node</returns>
      /// <exception cref="ArgumentNullException"></exception>
      /// <exception cref="ObjectNotFoundException"></exception>
      Task<SchemaViewNodeVm> GetViewNodeById(string viewId, string viewNodeId, string language = "en-GB");

      /// <summary>
      ///    List document categories assigned to specified view node
      /// </summary>
      /// <param name="viewId">View's identifier</param>
      /// <param name="viewNodeId">View node's identifier</param>
      /// <param name="language"></param>
      /// <returns>Collection of document categories</returns>
      /// <exception cref="ArgumentNullException"></exception>
      /// <exception cref="ObjectNotFoundException"></exception>
      Task<IEnumerable<CategoryVm>> GetCategories(string viewId, string viewNodeId, string language = "en-GB");

      /// <summary>
      ///    Perform shortcut query on documents located under specified view/folder
      /// </summary>
      /// <param name="viewId">View's identifier</param>
      /// <param name="viewNodeId">View node's identifier</param>
      /// <param name="searchText">Text fragment to search</param>
      /// <param name="language"></param>
      /// <returns>Query result ticket</returns>
      /// <exception cref="ArgumentNullException"></exception>
      /// <exception cref="ObjectNotFoundException"></exception>
      Task<string> FindDocuments(string viewId, string viewNodeId, string searchText, string language = "en-GB");
   }
}