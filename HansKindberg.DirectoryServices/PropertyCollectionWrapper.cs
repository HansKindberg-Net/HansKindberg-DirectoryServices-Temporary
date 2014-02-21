﻿using System;
using System.Collections;
using System.DirectoryServices;
using System.Linq;
using HansKindberg.DirectoryServices.Extensions;

namespace HansKindberg.DirectoryServices
{
	public class PropertyCollectionWrapper : IPropertyCollection
	{
		#region Fields

		private readonly PropertyCollection _propertyCollection;

		#endregion

		#region Constructors

		public PropertyCollectionWrapper(PropertyCollection propertyCollection)
		{
			if(propertyCollection == null)
				throw new ArgumentNullException("propertyCollection");

			this._propertyCollection = propertyCollection;
		}

		#endregion

		#region Properties

		public virtual int Count
		{
			get { return this.PropertyCollection.Count; }
		}

		bool IDictionary.IsFixedSize
		{
			get { return ((IDictionary) this.PropertyCollection).IsFixedSize; }
		}

		bool IDictionary.IsReadOnly
		{
			get { return ((IDictionary) this.PropertyCollection).IsReadOnly; }
		}

		bool ICollection.IsSynchronized
		{
			get { return ((ICollection) this.PropertyCollection).IsSynchronized; }
		}

		public virtual IPropertyValueCollection this[string propertyName]
		{
			get { return (PropertyValueCollectionWrapper) this.PropertyCollection[propertyName]; }
		}

		object IDictionary.this[object key]
		{
			get { return ((IDictionary) this.PropertyCollection)[key]; }
			set { ((IDictionary) this.PropertyCollection)[key] = value; }
		}

		ICollection IDictionary.Keys
		{
			get { return ((IDictionary) this.PropertyCollection).Keys; }
		}

		public virtual PropertyCollection PropertyCollection
		{
			get { return this._propertyCollection; }
		}

		public virtual ICollection PropertyNames
		{
			get { return this.PropertyCollection.PropertyNames; }
		}

		object ICollection.SyncRoot
		{
			get { return ((ICollection) this.PropertyCollection).SyncRoot; }
		}

		public virtual ICollection Values
		{
			get { return this.PropertyCollection.Values.Cast<PropertyValueCollection>().Select(propertyValueCollection => (PropertyValueCollectionWrapper) propertyValueCollection).ToList(); }
		}

		#endregion

		#region Methods

		void IDictionary.Add(object key, object value)
		{
			((IDictionary) this.PropertyCollection).Add(key, value);
		}

		void IDictionary.Clear()
		{
			((IDictionary) this.PropertyCollection).Clear();
		}

		bool IDictionary.Contains(object key)
		{
			return ((IDictionary) this.PropertyCollection).Contains(key);
		}

		public virtual bool Contains(string propertyName)
		{
			return this.PropertyCollection.Contains(propertyName);
		}

		void ICollection.CopyTo(Array array, int index)
		{
			((ICollection) this.PropertyCollection).CopyTo(array, index);
		}

		public virtual void CopyTo(IPropertyValueCollection[] array, int index)
		{
			this.PropertyCollection.CopyTo(array.Select(this.GetPropertyValueCollection).ToArray(), index);
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		public virtual IDictionaryEnumerator GetEnumerator()
		{
			return new PropertyEnumeratorWrapper(this.PropertyCollection.GetEnumerator());
		}

		void IDictionary.Remove(object key)
		{
			((IDictionary) this.PropertyCollection).Remove(key);
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