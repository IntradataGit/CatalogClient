using System;
using System.Linq;
using IntraOffice.Nuget.Catalog.Client.Interfaces.Helpers;
using IntraOffice.Nuget.Catalog.Models.Domain.Documents.Versions;

namespace IntraOffice.Nuget.Catalog.Client.Services.ModelValidators
{
   internal class ModelValidator4CreateDocumentVersionVm : IValidateModel<CreateDocumentVersionVm>
   {
      public void Validate(CreateDocumentVersionVm model)
      {
         if (model.Content == null || !model.Content.Any())
         {
            throw new ArgumentException("Content is not provided", nameof(model));
         }
      }
   }
}