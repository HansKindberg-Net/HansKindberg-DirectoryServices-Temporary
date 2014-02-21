using System.Collections;
using System.DirectoryServices;

namespace HansKindberg.DirectoryServices
{
	public interface ISchemaNameCollection : IList
	{
		#region Properties

		new string this[int index] { get; set; }

		#endregion

		#region Methods

		int Add(string value);
		void AddRange(string[] value);
		void AddRange(SchemaNameCollection value);
		bool Contains(string value);
		void CopyTo(string[] stringArray, int index);
		int IndexOf(string value);
		void Insert(int index, string value);
		void Remove(string value);

		#endregion
	}
}