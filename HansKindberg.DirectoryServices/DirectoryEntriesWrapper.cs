using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.DirectoryServices;
using System.Linq;
using HansKindberg.DirectoryServices.Extensions;

namespace HansKindberg.DirectoryServices
{
	[SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "This is a wrapper.")]
	public class DirectoryEntriesWrapper : IDirectoryEntryCollection
	{
		#region Fields

		private readonly DirectoryEntries _directoryEntries;

		#endregion

		#region Constructors

		public DirectoryEntriesWrapper(DirectoryEntries directoryEntries)
		{
			if(directoryEntries == null)
				throw new ArgumentNullException("directoryEntries");

			this._directoryEntries = directoryEntries;
		}

		#endregion

		#region Properties

		public virtual DirectoryEntries DirectoryEntries
		{
			get { return this._directoryEntries; }
		}

		public virtual ISchemaNameCollection SchemaFilter
		{
			get { return (SchemaNameCollectionWrapper) this.DirectoryEntries.SchemaFilter; }
		}

		#endregion

		#region Methods

		public virtual IDirectoryEntry Add(string name, string schemaClassName)
		{
			return (DirectoryEntryWrapper) this.DirectoryEntries.Add(name, schemaClassName);
		}

		public virtual IDirectoryEntry Find(string name)
		{
			return (DirectoryEntryWrapper) this.DirectoryEntries.Find(name);
		}

		public virtual IDirectoryEntry Find(string name, string schemaClassName)
		{
			return (DirectoryEntryWrapper) this.DirectoryEntries.Find(name, schemaClassName);
		}

		public static DirectoryEntriesWrapper FromDirectoryEntries(DirectoryEntries directoryEntries)
		{
			return directoryEntries;
		}

		public virtual IEnumerator<IDirectoryEntry> GetEnumerator()
		{
			return this.DirectoryEntries.Cast<DirectoryEntry>().Select(directoryEntry => (DirectoryEntryWrapper) directoryEntry).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		public virtual void Remove(IDirectoryEntry entry)
		{
			this.DirectoryEntries.Remove(this.GetDirectoryEntry(entry));
		}

		#endregion

		#region Implicit operator

		public static implicit operator DirectoryEntriesWrapper(DirectoryEntries directoryEntries)
		{
			return directoryEntries == null ? null : new DirectoryEntriesWrapper(directoryEntries);
		}

		#endregion
	}
}