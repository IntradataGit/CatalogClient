using System;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Testing.UnitTests;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.UnitTests.UseCases.CatalogViewClientService
{
   public abstract class UnhappyTests : UnitTestBase<ICatalogClient4Views>
   {
      public class GetCategories : UnhappyTests
      {
         [Test]
         public void View_Id_Null()
         {
            //arrange
            var viewId = "";
            var folderId = "dummy";

            //act+assert
            Assert.ThrowsAsync<ArgumentNullException>(() => SUT().GetCategories(viewId, folderId));
         }

         [Test]
         public void Folder_Id_Null()
         {
            //arrange
            var viewId = "dummy";
            var folderId = "";

            //act+assert
            Assert.ThrowsAsync<ArgumentNullException>(() => SUT().GetCategories(viewId, folderId));
         }
      }

      public class GetFolderById : UnhappyTests
      {
         [Test]
         public void View_Id_Null()
         {
            //arrange
            var viewId = "";
            var folderId = "dummy";

            //act+assert
            Assert.ThrowsAsync<ArgumentNullException>(() => SUT().GetViewNodeById(viewId, folderId));
         }

         [Test]
         public void Folder_Id_Null()
         {
            //arrange
            var viewId = "dummy";
            var folderId = "";

            //act+assert
            Assert.ThrowsAsync<ArgumentNullException>(() => SUT().GetViewNodeById(viewId, folderId));
         }
      }

      public class GetViewById : UnhappyTests
      {
         [Test]
         public void View_Id_Null()
         {
            //arrange
            var viewId = "";

            //act+assert
            Assert.ThrowsAsync<ArgumentNullException>(() => SUT().GetViewById(viewId));
         }
      }

      public class FindDocumentsInFolder : UnhappyTests
      {
         [Test]
         public void View_Id_Null()
         {
            //arrange
            var viewId = "";
            var folderId = "V000";
            var searchText = "a";

            //act+assert
            Assert.ThrowsAsync<ArgumentNullException>(() => SUT().FindDocuments(viewId, folderId, searchText));
         }

         [Test]
         public void Folder_Id_Null()
         {
            //arrange
            var viewId = "dummy";
            var folderId = "";
            var searchText = "a";

            //act+assert
            Assert.ThrowsAsync<ArgumentNullException>(() => SUT().FindDocuments(viewId, folderId, searchText));
         }

         [Test]
         public void Search_Text_Null()
         {
            //arrange
            var viewId = "dummy";
            var folderId = "V000";
            var searchText = "";

            //act+assert
            Assert.ThrowsAsync<ArgumentNullException>(() => SUT().FindDocuments(viewId, folderId, searchText));
         }
      }
   }
}