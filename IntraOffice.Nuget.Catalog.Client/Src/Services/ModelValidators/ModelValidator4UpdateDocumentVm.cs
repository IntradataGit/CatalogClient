using System;
using System.Linq;
using IntraOffice.Nuget.Catalog.Client.Interfaces.Helpers;
using IntraOffice.Nuget.Catalog.Models.Domain.Documents;

namespace IntraOffice.Nuget.Catalog.Client.Services.ModelValidators
{
   internal class ModelValidator4UpdateDocumentVm : IValidateModel<UpdateDocumentVm>
   {
      public void Validate(UpdateDocumentVm model)
      {
         if (model.Elements == null || !model.Elements.Any())
         {
            throw new ArgumentException("No elements provided", nameof(model));
         }
      }
   }
}