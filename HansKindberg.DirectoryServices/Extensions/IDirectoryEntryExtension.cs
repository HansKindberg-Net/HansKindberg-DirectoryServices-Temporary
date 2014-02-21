using System.DirectoryServices;

namespace HansKindberg.DirectoryServices.Extensions
{
	public interface IDirectoryEntryExtension
	{
		#region Methods

		DirectoryEntry GetDirectoryEntry(IDirectoryEntry directoryEntry);

		#endregion
	}
}