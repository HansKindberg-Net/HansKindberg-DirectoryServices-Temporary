using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.DirectoryServices;
using HansKindberg.Abstractions;

namespace HansKindberg.DirectoryServices
{
	[SuppressMessage("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly", Justification = "This is a wrapper.")]
	public class DirectoryEntryWrapper : Wrapper<DirectoryEntry>, IDirectoryEntry
	{
		#region Constructors

		public DirectoryEntryWrapper(DirectoryEntry directoryEntry) : base(directoryEntry, "directoryEntry") {}

		#endregion

		#region Events

		public virtual event EventHandler Disposed
		{
			add { this.WrappedInstance.Disposed += value; }
			remove { this.WrappedInstance.Disposed -= value; }
		}

		#endregion

		#region Properties

		public virtual IDirectoryEntryCollection Children
		{
			get { return (DirectoryEntriesWrapper) this.WrappedInstance.Children; }
		}

		public virtual Guid Guid
		{
			get { return this.WrappedInstance.Guid; }
		}

		public virtual string Name
		{
			get { return this.WrappedInstance.Name; }
		}

		public virtual string NativeGuid
		{
			get { return this.WrappedInstance.NativeGuid; }
		}

		public virtual object NativeObject
		{
			get { return this.WrappedInstance.NativeObject; }
		}

		public virtual IDirectoryEntryConfiguration Options
		{
			get { return (DirectoryEntryConfigurationWrapper) this.WrappedInstance.Options; }
		}

		public virtual IDirectoryEntry Parent
		{
			get { return (DirectoryEntryWrapper) this.WrappedInstance.Parent; }
		}

		public virtual string Path
		{
			get { return this.WrappedInstance.Path; }
			set { this.WrappedInstance.Path = value; }
		}

		public virtual IPropertyDictionary Properties
		{
			get { return (PropertyCollectionWrapper) this.WrappedInstance.Properties; }
		}

		public virtual string SchemaClassName
		{
			get { return this.WrappedInstance.SchemaClassName; }
		}

		public virtual IDirectoryEntry SchemaEntry
		{
			get { return (DirectoryEntryWrapper) this.WrappedInstance.SchemaEntry; }
		}

		public virtual ISite Site
		{
			get { return this.WrappedInstance.Site; }
			set { this.WrappedInstance.Site = value; }
		}

		public virtual bool UsePropertyCache
		{
			get { return this.WrappedInstance.UsePropertyCache; }
			set { this.WrappedInstance.UsePropertyCache = value; }
		}

		#endregion

		#region Methods

		public virtual void Close()
		{
			this.WrappedInstance.Close();
		}

		public virtual void CommitChanges()
		{
			this.WrappedInstance.CommitChanges();
		}

		public virtual IDirectoryEntry CopyTo(IDirectoryEntry newParent)
		{
			return (DirectoryEntryWrapper) this.WrappedInstance.CopyTo(this.GetWrappedDirectoryEntry(newParent));
		}

		public virtual IDirectoryEntry CopyTo(IDirectoryEntry newParent, string newName)
		{
			return (DirectoryEntryWrapper) this.WrappedInstance.CopyTo(this.GetWrappedDirectoryEntry(newParent), newName);
		}

		public virtual void DeleteTree()
		{
			this.WrappedInstance.DeleteTree();
		}

		[SuppressMessage("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly", Justification = "This is a wrapper.")]
		[SuppressMessage("Microsoft.Usage", "CA1816:CallGCSuppressFinalizeCorrectly", Justification = "This is a wrapper.")]
		public virtual void Dispose()
		{
			this.WrappedInstance.Dispose();
		}

		public static DirectoryEntryWrapper FromDirectoryEntry(DirectoryEntry directoryEntry)
		{
			return directoryEntry;
		}

		protected internal virtual DirectoryEntry GetWrappedDirectoryEntry(IDirectoryEntry directoryEntry)
		{
			return this.GetWrappedInstance(directoryEntry);
		}

		public virtual object Invoke(string methodName, params object[] args)
		{
			return this.WrappedInstance.Invoke(methodName, args);
		}

		public virtual object InvokeGet(string propertyName)
		{
			return this.WrappedInstance.InvokeGet(propertyName);
		}

		public virtual void InvokeSet(string propertyName, params object[] args)
		{
			this.WrappedInstance.InvokeSet(propertyName, args);
		}

		public virtual void MoveTo(IDirectoryEntry newParent)
		{
			this.WrappedInstance.MoveTo(this.GetWrappedDirectoryEntry(newParent));
		}

		public virtual void MoveTo(IDirectoryEntry newParent, string newName)
		{
			this.WrappedInstance.MoveTo(this.GetWrappedDirectoryEntry(newParent), newName);
		}

		public virtual void RefreshCache()
		{
			this.WrappedInstance.RefreshCache();
		}

		public virtual void RefreshCache(string[] propertyNames)
		{
			this.WrappedInstance.RefreshCache(propertyNames);
		}

		public virtual void Rename(string newName)
		{
			this.WrappedInstance.Rename(newName);
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