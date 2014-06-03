using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.DirectoryServices;
using System.Linq;
using HansKindberg.Abstractions;
using HansKindberg.Abstractions.Extensions;

namespace HansKindberg.DirectoryServices
{
	[SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "This is a wrapper.")]
	public class DirectoryEntriesWrapper : Wrapper<DirectoryEntries>, IDirectoryEntryCollection
	{
		#region Constructors

		public DirectoryEntriesWrapper(DirectoryEntries directoryEntries) : base(directoryEntries, "directoryEntries") {}

		#endregion

		#region Properties

		public virtual ISchemaNameCollection SchemaFilter
		{
			get { return (SchemaNameCollectionWrapper) this.WrappedInstance.SchemaFilter; }
		}

		#endregion

		#region Methods

		public virtual IDirectoryEntry Add(string name, string schemaClassName)
		{
			return (DirectoryEntryWrapper) this.WrappedInstance.Add(name, schemaClassName);
		}

		public virtual IDirectoryEntry Find(string name)
		{
			return (DirectoryEntryWrapper) this.WrappedInstance.Find(name);
		}

		public virtual IDirectoryEntry Find(string name, string schemaClassName)
		{
			return (DirectoryEntryWrapper) this.WrappedInstance.Find(name, schemaClassName);
		}

		public static DirectoryEntriesWrapper FromDirectoryEntries(DirectoryEntries directoryEntries)
		{
			return directoryEntries;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		public virtual IEnumerator<IDirectoryEntry> GetEnumerator()
		{
			return this.WrappedInstance.Cast<DirectoryEntry>().Select(directoryEntry => (DirectoryEntryWrapper) directoryEntry).GetEnumerator();
		}

		protected internal virtual DirectoryEntry GetWrappedDirectoryEntry(IDirectoryEntry directoryEntry)
		{
			return directoryEntry.GetWrappedInstance<DirectoryEntry>();
		}

		public virtual void Remove(IDirectoryEntry directoryEntry)
		{
			this.WrappedInstance.Remove(this.GetWrappedDirectoryEntry(directoryEntry));
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