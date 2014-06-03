using System.DirectoryServices;
using HansKindberg.Abstractions;

namespace HansKindberg.DirectoryServices
{
	public class DirectorySearcherWrapper : Wrapper<DirectorySearcher>
	{
		#region Constructors

		public DirectorySearcherWrapper(DirectorySearcher directorySearcher) : base(directorySearcher, "directorySearcher") {}

		#endregion

		#region Methods

		public virtual void Dispose()
		{
			this.WrappedInstance.Dispose();
		}

		public virtual SearchResultCollection FindAll()
		{
			return this.WrappedInstance.FindAll();
		}

		public virtual SearchResult FindOne()
		{
			return this.WrappedInstance.FindOne();
		}

		#endregion

		//public virtual bool Asynchronous { get; set; }
		//public virtual string AttributeScopeQuery { get; set; }
		//public virtual bool CacheResults { get; set; }
		//public virtual TimeSpan ClientTimeout { get; set; }
		//public virtual DereferenceAlias DerefAlias { get; set; }
		//public virtual DirectorySynchronization DirectorySynchronization { get; set; }
		//public virtual ExtendedDN ExtendedDN { get; set; }
		//public virtual string Filter { get; set; }
		//public virtual int PageSize { get; set; }
		//public virtual StringCollection PropertiesToLoad { get; }
		//public virtual bool PropertyNamesOnly { get; set; }
		//public virtual ReferralChasingOption ReferralChasing { get; set; }
		//public virtual DirectoryEntry SearchRoot { get; set; }
		//public virtual SearchScope SearchScope { get; set; }
		//public virtual SecurityMasks SecurityMasks { get; set; }
		//public virtual TimeSpan ServerPageTimeLimit { get; set; }
		//public virtual TimeSpan ServerTimeLimit { get; set; }
		//public virtual int SizeLimit { get; set; }
		//public virtual SortOption Sort { get; set; }
		//public virtual bool Tombstone { get; set; }
		//public virtual DirectoryVirtualListView VirtualListView { get; set; }
	}
}