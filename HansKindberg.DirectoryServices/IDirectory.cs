namespace HansKindberg.DirectoryServices
{
	public interface IDirectory
	{
		#region Methods

		bool Exists(string path);

		#endregion
	}
}