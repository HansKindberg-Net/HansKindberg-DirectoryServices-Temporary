using System.DirectoryServices;

namespace HansKindberg.DirectoryServices.Extensions
{
	public interface IPropertyValueCollectionExtension
	{
		#region Methods

		PropertyValueCollection GetPropertyValueCollection(IPropertyValueCollection propertyValueCollection);

		#endregion
	}
}