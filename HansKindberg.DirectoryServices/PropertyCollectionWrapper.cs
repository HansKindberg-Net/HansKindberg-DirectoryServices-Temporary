using System;
using System.Collections;
using System.Diagnostics.CodeAnalysis;
using System.DirectoryServices;
using System.Linq;
using HansKindberg.Abstractions;
using HansKindberg.Abstractions.Extensions;

namespace HansKindberg.DirectoryServices
{
	[SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "This is a wrapper.")]
	public class PropertyCollectionWrapper : Wrapper<PropertyCollection>, IPropertyDictionary
	{
		#region Constructors

		public PropertyCollectionWrapper(PropertyCollection propertyCollection) : base(propertyCollection, "propertyCollection") {}

		#endregion

		#region Properties

		public virtual int Count
		{
			get { return this.WrappedInstance.Count; }
		}

		public virtual bool IsFixedSize
		{
			get { return ((IDictionary) this.WrappedInstance).IsFixedSize; }
		}

		public virtual bool IsReadOnly
		{
			get { return ((IDictionary) this.WrappedInstance).IsReadOnly; }
		}

		public virtual bool IsSynchronized
		{
			get { return ((ICollection) this.WrappedInstance).IsSynchronized; }
		}

		public virtual IPropertyValueCollection this[string propertyName]
		{
			get { return (PropertyValueCollectionWrapper) this.WrappedInstance[propertyName]; }
		}

		public virtual object this[object key]
		{
			get { return ((IDictionary) this.WrappedInstance)[key]; }
			set { ((IDictionary) this.WrappedInstance)[key] = value; }
		}

		public virtual ICollection Keys
		{
			get { return ((IDictionary) this.WrappedInstance).Keys; }
		}

		public virtual ICollection PropertyNames
		{
			get { return this.WrappedInstance.PropertyNames; }
		}

		public virtual object SyncRoot
		{
			get { return ((ICollection) this.WrappedInstance).SyncRoot; }
		}

		public virtual ICollection Values
		{
			get { return this.WrappedInstance.Values.Cast<PropertyValueCollection>().Select(propertyValueCollection => (PropertyValueCollectionWrapper) propertyValueCollection).ToList(); }
		}

		#endregion

		#region Methods

		public virtual void Add(object key, object value)
		{
			((IDictionary) this.WrappedInstance).Add(key, value);
		}

		public virtual void Clear()
		{
			((IDictionary) this.WrappedInstance).Clear();
		}

		bool IDictionary.Contains(object key)
		{
			return ((IDictionary) this.WrappedInstance).Contains(key);
		}

		public virtual bool Contains(string propertyName)
		{
			return this.WrappedInstance.Contains(propertyName);
		}

		void ICollection.CopyTo(Array array, int index)
		{
			((ICollection) this.WrappedInstance).CopyTo(array, index);
		}

		public virtual void CopyTo(IPropertyValueCollection[] array, int index)
		{
			this.WrappedInstance.CopyTo(array.Select(this.GetWrappedPropertyValueCollection).ToArray(), index);
		}

		public static PropertyCollectionWrapper FromPropertyCollection(PropertyCollection propertyCollection)
		{
			return propertyCollection;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		[SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope", Justification = "Should be disposed by the caller.")]
		public virtual IDictionaryEnumerator GetEnumerator()
		{
			return new PropertyEnumeratorWrapper(this.WrappedInstance.GetEnumerator());
		}

		protected internal virtual PropertyValueCollection GetWrappedPropertyValueCollection(IPropertyValueCollection propertyValueCollection)
		{
			return propertyValueCollection.GetWrappedInstance<PropertyValueCollection>();
		}

		public virtual void Remove(object key)
		{
			((IDictionary) this.WrappedInstance).Remove(key);
		}

		#endregion

		#region Implicit operator

		public static implicit operator PropertyCollectionWrapper(PropertyCollection propertyCollection)
		{
			return propertyCollection == null ? null : new PropertyCollectionWrapper(propertyCollection);
		}

		#endregion
	}
}