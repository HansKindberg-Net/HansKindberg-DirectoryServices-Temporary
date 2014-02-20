using System;
using System.Collections;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;

namespace HansKindberg.DirectoryServices
{
	public class DirectoryEntryWrapper : IDirectoryEntry
	{
		#region Fields

		private readonly DirectoryEntry _directoryEntry;

		#endregion

		#region Constructors

		public DirectoryEntryWrapper(DirectoryEntry directoryEntry)
		{
			if(directoryEntry == null)
				throw new ArgumentNullException("directoryEntry");

			this._directoryEntry = directoryEntry;
		}

		#endregion

		#region Properties

		public virtual IEnumerable<IDirectoryEntry> Children
		{
			get { return this.DirectoryEntry.Children.Cast<DirectoryEntry>().Select(directoryEntry => (DirectoryEntryWrapper) directoryEntry); }
		}

		protected internal virtual DirectoryEntry DirectoryEntry
		{
			get { return this._directoryEntry; }
		}

		public virtual IDirectoryEntry Parent
		{
			get { return (DirectoryEntryWrapper) this.DirectoryEntry.Parent; }
		}

		public virtual string Path
		{
			get { return this.DirectoryEntry.Path; }
			set { this.DirectoryEntry.Path = value; }
		}

		public virtual IDictionary Properties
		{
			get { return this.DirectoryEntry.Properties; }
		}

		#endregion

		#region Implicit operator

		public static implicit operator DirectoryEntryWrapper(DirectoryEntry directoryEntry)
		{
			return directoryEntry == null ? null : new DirectoryEntryWrapper(directoryEntry);
		}

		#endregion
	}
}