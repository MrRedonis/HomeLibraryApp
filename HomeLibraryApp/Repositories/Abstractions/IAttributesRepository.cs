namespace HomeLibraryApp.Repositories.Abstractions
{
	public interface IAttributesRepository
	{
		Dictionary<string, string> GetAttributesDictionary();
        ICollection<Models.Attribute> GetAttributes();
    }
}
