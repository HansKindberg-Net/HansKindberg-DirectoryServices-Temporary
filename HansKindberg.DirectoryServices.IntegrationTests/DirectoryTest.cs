using System;
using System.DirectoryServices;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HansKindberg.DirectoryServices.IntegrationTests
{
	[TestClass]
	public class DirectoryTest
	{
		#region Methods

		private static DirectoryEntry CreateDirectoryEntry(string path)
		{
			return new DirectoryEntry(path);
		}

		[TestMethod]
		public void TemporaryTest()
		{
			Directory directory = new Directory();

			using(var root = directory.Get("LDAP://local.net"))
			{
				foreach(IPropertyValueCollection propertyValueCollection in root.Properties)
				{
					string propertyName = propertyValueCollection.PropertyName;
					propertyName = propertyName;

					object value = propertyValueCollection.Value;
					value = value;
				}
			}
		}

		[TestMethod]
		public void Test()
		{
			//Assert.IsTrue(DirectoryEntry.Exists("LDAP://local.net/OU=OU-2,DC=local,DC=net"));

			//Assert.IsFalse(DirectoryEntry.Exists("LDAP://local.net/OU=OU-3,DC=local,DC=net"));

			//Assert.IsFalse(DirectoryEntry.Exists("LDAP://local.net/OU=OU-1,DC=local,DC=net"));

			using(DirectoryEntry organizationalUnit = CreateDirectoryEntry("LDAP://local.net/OU=OU-1,DC=local,DC=net"))
			{
				Guid guid = organizationalUnit.Guid; // To perform a bind (I think)

				guid = guid;

				using(DirectoryEntry root = CreateDirectoryEntry("LDAP://local.net/DC=local,DC=net"))
				{
					//foreach(var property in root.Properties)
					//{
					//	Type type = property.GetType();

					//	if(type != typeof(PropertyValueCollection))
					//		Assert.Fail("Dfafdadf");

					//	type = type;
					//}

					foreach(var property in root.Properties.Values)
					{
						Type type = property.GetType();

						if(type != typeof(PropertyValueCollection))
							Assert.Fail("Dfafdadf");

						type = type;
					}
				}
			}

			//string rootDistinguishedName;

			////"LDAP://local.net/OU=OU-1,DC=local,DC=net"

			//using(DirectoryEntry root = new DirectoryEntry("LDAP://local.net"))
			//{
			//	root.AuthenticationType = AuthenticationTypes.Secure;

			//	rootDistinguishedName = (string)root.Properties["distinguishedName"].Value;

			//	foreach(PropertyValueCollection property in root.Properties)
			//	{
			//		string propertyName = property.PropertyName;
			//		object value = property.Value;

			//		string s = "";
			//	}

			//	foreach(DirectoryEntry child in root.Children)
			//	{
			//		string path = child.Path;

			//		string distinguishedName = (string)child.Properties["distinguishedName"].Value;

			//		foreach(PropertyValueCollection property in child.Properties)
			//		{
			//			string propertyName = property.PropertyName;
			//			object value = property.Value;

			//			string s = "";
			//		}

			//	}
			//}

			//const string firstLdapHost = "directory.verisign.com";
			//const string secondLdapHost = "directory.d-trust.de";

			//Assert.AreEqual(6, new DirectoryEntry("LDAP://" + firstLdapHost, null, null, AuthenticationTypes.Anonymous).Properties.Count);

			//DirectoryEntry root = new DirectoryEntry("LDAP://" + firstLdapHost, null, null, AuthenticationTypes.Anonymous);

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