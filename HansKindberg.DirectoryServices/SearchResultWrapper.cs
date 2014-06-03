using System;
using System.Diagnostics.CodeAnalysis;
using System.DirectoryServices;
using HansKindberg.Abstractions;

namespace HansKindberg.DirectoryServices
{
	public class SearchResultWrapper : Wrapper<SearchResult>
	{


		#region Constructors

		public SearchResultWrapper(SearchResult searchResult) : base(searchResult, "searchResult")
		{

		}

		#endregion

		#region Properties

		public virtual string Path
		{
			get { return this.WrappedInstance.Path; }
		}



		#endregion

		#region Methods

		[SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate", Justification = "This is a wrapper.")]
		public virtual IDirectoryEntry GetDirectoryEntry()
		{
			return (DirectoryEntryWrapper) this.WrappedInstance.GetDirectoryEntry();
		}

		#endregion

		//public virtual IResultPropertyCollection Properties { get; }
	}
}