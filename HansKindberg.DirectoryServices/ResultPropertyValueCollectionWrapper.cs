using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.DirectoryServices;
using System.Linq;
using HansKindberg.Abstractions;

namespace HansKindberg.DirectoryServices
{
	[SuppressMessage("Microsoft.Design", "CA1035:ICollectionImplementationsHaveStronglyTypedMembers")]
	[SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "This is a wrapper.")]
	public class ResultPropertyValueCollectionWrapper : Wrapper<ResultPropertyValueCollection>, IResultPropertyValueCollection
	{
		#region Constructors

		public ResultPropertyValueCollectionWrapper(ResultPropertyValueCollection resultPropertyValueCollection) : base(resultPropertyValueCollection, "resultPropertyValueCollection") {}

		#endregion

		#region Properties

		public virtual int Count
		{
			get { return this.WrappedInstance.Count; }
		}

		public virtual bool IsSynchronized
		{
			get { return ((ICollection) this.WrappedInstance).IsSynchronized; }
		}

		public virtual object this[int index]
		{
			get { return this.WrappedInstance[index]; }
		}

		public virtual object SyncRoot
		{
			get { return ((ICollection) this.WrappedInstance).SyncRoot; }
		}

		#endregion

		#region Methods

		public virtual bool Contains(object item)
		{
			return this.WrappedInstance.Contains(item);
		}

		public virtual void CopyTo(object[] array, int arrayIndex)
		{
			this.WrappedInstance.CopyTo(array, arrayIndex);
		}

		public virtual void CopyTo(Array array, int index)
		{
			((ICollection) this.WrappedInstance).CopyTo(array, index);
		}

		public static ResultPropertyValueCollectionWrapper FromResultPropertyValueCollection(ResultPropertyValueCollection resultPropertyValueCollection)
		{
			return resultPropertyValueCollection;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		public virtual IEnumerator<object> GetEnumerator()
		{
			return this.WrappedInstance.Cast<object>().GetEnumerator();
		}

		public virtual int IndexOf(object item)
		{
			return this.WrappedInstance.IndexOf(item);
		}

		#endregion

		#region Implicit operator

		public static implicit operator ResultPropertyValueCollectionWrapper(ResultPropertyValueCollection resultPropertyValueCollection)
		{
			return resultPropertyValueCollection == null ? null : new ResultPropertyValueCollectionWrapper(resultPropertyValueCollection);
		}

		#endregion
	}
}