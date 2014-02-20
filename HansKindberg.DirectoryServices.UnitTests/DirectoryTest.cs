using System.DirectoryServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HansKindberg.DirectoryServices.UnitTests
{
	[TestClass]
	public class DirectoryTest
	{
		#region Methods

		[TestMethod]
		public void Test()
		{
			const string firstLdapHost = "directory.verisign.com";
			const string secondLdapHost = "directory.d-trust.de";

			//Assert.AreEqual(6, new DirectoryEntry("LDAP://" + firstLdapHost, null, null, AuthenticationTypes.Anonymous).Properties.Count);

			DirectoryEntry root = new DirectoryEntry("LDAP://" + firstLdapHost, null, null, AuthenticationTypes.Anonymous);

			//IDictionary dictionary = new Hashtable();
			//dictionary.Add("Test", "Test");

			//foreach (var child in dictionary)
			//{
			//	var test = child;
			//}

			//foreach (var child in root.Properties)
			//{
			//	var test = child;
			//}
		}

		#endregion
	}
}