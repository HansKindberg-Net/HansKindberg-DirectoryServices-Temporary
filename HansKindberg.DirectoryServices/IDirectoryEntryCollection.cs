﻿using System.Collections.Generic;

namespace HansKindberg.DirectoryServices
{
	public interface IDirectoryEntryCollection : IEnumerable<IDirectoryEntry>
	{
		#region Properties

		ISchemaNameCollection SchemaFilter { get; }

		#endregion

		#region Methods

		IDirectoryEntry Add(string name, string schemaClassName);
		IDirectoryEntry Find(string name);
		IDirectoryEntry Find(string name, string schemaClassName);
		void Remove(IDirectoryEntry directoryEntry);

		#endregion
	}
}