using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace IntraOffice.Nuget.Catalog.Models.Domain.Configuration
{
   /// <summary>
   /// This represents 'document class'
   /// </summary>
   public class ClassVm
   {
      /// <summary>
      /// Unique identifier
      /// </summary>
      [Required]
      public string Id { get; set; }

      /// <summary>
      /// User friendly name
      /// </summary>
      [Required]
      public string Title { get; set; }

      /// <summary>
      /// Id's of elements that this document class consists of
      /// </summary>
      public IEnumerable<ElementRefVm> Elements { get; set; }

      /// <summary>
      /// Id's of entities to which documents that belong to that document class can be linked to
      /// </summary>
      public IEnumerable<EntityRefVm> Entities { get; set; }

      /// <summary>
      /// Id's of events that documents that belong to that document class can 'fire'
      /// </summary>
      public IEnumerable<string> Events { get; set; }
   }
}