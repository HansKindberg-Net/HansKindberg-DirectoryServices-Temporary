using System.Collections;
using System.Collections.Generic;

namespace HansKindberg.DirectoryServices
{
	public interface IResultPropertyValueCollection : ICollection, IEnumerable<object>
	{
		#region Properties

		object this[int index] { get; }

		#endregion

		#region Methods

		bool Contains(object item);
		void CopyTo(object[] array, int arrayIndex);
		int IndexOf(object item);

		#endregion
	}
}