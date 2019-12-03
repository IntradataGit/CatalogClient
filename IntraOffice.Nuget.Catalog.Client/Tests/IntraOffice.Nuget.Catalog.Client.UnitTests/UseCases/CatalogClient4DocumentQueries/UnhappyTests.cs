using System;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Models.Domain;
using IntraOffice.Nuget.Testing.UnitTests;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.UnitTests.UseCases.CatalogClient4DocumentQueries
{
   public abstract class UnhappyTests : UnitTestBase<ICatalogClient4DocumentQueries>
   {
      public class FindDocuments : UnhappyTests
      {
         [Test]
         public void Model_Null()
         {
            //arrange
            CatalogQueryVm queryVm = null;

            //act+assert
            Assert.ThrowsAsync<ArgumentNullException>(() => SUT().FindDocuments(queryVm));
         }

         [Test]
         public void Bad_Model()
         {
            //arrange
            var queryVm = new CatalogQueryVm();

            //act+assert
            Assert.ThrowsAsync<ArgumentException>(() => SUT().FindDocuments(queryVm));
         }
      }

      public class FindDocumentsWithCategory : UnhappyTests
      {
         [Test]
         public void Category_Id_Null()
         {
            //arrange
            var categoryId = "";
            var searchText = "a";

            //act+assert
            Assert.ThrowsAsync<ArgumentNullException>(() => SUT().FindDocumentsWithinCategory(categoryId, searchText));
         }
      }

      public class FindDocumentsWithClass : UnhappyTests
      {
         [Test]
         public void Class_Id_Null()
         {
            //arrange
            var classId = "";
            var searchText = "a";

            //act+assert
            Assert.ThrowsAsync<ArgumentNullException>(() => SUT().FindDocumentsWithinClass(classId, searchText));
         }
      }

      public class GetResultsetMetadata : UnhappyTests
      {
         [Test]
         public void Resultset_Ticket_Null()
         {
            //arrange
            var resultsetTicket = "";

            //act+assert
            Assert.ThrowsAsync<ArgumentNullException>(() => SUT().GetQueryResultMetadata(resultsetTicket));
         }
      }

      public class GetAllRows : UnhappyTests
      {
         [Test]
         public void Resultset_Ticket_Null()
         {
            //arrange

            var resultSetTicket = "";

            //act+assert
            Assert.ThrowsAsync<ArgumentNullException>(() => SUT().GetAllRows(resultSetTicket));
         }
      }

      public class GetSpecificRow : UnhappyTests
      {
         [Test]
         public void Resultset_Ticket_Null()
         {
            //arrange
            var resultSetTicket = "";
            var rowIndex = 0;

            //assert
            Assert.ThrowsAsync<ArgumentNullException>(() => SUT().GetSpecificRow(resultSetTicket, rowIndex));
         }

         [Test]
         public void Negative_Row_Index()
         {
            //arrange
            var resultSetTicket = "xxx";
            var rowIndex = -1;

            //assert
            Assert.ThrowsAsync<ArgumentException>(() => SUT().GetSpecificRow(resultSetTicket, rowIndex));
         }
      }

      public class GetSpecificRows : UnhappyTests
      {
         [Test]
         public void Resultset_Ticket_Null()
         {
            //arrange
            var resultSetTicket = "";
            var numberRowsToSkip = 0;
            var numberRowsToTake = 1;

            //act+assert
            Assert.ThrowsAsync<ArgumentNullException>(() => SUT().GetSpecificRows(resultSetTicket, numberRowsToSkip, numberRowsToTake));
         }

         [Test]
         public void Number_Rows_To_Skip_Negative()
         {
            //arrange
            var resultSetTicket = "dummy";
            var numberRowsToSkip = -1;
            var numberRowsToTake = 1;

            //act+assert
            Assert.ThrowsAsync<ArgumentException>(() => SUT().GetSpecificRows(resultSetTicket, numberRowsToSkip, numberRowsToTake));
         }

         [Test]
         public void Number_Rows_To_Take_Negative()
         {
            //arrange
            var resultSetTicket = "dummy";
            var numberRowsToSkip = 1;
            var numberRowsToTake = -1;

            //act+assert
            Assert.ThrowsAsync<ArgumentException>(() => SUT().GetSpecificRows(resultSetTicket, numberRowsToSkip, numberRowsToTake));
         }

         [Test]
         public void Number_Rows_To_Take_Nul()
         {
            //arrange
            var resultSetTicket = "dummy";
            var numberRowsToSkip = 1;
            var numberRowsToTake = 0;

            //act+assert
            Assert.ThrowsAsync<ArgumentException>(() => SUT().GetSpecificRows(resultSetTicket, numberRowsToSkip, numberRowsToTake));
         }
      }

      public class ChangeSortOder : UnhappyTests
      {
         [Test]
         public void Resultset_Ticket_Null()
         {
            //arrange
            var resultsetTicket = "";
            var model = new SortOrderVm
            {
               OrderBy = new[]
               {
                  "tence-flexcollegaPNR desc"
               }
            };

            //act+assert
            Assert.ThrowsAsync<ArgumentNullException>(() => SUT().ChangeSortOder(resultsetTicket, model));
         }

         [Test]
         public void Model_Null()
         {
            //arrange
            var resultsetTicket = "someticket";
            SortOrderVm model = null;

            //act+assert
            Assert.ThrowsAsync<ArgumentNullException>(() => SUT().ChangeSortOder(resultsetTicket, model));
         }

         [Test]
         public void Bad_Model()
         {
            //arrange
            var resultsetTicket = "someticket";
            var model = new SortOrderVm();

            //act+assert
            Assert.ThrowsAsync<ArgumentException>(() => SUT().ChangeSortOder(resultsetTicket, model));
         }

         [Test]
         public void Bad_Model_1()
         {
            //arrange
            var resultsetTicket = "someticket";
            var model = new SortOrderVm {OrderBy = new[] {"dummy"}};

            //act+assert
            Assert.ThrowsAsync<ArgumentException>(() => SUT().ChangeSortOder(resultsetTicket, model));
         }

         [Test]
         public void Bad_Model_2()
         {
            //arrange
            var resultsetTicket = "someticket";
            var model = new SortOrderVm {OrderBy = new[] {"dummy abc"}};

            //act+assert
            Assert.ThrowsAsync<ArgumentException>(() => SUT().ChangeSortOder(resultsetTicket, model));
         }
      }

      public class GetSortOrder : UnhappyTests
      {
         [Test]
         public void Resultset_Ticket_Null()
         {
            //arrange
            var resultsetTicket = "";

            //act+assert
            Assert.ThrowsAsync<ArgumentNullException>(() => SUT().GetSortOrder(resultsetTicket));
         }
      }
   }
}