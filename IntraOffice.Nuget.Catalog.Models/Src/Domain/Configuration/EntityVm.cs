using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IntraOffice.Nuget.Catalog.Models.Domain.Configuration
{
   /// <summary>
   /// This class represents entity
   /// </summary>
   public class EntityVm 
   {
      /// <summary>
      /// Unique id
      /// </summary>
      [Required]
      public string Id { get; set; }

      /// <summary>
      /// User friendly display name
      /// </summary>
      [Required]
      public string Title { get; set; }

      public string Parent { get; set; }

      [Required]
      public string Type { get; set; }

      /// <summary>
      /// Id's of elements the entity consists of
      /// </summary>
      public IEnumerable<ElementRefVm> Elements { get; set; }

      /// <summary>
      /// Entity identifiers. Each identifier is a collection of elements that
      /// uniquely identify an entity
      /// </summary>
      public IEnumerable<SchemaIdentifierVm> Identifiers { get; set; }

      /// <summary>
      /// List of events the entity supports
      /// </summary>
      public IEnumerable<string> Events { get; set; }
   }
}