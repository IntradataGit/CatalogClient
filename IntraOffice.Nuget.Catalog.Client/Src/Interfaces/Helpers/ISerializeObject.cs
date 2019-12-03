namespace IntraOffice.Nuget.Catalog.Client.Interfaces.Helpers
{
   /// <summary>
   ///    This interface represents help service to perform object from/to text conversions
   /// </summary>
   internal interface ISerializeObject
   {
      TObject DeserializeObject<TObject>(string text);

      string SerializeObject<TObject>(TObject obj);
   }
}