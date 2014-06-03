using System;
using System.Collections;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HansKindberg.Abstractions;
using HansKindberg.Abstractions.Extensions;

namespace HansKindberg.DirectoryServices
{
	public class ResultPropertyCollectionWrapper : Wrapper<ResultPropertyCollection>
	{
		public ResultPropertyCollectionWrapper(ResultPropertyCollection resultPropertyCollection) : base(resultPropertyCollection, "resultPropertyCollection") { }

		public virtual bool Contains(string propertyName)
		{
			return this.WrappedInstance.Contains(propertyName);
		}

		public virtual void CopyTo(Array array, int arrayIndex)
		{
			if (array == null)
				throw new ArgumentNullException("array");

			this.WrappedInstance.CopyTo(array, arrayIndex);

			for (int i = 0; i < array.Length; i++)
			{
				var value = array.GetValue(i);

				var resultPropertyValueCollection = value as ResultPropertyValueCollection;

				if (resultPropertyValueCollection != null)
					value = (ResultPropertyValueCollectionWrapper) resultPropertyValueCollection;
				
				array.SetValue(value, i);
			}
		}

		public virtual void CopyTo(IResultPropertyValueCollection[] array, int arrayIndex)
		{








			throw new NotImplementedException();







			//this.WrappedInstance.CopyTo(array.Select(this.GetWrappedResultPropertyValueCollection).ToArray(), arrayIndex);
		}

		//protected internal virtual ResultPropertyValueCollection GetWrappedResultPropertyValueCollection(IResultPropertyValueCollection resultPropertyValueCollection)
		//{
		//	return resultPropertyValueCollection.GetWrappedInstance<ResultPropertyValueCollection>();
		//}


		public virtual IResultPropertyValueCollection this[string name]
		{
			get { return (ResultPropertyValueCollectionWrapper)this.WrappedInstance[name]; }
		}

		public virtual ICollection PropertyNames
		{
			get { return this.WrappedInstance.PropertyNames; }
		}
		public virtual ICollection Values
		{
			get { return this.WrappedInstance.Values; }
		 }

	}
}
