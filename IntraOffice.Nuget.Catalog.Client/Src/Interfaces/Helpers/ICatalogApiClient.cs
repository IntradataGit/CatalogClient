using System.Collections.Generic;
using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Domain;

namespace IntraOffice.Nuget.Catalog.Client.Interfaces.Helpers
{
   /// <summary>
   ///    This interface represents help service to talk to Catalog REST API
   /// </summary>
   internal interface ICatalogApiClient
   {
      Task<TModel> GetModel<TModel>(string relativeUrl, string language = "en-GB");

      Task<OwnFile> GetFile(string relativeUrl, string language = "en-GB");

      Task<ResponseVm> Post(string relativeUrl, string language = "en-GB");

      Task<ResponseVm> Post<TModel>(string relativeUrl, TModel model, string language = "en-GB") where TModel : class;

      Task<ResponseVm> Post<TModel>(string relativeUrl, TModel model, IEnumerable<OwnFile> files, string language = "en-GB") where TModel : class;

      Task Put<TModel>(string relativeUrl, TModel model, string language = "en-GB") where TModel : class;

      Task<ResponseVm> Put<TModel>(string relativeUrl, TModel model, IEnumerable<OwnFile> files, string language = "en-GB") where TModel : class;

      Task Patch<TModel>(string relativeUrl, TModel model, string language = "en-GB") where TModel : class;

      Task Delete(string relativeUrl, string language = "en-GB");
   }
}