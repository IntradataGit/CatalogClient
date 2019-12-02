using System;
using System.ComponentModel.DataAnnotations;

namespace IntraOffice.Nuget.Catalog.Models.Domain.Configuration
{
   /// <summary>
   /// This class represents 'element'
   /// </summary>
   public class ElementVm 
   {
      /// <summary>
      /// Element id
      /// </summary>
      [Required]
      public string Id { get; set; }

      /// <summary>
      /// Element display name
      /// </summary>
      [Required]
      public string Title { get; set; }

      /// <summary>
      /// Name of Catalog type (string, date, number, etc) 
      /// </summary>
      [Required]
      public string Type { get; set; }

      /// <summary>
      /// Is element read only
      /// </summary>
      [Required]
      public bool IsReadOnly { get; set; }
   }

   public class DateTimeElementVm : ElementVm
   {
      public DateTimeValidationVm Validation { get; set; }
   }

   public class NumericElementVm : ElementVm
   {
      public NumericValidationVm Validation { get; set; }
   }

   public class StringElementVm : ElementVm
   {
      public StringValidationVm Validation { get; set; }
   }

   public class DateTimeValidationVm
   {
      public DateTime? Maximum { get; set; }

      public DateTime? Minimum { get; set; }

      public bool? ExclusiveMaximum { get; set; }

      public bool? ExclusiveMinimum { get; set; }
   }

   public class StringValidationVm
   {
      public int MaxLength { get; set; }

      public int MinLength { get; set; }

      public string Pattern { get; set; }
   }

   public class NumericValidationVm
   {
      public long? Maximum { get; set; }

      public long? Minimum { get; set; }

      public bool? ExclusiveMaximum { get; set; }

      public bool? ExclusiveMinimum { get; set; }

      public long TotalDigits { get; set; }

      public long[] Enumeration { get; set; }
   }
}