using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Configuration;
using IntraOffice.Nuget.Catalog.Client.Domain;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Client.Interfaces.Helpers;
using IntraOffice.Nuget.Catalog.Client.Services.Helpers;
using IntraOffice.Nuget.Catalog.Client.Services.ModelValidators;
using IntraOffice.Nuget.Catalog.Models.Domain.Documents;
using IntraOffice.Nuget.Catalog.Models.Domain.Documents.Annotations;
using IntraOffice.Nuget.Catalog.Models.Domain.Documents.Versions;

namespace IntraOffice.Nuget.Catalog.Client.Services
{
   /// <summary>
   ///    Implementation of <see cref="ICatalogClient4Documents" />
   /// </summary>
   public class CatalogClient4Documents : ICatalogClient4Documents
   {
      private readonly IValidateModel<CreateDocumentVm> _createDocumentModelValidator;
      private readonly IValidateModel<UpdateDocumentVm> _updateUpdateModelValidator;
      private readonly IValidateModel<CreateAnnotationVm> _createAnnotationModelValidator;
      private readonly IValidateModel<UpdateAnnotationVm> _updateAnnotationModelValidator;
      private readonly IValidateModel<CreateDocumentVersionVm> _createDocumentVersionModelValidator;
      private readonly ICatalogApiClient _apiClient;

      #region ctor

      public CatalogClient4Documents(CatalogClientSettings clientSettings) : this(
         new CatalogApiClientService(clientSettings),
         new ModelValidator4CreateDocumentVm(),
         new ModelValidator4UpdateDocumentVm(),
         new ModelValidator4CreateAnnotationVm(),
         new ModelValidator4UpdateAnnotationVm(),
         new ModelValidator4CreateDocumentVersionVm()
      )
      {
      }

      internal CatalogClient4Documents(
         ICatalogApiClient apiClient,
         IValidateModel<CreateDocumentVm> createDocumentModelValidator,
         IValidateModel<UpdateDocumentVm> updateUpdateModelValidator,
         IValidateModel<CreateAnnotationVm> createAnnotationModelValidator,
         IValidateModel<UpdateAnnotationVm> updateAnnotationModelValidator,
         IValidateModel<CreateDocumentVersionVm> createDocumentVersionValidator)
      {
         _apiClient = apiClient;
         _createDocumentModelValidator = createDocumentModelValidator;
         _updateUpdateModelValidator = updateUpdateModelValidator;
         _createAnnotationModelValidator = createAnnotationModelValidator;
         _updateAnnotationModelValidator = updateAnnotationModelValidator;
         _createDocumentVersionModelValidator = createDocumentVersionValidator;
      }

      #endregion

      public async Task<string> CreateDocument(CreateDocumentVm model, string language)
      {
         if (model == null)
         {
            throw new ArgumentNullException(nameof(model));
         }

         _createDocumentModelValidator.Validate(model);

         var files = new[] {new OwnFile {Content = model.Content, ContentType = model.ContentType}};
         var responseMessage = await _apiClient.Post("/document", model, files, language);
         var response = responseMessage.LocationHeader;
         var documentTicket = response.Split('/').Last();
         return documentTicket;
      }

      public async Task<DocumentVm> GetDocumentMetadata(string documentTicket, string language)
      {
         if (string.IsNullOrEmpty(documentTicket))
         {
            throw new ArgumentNullException(nameof(documentTicket));
         }

         var documentVm = await _apiClient.GetModel<DocumentVm>($"/document/{documentTicket}", language);

         return documentVm;
      }

      public async Task UpdateDocumentMetadata(string documentTicket, UpdateDocumentVm model, string language)
      {
         if (model == null)
         {
            throw new ArgumentNullException(nameof(model));
         }

         if (string.IsNullOrEmpty(documentTicket))
         {
            throw new ArgumentNullException(nameof(documentTicket));
         }

         _updateUpdateModelValidator.Validate(model);

         await _apiClient.Patch($"/document/{documentTicket}", model, language);
      }

      public async Task<byte[]> GetDocumentContent(string documentTicket, string language)
      {
         if (string.IsNullOrEmpty(documentTicket))
         {
            throw new ArgumentNullException(nameof(documentTicket));
         }

         var file = await _apiClient.GetFile($"/document/{documentTicket}/content", language);

         return file.Content;
      }

      public async Task<IEnumerable<DocumentEventVm>> GetDocumentEvents(string documentTicket, string language)
      {
         if (string.IsNullOrEmpty(documentTicket))
         {
            throw new ArgumentNullException(nameof(documentTicket));
         }

         var documentEvents = await _apiClient.GetModel<IEnumerable<DocumentEventVm>>($"/document/{documentTicket}/history", language);

         return documentEvents;
      }

      public async Task AddDocumentAnnotation(string documentTicket, CreateAnnotationVm model, string language)
      {
         if (model == null)
         {
            throw new ArgumentNullException(nameof(model));
         }

         if (string.IsNullOrEmpty(documentTicket))
         {
            throw new ArgumentNullException(nameof(documentTicket));
         }

         _createAnnotationModelValidator.Validate(model);

         await _apiClient.Post($"/document/{documentTicket}/annotations", model, language);
      }

      public async Task DeleteDocumentAnnotation(string documentTicket, string annotationTicket, string language)
      {
         if (string.IsNullOrEmpty(documentTicket))
         {
            throw new ArgumentNullException(nameof(documentTicket));
         }

         if (string.IsNullOrEmpty(annotationTicket))
         {
            throw new ArgumentNullException(nameof(annotationTicket));
         }

         await _apiClient.Delete($"/document/{documentTicket}/annotations/{annotationTicket}", language);
      }

      public async Task UpdateDocumentAnnotation(string documentVersionTicket, string annotationTicket, UpdateAnnotationVm model, string language)
      {
         if (model == null)
         {
            throw new ArgumentNullException(nameof(model));
         }

         if (string.IsNullOrEmpty(documentVersionTicket))
         {
            throw new ArgumentNullException(nameof(documentVersionTicket));
         }

         if (string.IsNullOrEmpty(annotationTicket))
         {
            throw new ArgumentNullException(nameof(annotationTicket));
         }

         _updateAnnotationModelValidator.Validate(model);

         await _apiClient.Put($"/document/{documentVersionTicket}/annotations/{annotationTicket}", model, language);
      }

      public async Task<IEnumerable<AnnotationVm>> GetDocumentAnnotations(string documentTicket, string language)
      {
         if (string.IsNullOrEmpty(documentTicket))
         {
            throw new ArgumentNullException(nameof(documentTicket));
         }

         var documentAnnotations = await _apiClient.GetModel<IEnumerable<AnnotationVm>>($"/document/{documentTicket}/annotations", language);

         return documentAnnotations;
      }

      public async Task<string> CreateDocumentVersion(string documentTicket, CreateDocumentVersionVm model, string language)
      {
         if (model == null)
         {
            throw new ArgumentNullException(nameof(model));
         }

         if (string.IsNullOrEmpty(documentTicket))
         {
            throw new ArgumentNullException(nameof(documentTicket));
         }

         _createDocumentVersionModelValidator.Validate(model);

         var files = new[] {new OwnFile {Content = model.Content, ContentType = model.ContentType}};
         var responseVm = await _apiClient.Put($"/document/{documentTicket}", model, files, language);
         var documentVersionTicket = responseVm.ResponseBody.Replace("\"", "");
         return documentVersionTicket;
      }

      public async Task DeleteDocumentVersion(string documentVersionTicket, string language)
      {
         if (string.IsNullOrEmpty(documentVersionTicket))
         {
            throw new ArgumentNullException(nameof(documentVersionTicket));
         }

         var documentVersions = await GetDocumentVersions(documentVersionTicket, language);

         var firstVersion = documentVersions.FirstOrDefault(v => v.Version == 1);

         string firstVersionTicket;

         if (firstVersion != null)
         {
            firstVersionTicket = firstVersion.Ticket;
         }
         else
         {
            firstVersionTicket = documentVersionTicket;
         }

         await _apiClient.Delete($"/document/{firstVersionTicket}/{documentVersionTicket}", language);
      }

      public async Task<IEnumerable<DocumentVersionVm>> GetDocumentVersions(string documentTicket, string language)
      {
         if (string.IsNullOrEmpty(documentTicket))
         {
            throw new ArgumentNullException(nameof(documentTicket));
         }

         var documentVersions = await _apiClient.GetModel<IEnumerable<DocumentVersionVm>>($"/document/{documentTicket}/versions", language);

         return documentVersions;
      }

      public async Task DeleteDocument(string documentTicket, string language)
      {
         if (string.IsNullOrEmpty(documentTicket))
         {
            throw new ArgumentNullException(nameof(documentTicket));
         }

         await _apiClient.Delete($"/document/{documentTicket}", language);
      }
   }
}