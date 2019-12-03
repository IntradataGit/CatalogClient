using System;
using IntraOffice.Nuget.Catalog.Client.Interfaces.Helpers;
using IntraOffice.Nuget.Catalog.Models.Domain.Configuration;
using IntraOffice.Nuget.Testing.Abstractions.ObjectExtensions;
using IntraOffice.Nuget.Testing.Abstractions.TestExtensions;
using IntraOffice.Nuget.Testing.UnitTests;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace IntraOffice.Nuget.Catalog.Client.UnitTests.UseCases.Deserialization.DateTimeElement
{
   [TestFixture]
   public class HappyTests : UnitTestBase
   {
      private ISerializeObject _sut;

      [SetUp]
      public void SetUp2()
      {
         _sut = Container.GetInstance<ISerializeObject>();
      }

      [Test]
      public void Dummy()
      {
         Console.WriteLine(Container.WhatDidIScan());
      }

      [Test]
      public void All()
      {
         //arrange
         var embeddedText = this.GetEmbeddedText("elements.json");
         var jArray = JArray.Parse(embeddedText);

         foreach (var jToken in jArray)
         {
            var jsonText = jToken.ToString();

            var obj = _sut.DeserializeObject<ElementVm>(jsonText);

            obj.Print();
         }
      }

      [Test]
      public void DateTime()
      {
         //arrange
         var embeddedText = this.GetEmbeddedText("elements.json");
         var jArray = JArray.Parse(embeddedText);

         foreach (var jToken in jArray)
         {
            var jsonText = jToken.ToString();

            if (jsonText.Contains("date-time"))
            {
               var obj = _sut.DeserializeObject<ElementVm>(jsonText);

               obj.Print();
            }
         }
      }

      [Test]
      public void Number()
      {
         //arrange
         var embeddedText = this.GetEmbeddedText("elements.json");
         var jArray = JArray.Parse(embeddedText);

         foreach (var jToken in jArray)
         {
            var jsonText = jToken.ToString();

            if (jsonText.Contains("number"))
            {
               var obj = _sut.DeserializeObject<ElementVm>(jsonText);

               obj.Print();
            }
         }
      }

      [Test]
      public void String()
      {
         //arrange
         var embeddedText = this.GetEmbeddedText("elements.json");
         var jArray = JArray.Parse(embeddedText);

         foreach (var jToken in jArray)
         {
            var jsonText = jToken.ToString();

            if (jsonText.Contains("string"))
            {
               var obj = _sut.DeserializeObject<ElementVm>(jsonText);

               obj.Print();
            }
         }
      }
   }
}