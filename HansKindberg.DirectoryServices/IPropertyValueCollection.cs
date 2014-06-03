using System.Collections.Generic;

namespace HansKindberg.DirectoryServices
{
	public interface IPropertyValueCollection : IList<object>
	{
		#region Properties

		string PropertyName { get; }
		object Value { get; set; }

		#endregion

		#region Methods

		void AddRange(IEnumerable<object> collection);
		void AddRange(IPropertyValueCollection propertyValueCollection);

		#endregion
	}
}