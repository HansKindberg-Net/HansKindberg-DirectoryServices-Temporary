using System.DirectoryServices;

namespace HansKindberg.DirectoryServices
{
	public interface IDirectoryEntryInternal
	{
		#region Properties

		DirectoryEntry DirectoryEntry { get; }

		#endregion
	}
}