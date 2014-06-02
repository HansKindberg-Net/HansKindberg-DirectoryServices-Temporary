using System.Collections;

namespace HansKindberg.DirectoryServices
{
	public interface IPropertyDictionary : IDictionary
	{
		#region Properties

		IPropertyValueCollection this[string propertyName] { get; }
		ICollection PropertyNames { get; }

		#endregion

		#region Methods

		bool Contains(string propertyName);
		void CopyTo(IPropertyValueCollection[] array, int index);

		#endregion
	}
}