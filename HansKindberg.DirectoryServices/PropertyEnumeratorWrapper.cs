using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.DirectoryServices;
using HansKindberg.Abstractions;

namespace HansKindberg.DirectoryServices
{
	[SuppressMessage("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly", Justification = "This is a wrapper.")]
	public class PropertyEnumeratorWrapper : Wrapper<IDictionaryEnumerator>, IDictionaryEnumerator, IEnumerator<object>
	{
		#region Constructors

		public PropertyEnumeratorWrapper(IDictionaryEnumerator propertyEnumerator) : base(propertyEnumerator, "propertyEnumerator") {}

		#endregion

		#region Properties

		public virtual object Current
		{
			get { return this.Entry.Value; }
		}

		public virtual DictionaryEntry Entry
		{
			get { return new DictionaryEntry(this.WrappedInstance.Entry.Key, (PropertyValueCollectionWrapper) (PropertyValueCollection) this.WrappedInstance.Entry.Value); }
		}

		public virtual object Key
		{
			get { return this.Entry.Key; }
		}

		public virtual object Value
		{
			get { return this.Entry.Value; }
		}

		#endregion

		#region Methods

		[SuppressMessage("Microsoft.Design", "CA1063:ImplementIDisposableCorrectly", Justification = "This is a wrapper.")]
		[SuppressMessage("Microsoft.Usage", "CA1816:CallGCSuppressFinalizeCorrectly", Justification = "This is a wrapper.")]
		public virtual void Dispose()
		{
			IDisposable disposable = this.WrappedInstance as IDisposable;

			if(disposable != null)
				disposable.Dispose();
		}

		public virtual bool MoveNext()
		{
			return this.WrappedInstance.MoveNext();
		}

		public virtual void Reset()
		{
			this.WrappedInstance.Reset();
		}

		#endregion
	}
}