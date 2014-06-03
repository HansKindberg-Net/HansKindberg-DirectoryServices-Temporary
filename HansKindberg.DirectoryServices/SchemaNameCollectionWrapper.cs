using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.DirectoryServices;
using System.Linq;
using HansKindberg.Abstractions;

namespace HansKindberg.DirectoryServices
{
	[SuppressMessage("Microsoft.Naming", "CA1710:IdentifiersShouldHaveCorrectSuffix", Justification = "This is a wrapper.")]
	public class SchemaNameCollectionWrapper : Wrapper<SchemaNameCollection>, ISchemaNameCollection
	{
		#region Constructors

		public SchemaNameCollectionWrapper(SchemaNameCollection schemaNameCollection) : base(schemaNameCollection, "schemaNameCollection") {}

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

		public virtual string this[int index]
		{
			get { return this.WrappedInstance[index]; }
			set { this.WrappedInstance[index] = value; }
		}

		public virtual object SyncRoot
		{
			get { return ((ICollection) this.WrappedInstance).SyncRoot; }
		}

		#endregion

		#region Methods

		public virtual void Add(string item)
		{
			this.WrappedInstance.Add(item);
		}

		public virtual void AddRange(IEnumerable<string> collection)
		{
			// ReSharper disable AssignNullToNotNullAttribute
			this.WrappedInstance.AddRange(collection != null ? collection.ToArray() : null);
			// ReSharper restore AssignNullToNotNullAttribute
		}

		public virtual void AddRange(ISchemaNameCollection schemaNameCollection)
		{
			this.WrappedInstance.AddRange(this.GetWrappedSchemaNameCollection(schemaNameCollection));
		}

		public virtual void Clear()
		{
			this.WrappedInstance.Clear();
		}

		public virtual bool Contains(string item)
		{
			return this.WrappedInstance.Contains(item);
		}

		public virtual void CopyTo(string[] array, int arrayIndex)
		{
			this.WrappedInstance.CopyTo(array, arrayIndex);
		}

		public static SchemaNameCollectionWrapper FromSchemaNameCollection(SchemaNameCollection schemaNameCollection)
		{
			return schemaNameCollection;
		}

		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		public virtual IEnumerator<string> GetEnumerator()
		{
			return this.WrappedInstance.Cast<string>().GetEnumerator();
		}

		protected internal virtual SchemaNameCollection GetWrappedSchemaNameCollection(ISchemaNameCollection schemaNameCollection)
		{
			return this.GetWrappedInstance(schemaNameCollection);
		}

		public virtual int IndexOf(string item)
		{
			return this.WrappedInstance.IndexOf(item);
		}

		public virtual void Insert(int index, string item)
		{
			this.WrappedInstance.Insert(index, item);
		}

		public virtual bool Remove(string item)
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

		public static implicit operator SchemaNameCollectionWrapper(SchemaNameCollection schemaNameCollection)
		{
			return schemaNameCollection == null ? null : new SchemaNameCollectionWrapper(schemaNameCollection);
		}

		#endregion
	}
}