using System;
using System.Linq;
using IntraOffice.Nuget.Catalog.Client.Interfaces.Helpers;
using IntraOffice.Nuget.Catalog.Models.Domain.Documents;

namespace IntraOffice.Nuget.Catalog.Client.Services.ModelValidators
{
   internal class ModelValidator4CreateDocumentVm : IValidateModel<CreateDocumentVm>
   {
      public void Validate(CreateDocumentVm model)
      {
         if (model.Content == null || !model.Content.Any())
         {
            throw new ArgumentException("Document content not specified", nameof(model));
         }
      }
   }
}