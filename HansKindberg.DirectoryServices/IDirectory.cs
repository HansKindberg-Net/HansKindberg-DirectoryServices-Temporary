using System.DirectoryServices;

namespace HansKindberg.DirectoryServices
{
	public interface IDirectory
	{
		#region Properties

		AuthenticationTypes AuthenticationTypes { get; set; }
		string Password { get; set; }
		string UserName { get; set; }

		#endregion

		#region Methods

		bool Exists(string path);
		IDirectoryEntry Get(string path);

		#endregion
	}
}