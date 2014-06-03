using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.DirectoryServices;
using System.Linq;
using HansKindberg.Abstractions;

namespace HansKindberg.DirectoryServices
{
	[SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "This is a wrapper.")]
	public class PropertyValueCollectionWrapper : Wrapper<PropertyValueCollection>, IPropertyValueCollection
	{
		#region Constructors

		public PropertyValueCollectionWrapper(PropertyValueCollection propertyValueCollection) : base(propertyValueCollection, "propertyValueCollection") {}

		#endregion

		#region Properties

		public virtual int Count
		{
			get { return this.WrappedInstance.Count; }
		}

		public virtual bool IsFixedSize
		{
			get { return ((IList) this.WrappedInstance).IsFixedSize; }
		}

		public virtual bool IsReadOnly
		{
			get { return ((IList) this.WrappedInstance).IsReadOnly; }
		}

		public virtual bool IsSynchronized
		{
			get { return ((ICollection) this.WrappedInstance).IsSynchronized; }
		}

		public virtual object this[int index]
		{
			get { return this.WrappedInstance[index]; }
			set { this.WrappedInstance[index] = value; }
		}

		public virtual string PropertyName
		{
			get { return this.WrappedInstance.PropertyName; }
		}

		public virtual object SyncRoot
		{
			get { return ((ICollection) this.WrappedInstance).SyncRoot; }
		}

		public virtual object Value
		{
			get { return this.WrappedInstance.Value; }
			set { this.WrappedInstance.Value = value; }
		}

		#endregion

		#region Methods

		public virtual void Add(object item)
		{
			this.WrappedInstance.Add(item);
		}

		public virtual void AddRange(IEnumerable<object> collection)
		{
			// ReSharper disable AssignNullToNotNullAttribute
			this.WrappedInstance.AddRange(collection != null ? collection.ToArray() : null);
			// ReSharper restore AssignNullToNotNullAttribute
		}

		public virtual void AddRange(IPropertyValueCollection propertyValueCollection)
		{
			this.WrappedInstance.AddRange(this.GetWrappedPropertyValueCollection(propertyValueCollection));
		}

		public virtual void Clear()
		{
			this.WrappedInstance.Clear();
		}

		public virtual bool Contains(object item)
		{
			return this.WrappedInstance.Contains(item);
		}

		public virtual void CopyTo(object[] array, int arrayIndex)
		{
			this.WrappedInstance.CopyTo(array, arrayIndex);
		}

		public static PropertyValueCollectionWrapper FromPropertyValueCollection(PropertyValueCollection propertyValueCollection)
		{
			return propertyValueCollection;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		public virtual IEnumerator<object> GetEnumerator()
		{
			return this.WrappedInstance.Cast<object>().GetEnumerator();
		}

		protected internal virtual PropertyValueCollection GetWrappedPropertyValueCollection(IPropertyValueCollection propertyValueCollection)
		{
			return this.GetWrappedInstance(propertyValueCollection);
		}

		public virtual int IndexOf(object item)
		{
			return this.WrappedInstance.IndexOf(item);
		}

		public virtual void Insert(int index, object item)
		{
			this.WrappedInstance.Insert(index, item);
		}

		public virtual bool Remove(object item)
		{
			var count = this.Count;

			this.WrappedInstance.Remove(item);

			return count > this.Count;
		}

		public virtual void RemoveAt(int index)
		{
			this.WrappedInstance.RemoveAt(index);
		}

		#endregion

		#region Implicit operator

		public static implicit operator PropertyValueCollectionWrapper(PropertyValueCollection propertyValueCollection)
		{
			return propertyValueCollection == null ? null : new PropertyValueCollectionWrapper(propertyValueCollection);
		}

		#endregion
	}
}