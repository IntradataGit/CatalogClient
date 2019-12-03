using System;
using IntraOffice.Nuget.Catalog.Client.Interfaces.Helpers;
using IntraOffice.Nuget.Catalog.Models.Domain;

namespace IntraOffice.Nuget.Catalog.Client.Services.ModelValidators
{
   internal class ModelValidator4CatalogQueryVm : IValidateModel<CatalogQueryVm>
   {
      public void Validate(CatalogQueryVm model)
      {
         if (model.Query == null)
         {
            throw new ArgumentException("Query body not provided", nameof(model));
         }
      }
   }
}