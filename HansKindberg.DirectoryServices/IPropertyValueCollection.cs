using System.Collections;
using System.Collections.Generic;

namespace HansKindberg.DirectoryServices
{
	public interface IPropertyValueCollection : IList
	{
		#region Properties

		string PropertyName { get; }
		object Value { get; set; }

		#endregion

		#region Methods

		void AddRange(IEnumerable<object> value);
		void AddRange(IPropertyValueCollection value);
		void CopyTo(object[] array, int index);

		#endregion
	}
}