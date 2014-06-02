using System.Collections;
using System.Collections.Generic;
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
		void AddRange(IEnumerable<string> value);
		void AddRange(SchemaNameCollection value);
		bool Contains(string value);
		void CopyTo(string[] array, int index);
		int IndexOf(string value);
		void Insert(int index, string value);
		void Remove(string value);

		#endregion
	}
}