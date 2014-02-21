﻿using System;
using System.Collections;
using System.DirectoryServices;
using HansKindberg.DirectoryServices.Extensions;

namespace HansKindberg.DirectoryServices
{
	public class PropertyValueCollectionWrapper : IPropertyValueCollection, IPropertyValueCollectionInternal
	{
		#region Fields

		private readonly PropertyValueCollection _propertyValueCollection;

		#endregion

		#region Constructors

		public PropertyValueCollectionWrapper(PropertyValueCollection propertyValueCollection)
		{
			if(propertyValueCollection == null)
				throw new ArgumentNullException("propertyValueCollection");

			this._propertyValueCollection = propertyValueCollection;
		}

		#endregion

		#region Properties

		public virtual int Count
		{
			get { return this.PropertyValueCollection.Count; }
		}

		bool IList.IsFixedSize
		{
			get { return ((IList) this.PropertyValueCollection).IsFixedSize; }
		}

		bool IList.IsReadOnly
		{
			get { return ((IList) this.PropertyValueCollection).IsReadOnly; }
		}

		bool ICollection.IsSynchronized
		{
			get { return ((ICollection) this.PropertyValueCollection).IsSynchronized; }
		}

		public virtual object this[int index]
		{
			get { return this.PropertyValueCollection[index]; }
			set { this.PropertyValueCollection[index] = value; }
		}

		public virtual string PropertyName
		{
			get { return this.PropertyValueCollection.PropertyName; }
		}

		public virtual PropertyValueCollection PropertyValueCollection
		{
			get { return this._propertyValueCollection; }
		}

		object ICollection.SyncRoot
		{
			get { return ((ICollection) this.PropertyValueCollection).SyncRoot; }
		}

		public virtual object Value
		{
			get { return this.PropertyValueCollection.Value; }
			set { this.PropertyValueCollection.Value = value; }
		}

		#endregion

		#region Methods

		public virtual int Add(object value)
		{
			return this.PropertyValueCollection.Add(value);
		}

		public virtual void AddRange(object[] value)
		{
			this.PropertyValueCollection.AddRange(value);
		}

		public virtual void AddRange(IPropertyValueCollection value)
		{
			this.PropertyValueCollection.AddRange(this.GetPropertyValueCollection(value));
		}

		public virtual void Clear()
		{
			this.PropertyValueCollection.Clear();
		}

		public virtual bool Contains(object value)
		{
			return this.PropertyValueCollection.Contains(value);
		}

		public virtual void CopyTo(object[] array, int index)
		{
			this.PropertyValueCollection.CopyTo(array, index);
		}

		void ICollection.CopyTo(Array array, int index)
		{
			((ICollection) this.PropertyValueCollection).CopyTo(array, index);
		}

		public virtual IEnumerator GetEnumerator()
		{
			return this.PropertyValueCollection.GetEnumerator();
		}

		public virtual int IndexOf(object value)
		{
			return this.PropertyValueCollection.IndexOf(value);
		}

		public virtual void Insert(int index, object value)
		{
			this.PropertyValueCollection.Insert(index, value);
		}

		public virtual void Remove(object value)
		{
			this.PropertyValueCollection.Remove(value);
		}

		public virtual void RemoveAt(int index)
		{
			this.PropertyValueCollection.RemoveAt(index);
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