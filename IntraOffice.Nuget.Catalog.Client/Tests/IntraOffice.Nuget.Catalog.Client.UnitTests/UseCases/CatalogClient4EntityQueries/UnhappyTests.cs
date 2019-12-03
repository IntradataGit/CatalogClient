using System;
using System.Collections.Generic;
using IntraOffice.Nuget.Catalog.Client.Interfaces;
using IntraOffice.Nuget.Catalog.Models.Domain;
using IntraOffice.Nuget.Testing.UnitTests;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.UnitTests.UseCases.CatalogClient4EntityQueries
{
   public abstract class UnhappyTests : UnitTestBase<ICatalogClient4EntityQueries>
   {
      public class FindEntities : UnhappyTests
      {
         [Test]
         public void Entity_Id_Null()
         {
            //arrange
            var entityId = "";
            var queryVm = new CatalogQueryVm
            {
               Query = new CatalogQueryContentVm
               {
                  Select = new[] {"tence-flexcollegaPNR"},
                  Where = new Dictionary<string, object> {{"tence-flexcollegaPNR", 123}}
               }
            };

            //assert
            Assert.ThrowsAsync<ArgumentNullException>(() => SUT().FindEntities(entityId, queryVm));
         }

         [Test]
         public void Query_Model_Null()
         {
            //arrange
            var entityId = "tence-flexcollega";
            CatalogQueryVm queryVm = null;

            //act+assert
            Assert.ThrowsAsync<ArgumentNullException>(() => SUT().FindEntities(entityId, queryVm));
         }

         [Test]
         public void Invalid_Query_Model()
         {
            //arrange
            var entityId = "tence-flexcollega";
            var queryVm = new CatalogQueryVm();

            //act+assert
            Assert.ThrowsAsync<ArgumentException>(() => SUT().FindEntities(entityId, queryVm));
         }
      }

      public class FindEntities2 : UnhappyTests
      {
         [Test]
         public void Entity_Id_Null()
         {
            //arrange
            var entityId = "";
            var searchText = "a";

            //act+assert
            Assert.ThrowsAsync<ArgumentNullException>(() => SUT().FindEntities(entityId, searchText));
         }
      }

      public class GetEntitySetMetadata : UnhappyTests
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