using System;
using System.Linq;
using IntraOffice.Nuget.Catalog.Client.Interfaces.Helpers;
using IntraOffice.Nuget.Catalog.Models.Domain;

namespace IntraOffice.Nuget.Catalog.Client.Services.ModelValidators
{
   internal class ModelValidator4SortOrderVm : IValidateModel<SortOrderVm>
   {
      public void Validate(SortOrderVm model)
      {
         if (model.OrderBy == null || !model.OrderBy.Any())
         {
            throw new ArgumentException("Order by parameters not specified", nameof(model));
         }

         foreach (var s in model.OrderBy)
         {
            ValidateSortExpression(s);
         }
      }

      private void ValidateSortExpression(string sortExpression)
      {
         var arr = sortExpression.Split(new[] {" "}, StringSplitOptions.RemoveEmptyEntries);

         if (arr.Length != 2)
         {
            throw new ArgumentException("Incorrect format sort expression. Expected {elementName} {asc/des}", nameof(sortExpression));
         }

         var sortDirection = arr[1].ToLower();

         if (sortDirection != "asc" && sortDirection != "desc")
         {
            throw new ArgumentException("Sort direction cannot be read. Expected {asc/des}", nameof(sortExpression));
         }
      }
   }
}