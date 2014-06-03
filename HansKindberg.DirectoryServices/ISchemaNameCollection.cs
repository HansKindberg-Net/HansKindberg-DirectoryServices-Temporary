using System.Collections.Generic;

namespace HansKindberg.DirectoryServices
{
	public interface ISchemaNameCollection : IList<string>
	{
		#region Methods

		void AddRange(IEnumerable<string> collection);
		void AddRange(ISchemaNameCollection schemaNameCollection);

		#endregion
	}
}