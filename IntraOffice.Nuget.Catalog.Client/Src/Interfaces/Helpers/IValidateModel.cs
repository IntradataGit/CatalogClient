namespace IntraOffice.Nuget.Catalog.Client.Interfaces.Helpers
{
   internal interface IValidateModel<TModel>
   {
      void Validate(TModel model);
   }
}