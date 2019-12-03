using System;
using System.Collections.Generic;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Models.Domain.Documents;
using IntraOffice.Nuget.Catalog.Models.Domain.Documents.Annotations;
using IntraOffice.Nuget.Catalog.Models.Domain.Documents.Versions;
using IntraOffice.Nuget.Testing.UnitTests;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.UnitTests.UseCases.CatalogClient4Documents
{
   public abstract class UnhappyTests : UnitTestBase<ICatalogClient4Documents>
   {
      public class CreateDocument : UnhappyTests
      {
         [Test]
         public void Model_Null()
         {
            //arrange
            CreateDocumentVm model = null;

            //act+assert
            Assert.ThrowsAsync<ArgumentNullException>(() => SUT().CreateDocument(model));
         }

         [Test]
         public void Bad_Model()
         {
            //arrange
            var model = new CreateDocumentVm();

            //act+assert
            Assert.ThrowsAsync<ArgumentException>(() => SUT().CreateDocument(model));
         }
      }

      public class GetDocumentContent : UnhappyTests
      {
         [Test]
         public void Document_Ticket_Null()
         {
            //arrange
            var documentTicket = "";

            //act+assert
            Assert.ThrowsAsync<ArgumentNullException>(() => SUT().GetDocumentContent(documentTicket));
         }
      }

      public class GetDocument : UnhappyTests
      {
         [Test]
         public void Document_Ticket_Null()
         {
            //arrange
            var documentTicket = "";

            //act+assert
            Assert.ThrowsAsync<ArgumentNullException>(() => SUT().GetDocumentMetadata(documentTicket));
         }
      }

      public class UpdateDocument : UnhappyTests
      {
         [Test]
         public void Document_Ticket_Null()
         {
            //arrange
            var documentTicket = "";

            var updateDocumentVm = new UpdateDocumentVm
            {
               Elements = new Dictionary<string, string>
               {
                  {"tence-documentOmschrijving", "abc2"}
               }
            };

            //act+assert
            Assert.ThrowsAsync<ArgumentNullException>(() => SUT().UpdateDocumentMetadata(documentTicket, updateDocumentVm));
         }

         [Test]
         public void Model_Null()
         {
            //arrange
            var documentTicket = "dummy";

            UpdateDocumentVm updateDocumentVm = null;

            //act+assert
            Assert.ThrowsAsync<ArgumentNullException>(() => SUT().UpdateDocumentMetadata(documentTicket, updateDocumentVm));
         }

         [Test]
         public void Bad_Model()
         {
            //arrange
            var documentTicket = "dummy";

            var updateDocumentVm = new UpdateDocumentVm();

            //act+assert
            Assert.ThrowsAsync<ArgumentException>(() => SUT().UpdateDocumentMetadata(documentTicket, updateDocumentVm));
         }
      }

      public class DeleteDocument : UnhappyTests
      {
         [Test]
         public void Document_Ticket_Null()
         {
            //arrange
            var documentTicket = "";

            //act+assert
            Assert.ThrowsAsync<ArgumentNullException>(() => SUT().DeleteDocument(documentTicket));
         }
      }

      public class GetDocumentHistory : UnhappyTests
      {
         [Test]
         public void Document_Ticket_Null()
         {
            //arrange
            var documentTicket = "";

            //assert
            Assert.ThrowsAsync<ArgumentNullException>(() => SUT().GetDocumentEvents(documentTicket));
         }
      }

      public class CreateDocumentVersion : UnhappyTests
      {
         [Test]
         public void Document_Ticket_Null()
         {
            //arrange
            var documentTicket = "";

            var model = new CreateDocumentVersionVm();

            //act+assert
            Assert.ThrowsAsync<ArgumentNullException>(() => SUT().CreateDocumentVersion(documentTicket, model));
         }

         [Test]
         public void Model_Null()
         {
            //arrange
            var documentTicket = "xxx";

            CreateDocumentVersionVm model = null;

            //act+assert
            Assert.ThrowsAsync<ArgumentNullException>(() => SUT().CreateDocumentVersion(documentTicket, model));
         }

         [Test]
         public void Bad_Model()
         {
            //arrange
            var documentTicket = "xxx";

            var model = new CreateDocumentVersionVm();

            //act+assert
            Assert.ThrowsAsync<ArgumentException>(() => SUT().CreateDocumentVersion(documentTicket, model));
         }
      }

      public class GetDocumentVersions : UnhappyTests
      {
         [Test]
         public void Document_Ticket_Null()
         {
            //arrange
            var documentTicket = "";

            //act+assert
            Assert.ThrowsAsync<ArgumentNullException>(() => SUT().GetDocumentVersions(documentTicket));
         }
      }

      public class DeleteDocumentVersion : UnhappyTests
      {
         [Test]
         public void Document_Ticket_Null()
         {
            //arrange
            var documentTicket = "";
            var versionTicket = "bbb";

            //act+assert
            Assert.ThrowsAsync<ArgumentNullException>(() => SUT().DeleteDocumentVersion(documentTicket, versionTicket));
         }
      }

      public class CreateDocumentAnnotation : UnhappyTests
      {
         [Test]
         public void Document_Ticket_Null()
         {
            //arrange
            var documentTicket = "";
            var annotationVm = new CreateAnnotationVm {Text = "abc", IsPublic = true};

            //act+assert
            Assert.ThrowsAsync<ArgumentNullException>(() => SUT().AddDocumentAnnotation(documentTicket, annotationVm));
         }

         [Test]
         public void Model_Null()
         {
            //arrange
            var documentTicket = "xxx";
            CreateAnnotationVm annotationVm = null;

            //act+assert
            Assert.ThrowsAsync<ArgumentNullException>(() => SUT().AddDocumentAnnotation(documentTicket, annotationVm));
         }
      }

      public class DetDocumentAnnotations : UnhappyTests
      {
         [Test]
         public void Document_Version_Ticket_Null()
         {
            //arrange
            var documentVersionTicket = "";

            //act+assert
            Assert.ThrowsAsync<ArgumentNullException>(() => SUT().GetDocumentAnnotations(documentVersionTicket));
         }
      }

      public class UpdateDocumentAnnotation : UnhappyTests
      {
         [Test]
         public void Document_Version_Ticket_Null()
         {
            //arrange
            var documentVersionTicket = "";
            var annotationTicket = "yyy";
            var updateAnnotationVm = new UpdateAnnotationVm();

            //act+arrange
            Assert.ThrowsAsync<ArgumentNullException>(() => SUT().UpdateDocumentAnnotation(documentVersionTicket, annotationTicket, updateAnnotationVm));
         }

         [Test]
         public void Annotation_Ticket_Null()
         {
            //arrange
            var documentVersionTicket = "xx";
            var annotationTicket = "";
            var updateAnnotationVm = new UpdateAnnotationVm();

            //act+arrange
            Assert.ThrowsAsync<ArgumentNullException>(() => SUT().UpdateDocumentAnnotation(documentVersionTicket, annotationTicket, updateAnnotationVm));
         }
      }
   }
}