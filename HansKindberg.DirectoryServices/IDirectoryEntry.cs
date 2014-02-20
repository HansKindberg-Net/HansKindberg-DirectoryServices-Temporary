using System.Collections;
using System.Collections.Generic;

namespace HansKindberg.DirectoryServices
{
	public interface IDirectoryEntry
	{
		#region Properties

		IEnumerable<IDirectoryEntry> Children { get; }
		IDirectoryEntry Parent { get; }
		string Path { get; set; }
		IDictionary Properties { get; }

		#endregion
	}
}