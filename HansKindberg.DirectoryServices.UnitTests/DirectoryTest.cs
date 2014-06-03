using System.DirectoryServices;
using System.Security.Principal;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace HansKindberg.DirectoryServices.UnitTests
{
	[TestClass]
	public class DirectoryTest
	{
		[TestMethod]
		public void IdentityReference_ShouldBeAbleToMock()
		{
			var identityReferenceMock = new Mock<IdentityReference>();

			identityReferenceMock.Setup(identityReference => identityReference.Value).Returns("Test");

			var identityReferenceInstance = identityReferenceMock.Object;

			Assert.AreEqual("Test", identityReferenceInstance.Value);
		}









		#region Methods

		[TestMethod]
		public void AuthenticationTypes_ShouldReturnTheDefaultValueOfDirectoryEntryAuthenticationTypeByDefault()
		{
			AuthenticationTypes defaultAuthenticationTypes = new Directory().AuthenticationTypes;

			using(DirectoryEntry directoryEntry = new DirectoryEntry())
			{
				Assert.AreEqual(defaultAuthenticationTypes, directoryEntry.AuthenticationType);
			}

			using(DirectoryEntry directoryEntry = new DirectoryEntry("Test"))
			{
				Assert.AreEqual(defaultAuthenticationTypes, directoryEntry.AuthenticationType);
			}

			using(DirectoryEntry directoryEntry = new DirectoryEntry("Test", "Test", "Test"))
			{
				Assert.AreEqual(defaultAuthenticationTypes, directoryEntry.AuthenticationType);
			}
		}

		#endregion
	}
}