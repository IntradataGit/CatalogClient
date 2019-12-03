using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using IntraOffice.Nuget.Catalog.Client.Exceptions;
using IntraOffice.Nuget.Catalog.Models.Domain.Documents;
using IntraOffice.Nuget.Catalog.Models.Domain.Documents.Annotations;
using IntraOffice.Nuget.Catalog.Models.Domain.Documents.Versions;

namespace IntraOffice.Nuget.Catalog.Client.Interfaces
{
   /// <summary>
   ///    This interface represents client service to work with documents
   /// </summary>
   public interface ICatalogClient4Documents
   {
      /// <summary>
      ///    Add new document to Catalog
      /// </summary>
      /// <param name="model">Document create model</param>
      /// <param name="language"></param>
      /// <returns>Document's ticket</returns>
      /// <exception cref="ArgumentNullException"></exception>
      /// <exception cref="ArgumentException"></exception>
      /// <exception cref="BadRequestException"></exception>
      Task<string> CreateDocument(CreateDocumentVm model, string language = "en-GB");

      /// <summary>
      ///    Get document's binary content
      /// </summary>
      /// <param name="documentTicket">Document's ticket</param>
      /// <param name="language"></param>
      /// <returns>Binary document content</returns>
      /// <exception cref="ArgumentNullException"></exception>
      /// <exception cref="BadRequestException"></exception>
      /// <exception cref="ObjectNotFoundException"></exception>
      Task<byte[]> GetDocumentContent(string documentTicket, string language = "en-GB");

      /// <summary>
      ///    Get document's metadata
      /// </summary>
      /// <param name="documentTicket">Document's ticket</param>
      /// <param name="language"></param>
      /// <returns>Model of document metadata</returns>
      /// <exception cref="ArgumentNullException"></exception>
      /// <exception cref="ArgumentException"></exception>
      /// <exception cref="BadRequestException"></exception>
      Task<DocumentVm> GetDocumentMetadata(string documentTicket, string language = "en-GB");

      /// <summary>
      ///    Add new version of already created document
      /// </summary>
      /// <param name="documentTicket">Document's ticket</param>
      /// <param name="model">Create document version model</param>
      /// <param name="language"></param>
      /// <returns>Token of document's version</returns>
      /// <exception cref="ArgumentNullException"></exception>
      /// <exception cref="BadRequestException"></exception>
      /// <exception cref="ObjectNotFoundException"></exception>
      Task<string> CreateDocumentVersion(string documentTicket, CreateDocumentVersionVm model, string language = "en-GB");

      /// <summary>
      ///    List document versions
      /// </summary>
      /// <param name="documentTicket">Document's ticket</param>
      /// <param name="language"></param>
      /// <returns>Collection of document version models</returns>
      /// <exception cref="ArgumentNullException"></exception>
      /// <exception cref="BadRequestException"></exception>
      /// <exception cref="ObjectNotFoundException"></exception>
      Task<IEnumerable<DocumentVersionVm>> GetDocumentVersions(string documentTicket, string language = "en-GB");

      /// <summary>
      ///    Delete document version
      /// </summary>
      /// <param name="documentVersionTicket">Ticket of document version</param>
      /// <param name="language"></param>
      /// <returns></returns>
      /// <exception cref="ArgumentNullException"></exception>
      /// <exception cref="BadRequestException"></exception>
      /// <exception cref="ObjectNotFoundException"></exception>
      Task DeleteDocumentVersion(string documentVersionTicket, string language = "en-GB");

      /// <summary>
      ///    Update document's metadata
      /// </summary>
      /// <param name="documentTicket">Document's ticket</param>
      /// <param name="model">Update model</param>
      /// <param name="language"></param>
      /// <returns></returns>
      /// <exception cref="ArgumentNullException"></exception>
      /// <exception cref="ArgumentException"></exception>
      /// <exception cref="BadRequestException"></exception>
      Task UpdateDocumentMetadata(string documentTicket, UpdateDocumentVm model, string language = "en-GB");

      /// <summary>
      ///    Delete document and all its versions
      /// </summary>
      /// <param name="documentTicket">Document's ticket</param>
      /// <param name="language"></param>
      /// <returns></returns>
      /// <exception cref="ArgumentNullException"></exception>
      /// <exception cref="ObjectNotFoundException"></exception>
      /// <exception cref="BadRequestException"></exception>
      Task DeleteDocument(string documentTicket, string language = "en-GB");

      /// <summary>
      ///    List document's events
      /// </summary>
      /// <param name="documentTicket">Document's ticket</param>
      /// <param name="language"></param>
      /// <returns>Collection of document event models</returns>
      /// <exception cref="ArgumentNullException"></exception>
      /// <exception cref="BadRequestException"></exception>
      /// <exception cref="ObjectNotFoundException"></exception>
      Task<IEnumerable<DocumentEventVm>> GetDocumentEvents(string documentTicket, string language = "en-GB");

      /// <summary>
      ///    Add new annotation to document
      /// </summary>
      /// <param name="documentTicket">Document's ticket</param>
      /// <param name="model">Create annotation model</param>
      /// <param name="language"></param>
      /// <returns></returns>
      /// <exception cref="ArgumentNullException"></exception>
      /// <exception cref="BadRequestException"></exception>
      /// <exception cref="ObjectNotFoundException"></exception>
      Task AddDocumentAnnotation(string documentTicket, CreateAnnotationVm model, string language = "en-GB");

      /// <summary>
      ///    List document's annotations
      /// </summary>
      /// <param name="documentTicket">Document's ticket</param>
      /// <param name="language"></param>
      /// <returns>Collection of annotation models</returns>
      /// <exception cref="ArgumentNullException"></exception>
      /// <exception cref="BadRequestException"></exception>
      /// <exception cref="ObjectNotFoundException"></exception>
      Task<IEnumerable<AnnotationVm>> GetDocumentAnnotations(string documentTicket, string language = "en-GB");

      /// <summary>
      ///    Delete annotation
      /// </summary>
      /// <param name="documentTicket"></param>
      /// <param name="annotationTicket"></param>
      /// <param name="language"></param>
      /// <returns></returns>
      /// <exception cref="ArgumentNullException"></exception>
      /// <exception cref="BadRequestException"></exception>
      /// <exception cref="ObjectNotFoundException"></exception>
      Task DeleteDocumentAnnotation(string documentTicket, string annotationTicket, string language = "en-GB");

      /// <summary>
      ///    Update existing annotation
      /// </summary>
      /// <param name="documentVersionTicket"></param>
      /// <param name="annotationTicket"></param>
      /// <param name="model"></param>
      /// <param name="language"></param>
      /// <returns></returns>
      /// <exception cref="ArgumentNullException"></exception>
      /// <exception cref="BadRequestException"></exception>
      /// <exception cref="ObjectNotFoundException"></exception>
      Task UpdateDocumentAnnotation(string documentVersionTicket, string annotationTicket, UpdateAnnotationVm model, string language = "en-GB");
   }
}